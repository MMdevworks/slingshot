using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotate : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       transform.Rotate(Vector3.forward * Time.deltaTime * 5); 
    }
}
