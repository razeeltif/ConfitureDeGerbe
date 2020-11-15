using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadManager : MonoBehaviour
{

    public Rigidbody SkateRigibody;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeadlyObstacle")
        {
            SkateRigibody.gameObject.GetComponent<MoveUpdated>().speedCoef = 0;
            SkateRigibody.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            SkateRigibody.gameObject.GetComponent<MoveUpdated>().enabled = false;
            GameManager.instance.GameOver();
        }   
    }
}
