using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSkate : MonoBehaviour
{
    public ParticleSystem PSVitesse;
    public ParticleSystem PSTurbo;
    public ParticleSystem PSTurbo2;
    Animator animator;
    private float ActualSpeed;
    public bool stopped;
    // Start is called before the first frame update
    void Start()
    {
        ActualSpeed = transform.parent.GetComponent<MoveUpdated>().speedCoef;
        PSVitesse.gameObject.SetActive(false);
        PSTurbo.gameObject.SetActive(false);
        PSTurbo2.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Stopped", stopped);
        var EmissionPSV = PSVitesse.emission;
        var EmissionPST1 = PSTurbo.emission;
        var EmissionPST2 = PSTurbo2.emission;

        ActualSpeed = transform.parent.GetComponent<MoveUpdated>().speedCoef;

        if(ActualSpeed > 0.1f && transform.parent.GetComponent<MoveUpdated>().enabled)
        {
            stopped = false;
            PSVitesse.gameObject.SetActive(true);
            PSTurbo.gameObject.SetActive(true);
            PSTurbo2.gameObject.SetActive(true);
            EmissionPSV.rateOverTime = ActualSpeed * 500;
            EmissionPST1.rateOverTime = ActualSpeed * 100;
            EmissionPST2.rateOverTime = ActualSpeed * 100;
        }
        else
        {
            stopped = true;
            PSVitesse.gameObject.SetActive(false);
            PSTurbo.gameObject.SetActive(false);
            PSTurbo2.gameObject.SetActive(false);
        }  
    }
}
