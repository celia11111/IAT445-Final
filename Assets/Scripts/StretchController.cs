using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For the interactions of the mural posture-immitating exercise.
public class StretchController : MonoBehaviour
{
    public GameObject[] exercises;
    public GameObject[] murals;
    public bool begin;
    public bool finished;
    public float offset;
    public GameObject head, ground; // keep track of the player's height
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            begin = false;
            StartCoroutine(doExercise());
            offset = head.transform.position.y;
        }
    }

    // Wait for the player to do the exercise. When they finishes immitating the posture of the current mural painting, activate the next mural painting.
    IEnumerator doExercise()
    {
        for (int i = 0; i < exercises.Length; i++)
        {
            GameObject g = exercises[i];
            murals[i].SetActive(true);

            g.SetActive(true);
            CheckController[] stretches = g.GetComponentsInChildren<CheckController>();
            Debug.Log(stretches[0].transform.localPosition.y);    
            yield return new WaitUntil(() => stretches[0].complete && stretches[1].complete);
            g.SetActive(false);
            murals[i].SetActive(false);
        }
        finished = true;
       
    }
}
