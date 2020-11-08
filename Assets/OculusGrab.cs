using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;
    public GameObject HandlepositionInitial;
    public GameObject skateObject;
    GameObject parent;
    Vector3 parentPrevious;
    public GameObject trackingSpace;
    float velocity;

    private void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f && collidingObject)

        {
            GrabObject();

            if(trackingSpace.transform.TransformVector(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand)).y > 1.1)
            {
                //Finish here
            }

        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < 0.2f && objectInHand)

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
