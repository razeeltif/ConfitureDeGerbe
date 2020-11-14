using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateHandle : Interactable
{

    public GameObject trackingSpace;

    private void Update()
    {
        if(isGrabbed){
            if(trackingSpace.transform.TransformVector(OVRInput.GetLocalControllerVelocity(grabbingHand)).y > 1.1)
            {
                GetComponentInParent<MoveUpdated>().CanMove = true;
            } 
        }
    }


    public override void ActionGrab()
    {}

    public override void ActionRelease()
    {}
}
