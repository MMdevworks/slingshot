using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public bool timeChanged = false;
    public Button restartButton;
    public bool isGameActive = true;

    void Start() {
    }

    void Update()
    {
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Floor(timeRemaining);
        }

        if (timeRemaining > 0 && timeChanged){
            timeRemaining += 10; // Add the desired time
            timeText.text = "Time: " + Mathf.Floor(timeRemaining);
            timeChanged = false; // Set timeChanged back to false
        }

        if (timeRemaining <= 0){
            timeText.text = "Time's up!";
            isGameActive = false;
            GameOver();
         }     
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

