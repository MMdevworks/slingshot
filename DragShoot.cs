using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{
    private Vector3 mouseDownPos;
    private Vector3 mouseUpPos;
    private Rigidbody rb;
    private bool isShot;  
    private float zBound = 40;  

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (transform.position.z > zBound)
            {
                Destroy(gameObject);
            }
    }

    void OnMouseDown() {
        mouseDownPos = Input.mousePosition;
    }

    void OnMouseUp() {
        rb.isKinematic = false;  
        mouseUpPos = Input.mousePosition;
        Shoot(Force: mouseDownPos-mouseUpPos);
    }

    private float forceMultiplier = 3;

    void Shoot(Vector3 Force) {
        if(isShot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, z: Force.y) * forceMultiplier);
        isShot = true;
    }

    private void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.CompareTag("ground")) {
        Destroy(gameObject);
        }  
    }
}


