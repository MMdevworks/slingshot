using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Counter : MonoBehaviour
{
    public Text CounterText;
    public TextMeshProUGUI timeText;
    public float speed;
    public Vector3 startPoint = new Vector3(15, 0, 25);
    public Vector3 endPoint = new Vector3(-15, 0, 25);
    private int Count = 0;
    public float moveSpeed = 3f;
    public GameObject torus1;
    public GameObject torus2;
    public GameObject torus3;
    public GameObject box;
    public ParticleSystem burst;
    public Timer timerScript;
    public float time;

    private void Start() {
        Count = 0;
        float time = timerScript.timeRemaining;
    }

        //will want to make a moving script once more obj are added
    void Update() {
        if(Count == 2) {
            StartCoroutine(CountdownRoutine()); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Level : " + Count;
        Destroy(other.gameObject, 1f);

        // timeText.text = "Time: " + Mathf.Floor(timerScript.timeRemaining + 10);
        // time = Mathf.Floor(timerScript.timeRemaining + 10);

        Quaternion newRotation = Quaternion.Euler(-90, 0, 0);
        Instantiate(burst, transform.position, newRotation);

        if(Count == 1 ){
            // Invoke("LevelTwo", 1);
            Invoke("LevelFour", 1);
        }
        if(Count == 3 ){
            Invoke("LevelFour", 1);
        }
    }

    void LevelTwo(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 15);
    }

    void LevelFour(){
        torus1.gameObject.SetActive(true);
        torus2.gameObject.SetActive(true);
        torus3.gameObject.SetActive(true);
        box.gameObject.SetActive(false);
    }

    IEnumerator CountdownRoutine(){
        yield return new WaitForSeconds(1);
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPoint, endPoint, time);
    }    
}
