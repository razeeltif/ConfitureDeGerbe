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
            SkateManager.instance.GetComponent<MoveUpdated>().StopHard();
            GameManager.instance.GameOver();
        }   
    }
}
