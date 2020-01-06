using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Tutorial for grabbing: 
1. https://www.youtube.com/watch?v=HnzmnSqE-Bc&list=PLF6iBvBg-PJPH2A4iJitnMKQkDvnRTtXU&index=30&t=0s
2. https://www.youtube.com/watch?v=ryfUXr5yvKw&list=PLF6iBvBg-PJPH2A4iJitnMKQkDvnRTtXU&index=31&t=0s
3. https://www.youtube.com/watch?v=RcTVZq_Du5c&list=PLF6iBvBg-PJPH2A4iJitnMKQkDvnRTtXU&index=32&t=98s
*/

// Script for interactable items.
[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{

    public Vector2 m_Offest = Vector3.zero;

    [HideInInspector]
    public PickupHand m_ActiveHand = null;

    public virtual void Action()
    {

    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.identity;
        transform.localPosition = m_Offest;
        transform.SetParent(null);
    }
}
