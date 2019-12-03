using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControllerScript : MonoBehaviour
{
    public GameObject[] torches;
    public bool allOn;
    public Animator anime;
    void Start()
    {
        
    }

    void Update()
    {
        allOn = true;
        foreach (GameObject torch in torches) {
            if (!torch.GetComponent<TorchScript>().on)
                allOn = false;
        }
        if (allOn)
            anime.SetBool("open", true);
    }

    //public void AllOn()
    //{
        //foreach (GameObject torch in torches)
        //{
        //    torch.GetComponent<TorchScript>().on = true;
        //    torch.GetComponent<TorchScript>().TurnOn();
        //}
    //}
}
