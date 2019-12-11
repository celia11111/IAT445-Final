using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For the second controller for the rod for playing the ancient chime bells.
// It checks the state of the first controller to prevent overlapping commands and bugs.
public class otherinstrumentTool : instrumentToolController

{
    public instrumentToolController tool;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<MeshRenderer>().material = glow;

    }

    // Update is called once per frame
    public void Update()
    {
        if (toolStatus && toolStatus.toolPickedUp == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = standard;
           
        }

    }

    // passes info to the first (main) controller
    public void OnCollisionEnter(Collision otherCollision)
    {
        tool.OnCollisionEnter(otherCollision);
    }
}
