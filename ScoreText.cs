using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private void Start()
        {
            UpdateScore(0);
            
        }

    public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;      
        }

    private void OnTriggerEnter(Collider other)
        {
            {
                score += 1;
                scoreText.text = "Score : " + score;
            }
        }
}
