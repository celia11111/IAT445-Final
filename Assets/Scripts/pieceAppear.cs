using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //add open door script here

            pieceAppearTimer++;
            chimePieceAppear = true;

            if (pieceAppearTimer > 100 && pieceAppearTimer < 200 && chimePieceAppear == true)
            {
                /*if (gameObject.name == "chimeDoorLeft")
                {
                    this.gameObject.transform.Translate(Vector3.left * Time.deltaTime);
                }
                if (gameObject.name == "chimeDoorRight") {
                    this.gameObject.transform.Translate(Vector3.right * Time.deltaTime);
                }*/
                if (gameObject.name == "CylinderPiece")
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
