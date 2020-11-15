using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpdated : MonoBehaviour
{


    public float MaxSpeed = 5;
    public float maxHeight = 2f;
    public float minHeight = 1f;

    [HideInInspector]
    public float height = 0;

    // strife
    public float SpeedStrife = 1f;

    public float minStrifeAngle = 10f;
    public float maxStrifeAngle = 90f;

    [HideInInspector]
    public bool CanMove = false;



    [HideInInspector]
    public float speedCoef = 0;


    [HideInInspector]
    public bool IsOnGround = false;

    public GameObject front;

    // get center camera (audio listener because reason)
    AudioListener MainCamera;
    private Rigidbody rb;
    public float distance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        rb = GetComponent<Rigidbody>();
        MainCamera = GetComponentInChildren<AudioListener>();
    }

    private void Update()
    {
     /*   Debug.DrawRay(front.transform.position, -Vector3.up * distance, Color.cyan);
        RaycastHit hit;
            Vector3 vecAngleBetweenSkateAndGround = new Vector3();
            IsOnGround = GetGroundAngle(front.transform.position, this.transform.forward, out vecAngleBetweenSkateAndGround);
        Debug.Log(IsOnGround);*/
    }

    private void FixedUpdate(){


        if(CanMove)
        {
            MoveForward();
            Strife(SpeedStrife);
        }
    }

    private void MoveForward()
    {
            speedCoef = GetSpeedCoef();
            speedCoef *= speedCoef;

            Vector3 vecAngleBetweenSkateAndGround = new Vector3();
            IsOnGround = GetGroundAngle(front.transform.position, this.transform.forward, out vecAngleBetweenSkateAndGround);

            if(IsOnGround)
            {
                rb.velocity = vecAngleBetweenSkateAndGround * speedCoef * MaxSpeed * Time.fixedDeltaTime;
            }
    }

    private void Strife(float speedStrife){

        float speedToStrifeCoef = GetSpeedCoef();

        float HeadLeanAngle = MainCamera.transform.rotation.eulerAngles.z;

        // strife left
        if(HeadLeanAngle < 180){
        
            float angleCoef = Mathf.InverseLerp(minStrifeAngle, maxStrifeAngle, HeadLeanAngle);
            rb.velocity = new Vector3(-angleCoef * speedStrife * speedToStrifeCoef, rb.velocity.y, rb.velocity.z);
           // transform.Translate(-transform.right * angleCoef * speedStrife * speedToStrifeCoef);

        // strife right
        }else{
            HeadLeanAngle = 360 - HeadLeanAngle;
            float angleCoef = Mathf.InverseLerp(minStrifeAngle, maxStrifeAngle, HeadLeanAngle);
            rb.velocity = new Vector3(angleCoef * speedStrife * speedToStrifeCoef, rb.velocity.y, rb.velocity.z);
           // transform.Translate(transform.right * angleCoef * speedStrife * speedToStrifeCoef);
        }
    }


    private float GetSpeedCoef()
    {

        height = MainCamera.transform.localPosition.y;

        if(height > maxHeight) height = maxHeight;
        if(height < minHeight) height = minHeight;

        return  Mathf.InverseLerp(maxHeight, minHeight, height);

    }

    private bool GetGroundAngle(Vector3 initialPosition, Vector3 forward, out Vector3 newVec){

        float distance = 1f;
        bool resultisOnGround = false;
 
        RaycastHit hit;
        resultisOnGround = Physics.Raycast(initialPosition, -Vector3.up, out hit, distance);
        Vector3 norm = hit.normal;
        Vector3 vect1 = new Vector3(0,-norm.z*2.2f,1);
        newVec = (forward + vect1).normalized;
        Debug.Log(newVec);
        return resultisOnGround;

    }

}
