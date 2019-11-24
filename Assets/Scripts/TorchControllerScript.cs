using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControllerScript : MonoBehaviour
{
    public GameObject[] torches;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void AllOn()
    {
        foreach (GameObject torch in torches)
        {
            torch.GetComponent<TorchScript>().on = true;
            torch.GetComponent<TorchScript>().TurnOn();
        }
    }
}
