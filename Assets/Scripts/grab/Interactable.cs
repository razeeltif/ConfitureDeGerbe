using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool isGrabbed = false;
    public OVRInput.Controller grabbingHand;

    public void Grab(OVRInput.Controller hand)
    {
        isGrabbed = true;
        grabbingHand = hand;
        ActionGrab();
    }

    public void Release(OVRInput.Controller hand)
    {
        isGrabbed = false;
        grabbingHand = OVRInput.Controller.None;
        ActionRelease();
    }


    public abstract void ActionGrab();

    public abstract void ActionRelease();

}
