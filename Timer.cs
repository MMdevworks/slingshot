using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public TextMeshProUGUI timeText;
    public bool timeChanged = false;

    void Update()
    {
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Floor(timeRemaining);
        }

        if (timeRemaining > 0 && timeChanged){
            timeRemaining += 10; 
            timeText.text = "Time: " + Mathf.Floor(timeRemaining);
            timeChanged = false; 
        }

        if (timeRemaining <= 0){
            timeText.text = "Time's up!";
         }
        
    }
}

