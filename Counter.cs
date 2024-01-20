using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public float speed;
    public Vector3 startPoint;
    public Vector3 endPoint;
    // private bool movingToEnd = true;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
        startPoint = new Vector3(15, 0, 25);
        endPoint = new Vector3(-15, 0, 25);
    }

    //will want to make a moving script once more obj are added
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPoint, endPoint, time);
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        Destroy(other.gameObject, 1f);
    }
}
