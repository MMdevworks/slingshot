using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip goalSound;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    public void playSound(){
        playerAudio.PlayOneShot(goalSound, 1);
    }
}
