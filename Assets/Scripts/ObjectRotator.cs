using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] float speed = 50;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }
}
