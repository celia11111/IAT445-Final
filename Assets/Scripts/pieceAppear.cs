using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Playing a short piece of music when the player finishes hitting all of the designated bells.
public class pieceAppear : MonoBehaviour
{
    public instrumentToolController tool;
    private int pieceAppearTimer = 0;

    bool chimePieceAppear = false;

    public AudioClip appearSound; // to hold the audios;
    public AudioSource MusicSource; // reference to the audio source

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = appearSound; // load audio into AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        if (tool.count > 9)
        {
            pieceAppearTimer++;
            chimePieceAppear = true;

            // Delay the time for playing the sound after the player finishes hitting all of the bells in the sequence.
            if (pieceAppearTimer > 100 && pieceAppearTimer < 200 && chimePieceAppear == true)
            {
               
                // play the sound
                if (gameObject.name == "ChimeEndingAudio")
                {
                    this.gameObject.GetComponent<AudioSource>().enabled = true;
                    this.gameObject.transform.Translate(Vector3.up * Time.deltaTime);
                }
            }
            else
            {
                this.gameObject.transform.Translate(Vector3.zero);
            }


        }
    }
}
