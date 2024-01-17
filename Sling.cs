using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{

    [Header("Sling Settings")]
    [SerializeField] private Transform TransPoint1;
    [SerializeField] private Transform TransPoint2;
    [SerializeField] private Transform BallPrefab;
    private Transform newBall;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if(newBall == null){
            newBall = Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);
            if(newBall) {
                Vector3 newPos = newBall.position;
            }
        }

        if(Input.GetMouseButtonDown(0) && newBall) {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.WorldToScreenPoint(newBall.position).z);
            Vector3 worldPos = mainCam.ScreenToWorldPoint(pos);
            newBall.position = new Vector3(worldPos.x, 0f, worldPos.z);
            Vector3 newPos = newBall.position;

        } else if(Input.GetMouseButtonUp(0)) {
            Vector3 newPos = newBall.position;
        }
        
    }
}