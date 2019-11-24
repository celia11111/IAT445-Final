using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrumentToolController : MonoBehaviour
{
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
        sequence = new int[] { 6, 3, 25, 22, 8, 4, 42, 37, 40, 43};
        /*MusicSource.clip = smallBell1Sound;
        MusicSource.clip = smallBell2Sound;
        MusicSource.clip = mediumBell1Sound;
        MusicSource.clip = mediumBell2Sound;
        MusicSource.clip = mediumBell3Sound;
        MusicSource.clip = bigBell1Sound;
        MusicSource.clip = bigBell2Sound;
        MusicSource.clip = bigBell3Sound;*/

        //chimes[sequence[0]].GetComponent<MeshRenderer>().material = glow;


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
        if (toolStatus && toolStatus.toolPickedUp == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = standard;
        }

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

        if (count < sequence.Length) {

            
            if (chimes[sequence[count]].Equals(otherCollision.gameObject))
            {
                count++;
                chimes[sequence[count-1]].GetComponent<MeshRenderer>().material = standard;
                if (count < sequence.Length)
                 chimes[sequence[count]].GetComponent<MeshRenderer>().material = glow;
            }
            










           /* if (otherCollision.gameObject.tag == "smallBell1" ||
                otherCollision.gameObject.tag == "smallBell2" ||
                otherCollision.gameObject.tag == "mediumBell1" ||
                otherCollision.gameObject.tag == "mediumBell2" ||
                otherCollision.gameObject.tag == "mediumBell3" ||
                otherCollision.gameObject.tag == "bigBell1" ||
                otherCollision.gameObject.tag == "bigBell2" ||
                otherCollision.gameObject.tag == "bigBell3")
            {
                count++;
            }*/

            /*if (otherCollision.gameObject.tag == "smallBell1")
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
            }*/
        }
    }
}
