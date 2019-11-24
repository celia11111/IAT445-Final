using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickupHand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null; // whether pick up or not (either true or false)

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null; 
    public List<Interactable> m_ContactInteractables = new List<Interactable>();

    public bool toolPickedUp = false;


    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();

    }


    private void Update()
    {
        //down
        if (m_GrabAction.GetStateDown(m_Pose.inputSource)) // either left or right
        {
            print(m_Pose.inputSource + "Trigger Down");
            Pickup();
        }

        //up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Trigger Up");
            Drop();
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
        if (other.gameObject.GetComponent<instrumentToolController>())
        {
            other.gameObject.GetComponent<instrumentToolController>().toolStatus = this;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
        

    }

    public void Pickup()
    {
        // Get nearest
        m_CurrentInteractable = GetNearestInteractable();

        // Null check
        if (!m_CurrentInteractable)
            return;
        m_CurrentInteractable.GetComponent<Rigidbody>().isKinematic = true;
        // Already held, check
        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();

        Vector3 offset = new Vector3(0, 0, 0);
        // Position it to our controller
        if (m_CurrentInteractable.GetComponent<instrumentToolController>())
            offset = new Vector3(2, 0, 0);

        //m_CurrentInteractable.transform.position = transform.position + offset;

        //if (m_CurrentInteractable.GetComponent<instrumentToolController>())
        //    m_CurrentInteractable.transform.localRotation = Quaternion.Euler(90, 0, 0);


            // Attach the rigidbody of the interactable to the fixed joint of the hands
            Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        //m_Joint.connectedBody = targetBody;
        targetBody.transform.parent = transform;
        // Set active hand variable to our interactable script
        m_CurrentInteractable.m_ActiveHand = this;

        toolPickedUp = true;
    }


    public void Drop()
    {
        // Null check
        if (!m_CurrentInteractable)
            return;
        m_CurrentInteractable.GetComponent<Rigidbody>().isKinematic = false;
        // Apply velocity to the dropped object from controller
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();
        // Detach it from the joint
        //m_Joint.connectedBody = null;
        targetBody.transform.parent = null;
        // Clear
        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;



    }

    private Interactable GetNearestInteractable() // pick up the nearest one
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Interactable interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }

        }

        return nearest;
    }


}

