using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrabLeft : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;
    public PositionRotation HandlepositionInitial;
    public GameObject skateObject;
    public GameObject trackingSpace;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.2f && collidingObject)

        {
            GrabObject();

            if(trackingSpace.transform.TransformVector(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LHand)).y > 1.1)
            {
                GetComponentInParent<Move>().CanMove = true;
            }

        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.2f && objectInHand)

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
    }

    public void OnTriggerExit(Collider other)
    {
        collidingObject = null;
    }

    public void GrabObject()
    {
        objectInHand = collidingObject;

        HandlepositionInitial = new PositionRotation();
        HandlepositionInitial.position = collidingObject.transform.position;
        HandlepositionInitial.rotation = collidingObject.transform.rotation;

        objectInHand.transform.SetParent(this.transform);

        objectInHand.GetComponent<Rigidbody>().isKinematic = true;

        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }

    public void ReleaseObject()
    {

        objectInHand.transform.SetParent(skateObject.transform);
        objectInHand.transform.position = HandlepositionInitial.position;
        objectInHand.transform.rotation = HandlepositionInitial.rotation;
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        objectInHand = null;
    }


    public struct PositionRotation {
        public Vector3 position;
        public Quaternion rotation;

    }

}
