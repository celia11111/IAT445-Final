using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAppearChimeKey : MonoBehaviour
{
    public instrumentToolController tool;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tool.count > 9)
        {
            key.SetActive(true);
            Destroy(this);
        } else
        {
            key.SetActive(false);
        }
    }
    
}
