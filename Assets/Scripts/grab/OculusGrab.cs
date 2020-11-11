using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrab : MonoBehaviour
{
    public bool leftHand = false;
    public GameObject collidingObject;
    public GameObject objectInHand;
    private PositionRotation HandlepositionInitial;
    public GameObject skateObject;
    GameObject tappedObject;


    private void Awake(){
        HandlepositionInitial = new PositionRotation();
    }

    private void Update()
    {
        if(leftHand)
        {
            UpdateLeft();
        }
        else
        {
            UpdateRight();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            collidingObject = other.gameObject;
        }

        else if (other.tag == "Tappable")
        {
            tappedObject = other.gameObject;
            tappedObject.GetComponent<WatchHour>().tap = true;
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        collidingObject = null;

        if (tappedObject != null)
        {
            tappedObject.GetComponent<WatchHour>().tapRegistered = false;
            tappedObject.GetComponent<WatchHour>().tap = false;
        }
        tappedObject = null;
    }

    public void GrabObject()
    {
        objectInHand = collidingObject;

        HandlepositionInitial.position = collidingObject.transform.localPosition;
        HandlepositionInitial.rotation = collidingObject.transform.localRotation;
        
        objectInHand.transform.SetParent(this.transform);

        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        objectInHand.GetComponent<Interactable>().Grab(leftHand ? OVRInput.Controller.LHand : OVRInput.Controller.RHand);
    }

        public void ReleaseObject()
    {
        objectInHand.GetComponent<Interactable>().Release(leftHand ? OVRInput.Controller.LHand : OVRInput.Controller.RHand);
        
        objectInHand.transform.SetParent(skateObject.transform);
        objectInHand.transform.localPosition = HandlepositionInitial.position;
        objectInHand.transform.localRotation = HandlepositionInitial.rotation;
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        objectInHand = null;

    }


    public void UpdateLeft(){
        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.2f && collidingObject)
        {
            if(!collidingObject.GetComponent<Interactable>().isGrabbed)
            {
                GrabObject();
            }

        }

        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2f && objectInHand)
        {
            ReleaseObject();
        }
    }

    public void UpdateRight(){
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.2 && collidingObject)
        {
            if(!collidingObject.GetComponent<Interactable>().isGrabbed)
            {
                GrabObject();  
            }

        }

        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.2f && objectInHand)
        {
            ReleaseObject();
        }
    }


    public struct PositionRotation {
        public Vector3 position;
        public Quaternion rotation;

    }
}
