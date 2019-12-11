using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for pickupable items to check if controller is touching them
public class CheckController : MonoBehaviour
{
    // Start is called before the first frame update
    public int timer;
    public int HoldFor;
    public bool touching;
    public bool complete;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (touching)
            timer++;
        else
            timer = 0;
        if (timer >= HoldFor)
            complete = true;
        else
            complete = false;
    }

    // checking if the controller touches the item
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            touching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
        {
            touching = false;
        }
    }
}
