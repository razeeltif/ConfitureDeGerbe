using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSkate : MonoBehaviour
{
    public ParticleSystem PSVitesse;
    public ParticleSystem PSTurbo;
    private float ActualSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ActualSpeed = transform.parent.parent.GetComponent<Move>().actualSpeed;
        PSVitesse.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var EmissionPSV = PSVitesse.emission;
        ActualSpeed = transform.parent.parent.GetComponent<Move>().actualSpeed;
        Debug.Log(ActualSpeed);
        if(ActualSpeed > 0.1f)
        {
            PSVitesse.gameObject.SetActive(true);
            EmissionPSV.rateOverTime = ActualSpeed * 500;
        }
        else
        {
            PSVitesse.gameObject.SetActive(false);
        }  
    }
}
