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
    // private bool listActive = true;
    public int torusCount;

    private void Start() {
        Count = 3;
        torusCount = 0;
        CounterText.text = "Level : " + Count;
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball")){
            gameObject.SetActive(false);
            Destroy(other.gameObject, .5f);
            CheckListActive();
        } 
    }

    void SetActivation() {
            foreach(GameObject obj in torusList){
                    obj.SetActive(true);
            }
    }
    bool CheckListActive(){
        foreach(GameObject obj in torusList) {
            if(obj.activeSelf) {
                return false;
            }
        }
        SetActivation();
        return true;
    }
}
