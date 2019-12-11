using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//if the object/key falls though the floor which is set to 46, reset the position of the key and speed
public class FallThroughGroundProtection : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 46)
        {
            transform.position = new Vector3(transform.position.x, 49.1f, transform.position.z);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
