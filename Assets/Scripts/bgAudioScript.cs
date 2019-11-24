using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAudioScript : MonoBehaviour
{
    public AudioClip MusicClip; // to hold the audios;
    public AudioSource MusicSource; // reference to the audio source
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip; // load audio into AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = true;
    }
}
