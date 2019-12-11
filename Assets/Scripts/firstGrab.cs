using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The touch has a white outglow until it is touched with the controller for the first time.
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            GetComponent<MeshRenderer>().material = noglow;
        }
    }
}
