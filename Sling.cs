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
    public Timer timerScript;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        //if mouse button is down and there is no ball, instantiate one at Vector3(0, 0, 0), no rotation, prevent if timer is up
        if(newBall == null && timerScript.isGameActive){
            newBall = Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);
            //if the ball is there
            if(newBall) {
                Vector3 newPos = newBall.position;
            }
        }

        if(Input.GetMouseButtonDown(0) && newBall && timerScript.isGameActive) {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.WorldToScreenPoint(newBall.position).z);
            Vector3 worldPos = mainCam.ScreenToWorldPoint(pos);
            newBall.position = new Vector3(worldPos.x, 0f, worldPos.z);
            Vector3 newPos = newBall.position;

        } else if(Input.GetMouseButtonUp(0) && timerScript.isGameActive) {
            Vector3 newPos = newBall.position;
        }
        
    }
}