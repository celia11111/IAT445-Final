using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAppearDanceKey : MonoBehaviour
{
    public StretchController stretch;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stretch.finished)
        {
            key.SetActive(true);
            Destroy(this);
        } else
        {
            key.SetActive(false);
        }
    }
}
