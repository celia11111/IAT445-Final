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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "GameController");
        {
            if (SceneManager.GetActiveScene().name == "desert")
            {
                SceneManager.LoadScene(1);
            }
            
            if (SceneManager.GetActiveScene().name == "underground")
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
