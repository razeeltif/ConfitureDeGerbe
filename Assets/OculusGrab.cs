using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;
    public GameObject HandlepositionInitial;
    public GameObject skateObject;
    public GameObject trackingSpace;
    GameObject tappedObject;


    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.2 && collidingObject)
        {

            GrabObject();

            if(trackingSpace.transform.TransformVector(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand)).y > 1.1)
            {
                GetComponentInParent<Move>().CanMove = true;
            }

        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < 0.2f && objectInHand)

        {

            ReleaseObject();

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
        objectInHand.transform.position = gameObject.transform.parent.GetChild(2).transform.position;
        objectInHand.transform.SetParent(this.transform);

        objectInHand.GetComponent<Rigidbody>().isKinematic = true;

        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }

    public void ReleaseObject()
    {

        objectInHand.transform.SetParent(skateObject.transform);
        objectInHand.transform.position = HandlepositionInitial.transform.position;
        objectInHand.transform.rotation = HandlepositionInitial.transform.rotation;
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        objectInHand = null;
    }

}
