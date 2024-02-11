using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TorusMovement : MonoBehaviour
{
    public Text CounterText;
    public int Count;
    public List<GameObject> torusList;
    public ParticleSystem burst;
    public Timer timerScript;
    public AudioPlayer audioPlayer;
    public GameObject targetAxis;
    public TextMeshProUGUI endText;
    
    private void Start() {
        GameObject soundPole = GameObject.Find("Sound Pole");
        audioPlayer = soundPole.GetComponent<AudioPlayer>();
        
        Count = 4;
        CounterText.text = "Level : " + Count;

        targetAxis = GameObject.Find("Axis");
    }

    void Update() {
        if(Count == 5){
            LevelFive();
        }
        if(Count == 6){
            foreach(GameObject obj in torusList){
                obj.SetActive(false);
                Debug.Log("Count 5 -> Level 6");
            }
            TheEnd();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball")){
            gameObject.SetActive(false);
            Destroy(other.gameObject, .5f);

            timerScript.timeChanged = true;
            audioPlayer.playSound();

            Quaternion newRotation = Quaternion.Euler(-90, 0, 0);
            Instantiate(burst, transform.position, newRotation);
            
            CheckListActive();
        } 
    }

    void SetActivation() {
            foreach(GameObject obj in torusList){
                    obj.SetActive(true);
            }
            CounterText.text = "Level : " + Count;
            Debug.Log("Set activation complete");
    }

    bool CheckListActive(){
        foreach(GameObject obj in torusList) {
            if(obj.activeSelf) {
                return false;
            }
                Debug.Log("Checsk list active = FALSE");
        }
        Count += 1;
        Invoke("SetActivation", 1);
        return true;
    }
    
    void LevelFive(){
        foreach(GameObject obj in torusList){
            obj.transform.RotateAround(targetAxis.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
            Debug.Log("Level 5 function activated");
    }

    public void TheEnd(){
        endText.gameObject.SetActive(true);
    }
}