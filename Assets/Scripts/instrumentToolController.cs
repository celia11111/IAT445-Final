using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial for adding multiple audio files into one script: https://www.youtube.com/watch?v=nGpTgAK4diM&list=PLF6iBvBg-PJPH2A4iJitnMKQkDvnRTtXU&index=28&t=0s

// The rod for playing the ancient chime bells.

public class instrumentToolController : MonoBehaviour
{
    // For the 8 different sounds of the bells.
    public AudioClip smallBell1Sound;
    public AudioClip smallBell2Sound;
    public AudioClip mediumBell1Sound;
    public AudioClip mediumBell2Sound;
    public AudioClip mediumBell3Sound;
    public AudioClip bigBell1Sound;
    public AudioClip bigBell2Sound;
    public AudioClip bigBell3Sound;
    public int count;
    
    public AudioSource MusicSource;

    public bool playSmallBell1 = false;
    public bool playSmallBell2 = false;
    public bool playMediumBell1 = false;
    public bool playMediumBell2 = false;
    public bool playMediumBell3 = false;
    public bool playBigBell1 = false;
    public bool playBigBell2 = false;
    public bool playBigBell3 = false;
    public GameObject[] chimes;
    public Material glow, standard;
    public int[] sequence;

    public PickupHand toolStatus;

    // Start is called before the first frame update
    void Start()
    {
        // The sequence of the bells that we want the players to hit. Each of them would have a white outline on it.
        sequence = new int[] { 6, 3, 25, 22, 8, 4, 42, 37, 40, 43};

        GetComponent<MeshRenderer>().material = glow;

        StartCoroutine(FirstPickUp());
    }
    IEnumerator FirstPickUp ()
    {
        yield return new WaitUntil(()=> toolStatus);
        chimes[sequence[count]].GetComponent<MeshRenderer>().material = glow;
    }

    // Update is called once per frame
    void Update()
    {
        // If the rod is picked up, remove the white outglow.
        if (toolStatus && toolStatus.toolPickedUp == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = standard;
        }

        // Play the sound based on which bell is hit by the rod.
        if (playSmallBell1 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = smallBell1Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playSmallBell1 = false;
        }

        if (playSmallBell2 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = smallBell2Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playSmallBell2 = false;
        }

        if (playMediumBell1 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = mediumBell1Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playMediumBell1 = false;
        }

        if (playMediumBell2 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = mediumBell2Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playMediumBell2 = false;
        }

        if (playMediumBell3 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = mediumBell3Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playMediumBell3 = false;
        }

        if (playBigBell1 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = bigBell1Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playBigBell1 = false;
        }

        if (playBigBell2 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = bigBell2Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playBigBell2 = false;
        }

        if (playBigBell3 == true)
        {
            gameObject.GetComponent<AudioSource>().clip = bigBell3Sound;
            gameObject.GetComponent<AudioSource>().Play();
            playBigBell3 = false;
        }

    }

    // Enable the sound to play when the rod touches the bell.
    public void OnCollisionEnter(Collision otherCollision)
    {

        if (otherCollision.gameObject.tag == "smallBell1")
        {
            playSmallBell1 = true;
        }

        if (otherCollision.gameObject.tag == "smallBell2")
        {
            playSmallBell2 = true;
        }

        if (otherCollision.gameObject.tag == "mediumBell1")
        {
            playMediumBell1 = true;
        }

        if (otherCollision.gameObject.tag == "mediumBell2")
        {
            playMediumBell2 = true;
        }

        if (otherCollision.gameObject.tag == "mediumBell3")
        {
            playMediumBell3 = true;
        }

        if (otherCollision.gameObject.tag == "bigBell1")
        {
            playBigBell1 = true;
        }

        if (otherCollision.gameObject.tag == "bigBell2")
        {
            playBigBell2 = true;
        }

        if (otherCollision.gameObject.tag == "bigBell3")
        {
            playBigBell3 = true;
        }

        // Make the sequence of the bells to have the white outline one by one.
        // If the current bell is not hit, the white outglow remains shown for this bell and other bells will not have a white outline. 
        // If the current bell is hit, the white outglow will be removed from this bell and the next bell in the sequence will have a white outline.
        if (count < sequence.Length) {

            
            if (chimes[sequence[count]].Equals(otherCollision.gameObject))
            {
                count++;
                chimes[sequence[count-1]].GetComponent<MeshRenderer>().material = standard;
                if (count < sequence.Length)
                 chimes[sequence[count]].GetComponent<MeshRenderer>().material = glow;
            }
       
        }
    }
}
