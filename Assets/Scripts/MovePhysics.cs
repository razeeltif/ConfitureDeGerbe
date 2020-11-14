using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePhysics : MonoBehaviour
{

    public float MaxSpeed = 5;

    private Rigidbody rb;

    public bool move = false;

    public float actualSpeed = 0;

    public bool IsOnGround = false;

    public GameObject front;


    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    private void Update(){

        if(!IsOnGround){
            return;
        }

        move = Input.GetKey(KeyCode.Space);
        if(move){
            actualSpeed = MaxSpeed;
        }else{
            actualSpeed = 0;
        }


    }

    private void FixedUpdate(){


        Vector3 vecAngleBetweenSkateAndGround = new Vector3();
        IsOnGround = GetGroundAngle(front.transform.position, this.transform.forward, out vecAngleBetweenSkateAndGround);

        if(IsOnGround){

            rb.velocity = vecAngleBetweenSkateAndGround * actualSpeed * Time.fixedDeltaTime;
           // rb.AddForce(newVec * actualSpeed * Time.fixedDeltaTime);

           // rb.velocity = transform.forward * actualSpeed;
        }else{

        }
       // if(move){
            
       // }
    }

   /* private void OnCollisionEnter(){
        IsOnGround = true;
    }

    private void OnCollisionStay(){
        IsOnGround = true;
    }

    private void OnCollisionExit(){
        IsOnGround = false;
    }*/

    private bool GetGroundAngle(Vector3 initialPosition, Vector3 forward, out Vector3 newVec){
        bool resultisOnGround = false;
        Debug.DrawRay(initialPosition, -transform.up * 0.6f, Color.cyan);
        RaycastHit hit;
        resultisOnGround = Physics.Raycast(initialPosition, -Vector3.up, out hit, 0.6f);
        Vector3 norm = hit.normal;
        Vector3 vect1 = new Vector3(0,-norm.z*2.2f,1);
        newVec = (forward + vect1).normalized;
        Debug.Log(newVec);
        return resultisOnGround;

    }

}
