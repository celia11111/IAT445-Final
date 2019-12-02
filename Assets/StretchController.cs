using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchController : MonoBehaviour
{
    public GameObject[] exercises;
    public bool begin;
    public bool finished;
    public float offset;
    public GameObject head, ground;
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
    IEnumerator doExercise()
    {
        foreach (GameObject g in exercises)
        {
            g.SetActive(true);
            CheckController[] stretches = g.GetComponentsInChildren<CheckController>();
            Debug.Log(stretches[0].transform.localPosition.y);
            stretches[0].transform.position = new Vector3(stretches[0].transform.position.x, head.transform.position.y , stretches[0].transform.position.z);
            stretches[1].transform.position = new Vector3(stretches[1].transform.position.x, head.transform.position.y, stretches[1].transform.position.z);
            yield return new WaitUntil(() => stretches[0].complete && stretches[1].complete);
            g.SetActive(false);
        }
        finished = true;
       
    }
}
