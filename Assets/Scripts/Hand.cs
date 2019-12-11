using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// For using the controller to grab the object. 
public class Hand : PickupHand
{

    public SteamVR_Action_Boolean m_TriggerAction = null;
    public SteamVR_Action_Boolean m_TouchpadAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null; // current item that is picked up by the player
    public List<Interactable> m_ContactInteractables = new List<Interactable>(); // a list of items that can be picked up

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();  
      }
    

    private void Update()
    {
        // Start grabbing the item when pressing the trigger.
        if (m_TriggerAction.GetLastStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "TriggerDown");

            if (m_CurrentInteractable != null)
            {
                m_CurrentInteractable.Action();
                return;
            }
            Pickup();
        }

        // Stop grabbing the item when releasing the trigger.
        if (m_TouchpadAction.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Touchpad Up");
            Drop();
        }
    }

    // Trigger the grabbing event for the specific object when the controller touches it.
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Grab"))
            return;
        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }

    // Not trigger the grabbing event for the specific object when the controller not touches it.
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Grab"))
            return;
        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    // When picking up the object, make the object's position change with the controller.
    public void Pickup()
    {
        m_CurrentInteractable = GetNearestInteractable();

        if (!m_CurrentInteractable)
            return;

        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();

        m_CurrentInteractable.ApplyOffset(transform);

        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        m_CurrentInteractable.m_ActiveHand = this;
    }

    // When dropping the object, do not let the object follow the position of the controller.
    public void Drop()
    {
        if (!m_CurrentInteractable)
            return;

        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();


        m_Joint.connectedBody = null;

        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;

    }

    // Checking the item that is about to be grabbed based on the distance between the item and the controller.
    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(Interactable interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
