using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks if player is at the right area and whether he/she is starting the individual posture-immitating interaction.
public class StartStrechExercise : MonoBehaviour
{
    // Start is called before the first frame update
    public StretchController stretch;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "GameController")
        {
            stretch.begin = true;
            Destroy(gameObject);
        }
    }
}
