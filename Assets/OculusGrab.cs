using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;
    public GameObject HandlepositionInitial;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f && collidingObject)

        {
            GrabObject();
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
        objectInHand.transform.position = HandlepositionInitial.transform.position;

        objectInHand.GetComponent<Rigidbody>().isKinematic = false;

        objectInHand.transform.SetParent(null);

        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        objectInHand = null;
    }
}
