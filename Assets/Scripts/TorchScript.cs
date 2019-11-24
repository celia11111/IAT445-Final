using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    public GameObject flame;
    // Start is called before the first frame update
    public bool on;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn()
    {
        flame.SetActive(true);

    }
    public void TurnOff()
    {
        flame.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TorchScript>() && other.GetComponent<TorchScript>().on) {
            on = true;
            TurnOn();
            GameObject.Find("TorchController").GetComponent<TorchControllerScript>().AllOn();
        }
    }
}
