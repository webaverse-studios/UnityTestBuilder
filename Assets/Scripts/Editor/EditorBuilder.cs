using System;
using System.Collections.Generic;
using UnityEditor;

class EditorBuilder
{
    static string[] SCENES = FindEnabledEditorScenes();

    static string APP_NAME = "YourProject";
    static string TARGET_DIR = "target";

    [MenuItem("Custom/CI/Build Windows")]
    static void PerformMacOSXBuild()
    {
        string target_dir = APP_NAME + ".app";
        GenericBuild(SCENES, TARGET_DIR + "/" + target_dir, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    private static string[] FindEnabledEditorScenes()
    {
        List<string> EditorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }

    static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
        var res = BuildPipeline.BuildPlayer(scenes, target_dir, build_target, build_options);
       var summary= res.summary;
        if (summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            throw new Exception("BuildPlayer failure");
        }
    }
}