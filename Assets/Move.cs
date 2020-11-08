using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // get center camera (audio listener because reason)
    AudioListener MainCamera;

    // speed
    public float SpeedForward = 1f;
    public float maxHeight = 2f;
    public float minHeight = 1f;

    public float height = 0;

    // strife
    public float SpeedStrife = 1f;

    public float minStrifeAngle = 10f;
    public float maxStrifeAngle = 90f;
    
    public float speedToStrifeCoef = 3;

    public float actualSpeed = 0;

    public bool CanMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        MainCamera = GetComponentInChildren<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {

        if(CanMove)
        {
            Speed(SpeedForward);

            Strife(SpeedStrife, actualSpeed);
        }
    }


    private void Speed(float speedCoef){

        height = MainCamera.transform.localPosition.y;

        if(height > maxHeight) height = maxHeight;
        if(height < minHeight) height = minHeight;

        float coef = Mathf.InverseLerp(maxHeight, minHeight, height);


        transform.Translate(transform.forward * coef * speedCoef);

        actualSpeed = coef;
    }


    private void Strife(float speedStrife, float actuSpeed){


        actuSpeed *= speedToStrifeCoef;
        if(actualSpeed > 1) actualSpeed = 1;

        float HeadLeanAngle = MainCamera.transform.rotation.eulerAngles.z;

        // strife left
        if(HeadLeanAngle < 180){
        
            float coef = Mathf.InverseLerp(minStrifeAngle, maxStrifeAngle, HeadLeanAngle);
            transform.Translate(-transform.right * coef * speedStrife * actuSpeed);

        // strife right
        }else{
            HeadLeanAngle = 360 - HeadLeanAngle;
            float coef = Mathf.InverseLerp(minStrifeAngle, maxStrifeAngle, HeadLeanAngle);
            transform.Translate(transform.right * coef * speedStrife * actuSpeed);
        }

    }
}
