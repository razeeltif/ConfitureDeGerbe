using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSkate : MonoBehaviour
{
    public ParticleSystem PSVitesse;
    public ParticleSystem PSTurbo;
    public ParticleSystem PSTurbo2;
    private float ActualSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ActualSpeed = transform.parent.parent.GetComponent<Move>().actualSpeed;
        PSVitesse.gameObject.SetActive(false);
        PSTurbo.gameObject.SetActive(false);
        PSTurbo2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var EmissionPSV = PSVitesse.emission;
        var EmissionPST1 = PSTurbo.emission;
        var EmissionPST2 = PSTurbo2.emission;

        ActualSpeed = transform.parent.parent.GetComponent<Move>().actualSpeed;

        if(ActualSpeed > 0.1f)
        {
            PSVitesse.gameObject.SetActive(true);
            PSTurbo.gameObject.SetActive(true);
            PSTurbo2.gameObject.SetActive(true);
            EmissionPSV.rateOverTime = ActualSpeed * 500;
            EmissionPST1.rateOverTime = ActualSpeed * 100;
            EmissionPST2.rateOverTime = ActualSpeed * 100;
        }
        else
        {
            PSVitesse.gameObject.SetActive(false);
            PSTurbo.gameObject.SetActive(false);
            PSTurbo2.gameObject.SetActive(false);
        }  
    }
}
