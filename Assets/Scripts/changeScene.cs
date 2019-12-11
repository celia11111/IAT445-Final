using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        // when player enters the collider, change to the next scene
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "GameController");
        {
            // from the desert scene to the underground palace scene
            if (SceneManager.GetActiveScene().name == "desert")
            {
                SceneManager.LoadScene(1);
            }
            
            // from the underground palace scene to the secret room / treasure room scene
            if (SceneManager.GetActiveScene().name == "underground")
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
