using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shape;
    public bool startMovement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startMovement)
        {
            shape.transform.position = Vector3.MoveTowards(shape.transform.position, transform.position, 0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name.Equals(shape.name))
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            startMovement = true;
        }
    }
}
