using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks if the key is on the correct slot.
public class CheckKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shape;
    public bool startMovement;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // moves the key to the slot if the key name matches with the slot name 
        if (startMovement)
        {
            shape.transform.position = Vector3.MoveTowards(shape.transform.position, transform.position, 0.2f);
            shape.transform.rotation = Quaternion.Euler(offset);
        }
    }

    // checks key matches with the slot name
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
