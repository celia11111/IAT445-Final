using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnCollisionEnter(Collision otherCollision)
    {
        tool.OnCollisionEnter(otherCollision);
    }
}
