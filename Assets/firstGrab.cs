using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstGrab : MonoBehaviour
{
    // Start is called before the first frame update
    public Material noglow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "GameController")
        {
            GetComponent<MeshRenderer>().material = noglow;
        }
    }
}
