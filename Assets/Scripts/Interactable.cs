using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
