using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeDoor : MonoBehaviour
{
    public instrumentToolController tool;
    private int doorOpenTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tool.count > 9)
        {
            //add open door script here

            doorOpenTimer++;

            if (doorOpenTimer>100 && doorOpenTimer < 1000){
                if (gameObject.name == "chimeDoorLeft")
                {
                    this.gameObject.transform.Translate(Vector3.left * Time.deltaTime);
                }
                if (gameObject.name == "chimeDoorRight") {
                    this.gameObject.transform.Translate(Vector3.right * Time.deltaTime);
                }
            } else {
                this.gameObject.transform.Translate(Vector3.zero);
            }
            
        
        }
    }
}
