using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks if the door is touched. If so, plays the animation.
public class DoorHolder : MonoBehaviour
{
    private Animator _animator = null;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    // If touching, open the door.
    void OnTriggerEnter(Collider collider)
    {
        _animator.SetBool("isopen", true);
    }

    // If not touching, do not open the door.
     void OnTriggerExit(Collider collider)
    {
      _animator.SetBool("isopen", false);  
    }
}
