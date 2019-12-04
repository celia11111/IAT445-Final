using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    public GameObject flame;
    public Material glow, notGlow;
    public MeshRenderer render;
    public MeshRenderer[] otherTorches;
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
            render.material = notGlow;
            render.materials[0] = notGlow;
            render.materials[1] = notGlow;
            TurnOn();
            //GameObject.Find("TorchController").GetComponent<TorchControllerScript>().AllOn();
        }
        if (other.tag == "GameController")
        {
            //GetComponent<Rigidbody>().isKinematic = true;
            render.material = notGlow;
            render.materials[0] = notGlow;
            render.materials[1] = notGlow;
            foreach (MeshRenderer m in otherTorches) {
                m.material = glow;
                m.materials[0] = glow;
                m.materials[1] = glow;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
        {
            //GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
