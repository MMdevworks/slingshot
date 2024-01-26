using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorusMovement : MonoBehaviour
{
    public Text CounterText;
    public int Count;
    public List<GameObject> torusList;
    public int torusCount;
    public ParticleSystem burst;
    public Timer timerScript;
    public GameObject targetAxis;
    // public AudioClip goalSound;
    // private AudioSource playerAudio;
    //torus is being deactivated, so sound fx on that object will be cut- new solution: audio listener? set source on a different obj
    private void Start() {
        // playerAudio = GetComponent<AudioSource>();
        Count = 3;
        torusCount = 0;
        CounterText.text = "Level : " + Count;

        targetAxis = GameObject.Find("Axis");
    }

    void Update() {
        if(Count == 4){
            LevelFive();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball")){
            gameObject.SetActive(false);
            Destroy(other.gameObject, .5f);

            timerScript.timeChanged = true;
            // playerAudio.PlayOneShot(goalSound, 1);

            Quaternion newRotation = Quaternion.Euler(-90, 0, 0);
            Instantiate(burst, transform.position, newRotation);
            
            CheckListActive();
        } 
    }

    void SetActivation() {
            foreach(GameObject obj in torusList){
                    obj.SetActive(true);
            }
            Count += 1;
            CounterText.text = "Level : " + Count;
    }

    bool CheckListActive(){
        foreach(GameObject obj in torusList) {
            if(obj.activeSelf) {
                return false;
            }
        }
        Invoke("SetActivation", 1);
        return true;
    }
    
    void LevelFive(){
        foreach(GameObject obj in torusList){
            obj.transform.RotateAround(targetAxis.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
