using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For lighting up torches
public class TorchScript : MonoBehaviour
{
    public GameObject flame;
    public Material glow, notGlow;
    public MeshRenderer render;
    public MeshRenderer[] otherTorches;
    // Start is called before the first frame update
    public bool on;
    public bool oneTime = true;
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

    // When the flame of the main torch collides with the top portion of one of the other torches, that torch will turn on
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TorchScript>() && other.GetComponent<TorchScript>().on) {
            on = true;
            render.material = notGlow;
            TurnOn();         
        }

        // When controller touches the main torch, it will no longer glow. Then, the other torches will glow.
        if (other.tag == "GameController")
        {
            render.material = notGlow;
            if (oneTime)
            {
                oneTime = false;
                foreach (MeshRenderer m in otherTorches)
                {
                    m.material = glow;
                }
            }
        }
    }

}
