using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wait for all the torches to be on. Then, play the animation of the door opens.
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

}
