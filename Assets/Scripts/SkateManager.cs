using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateManager : MonoBehaviour
{
    public Camera mainCamera;

    SphereCollider headCollider;


    void Awake(){
        headCollider = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeadColliderPosition();
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DeadlyObstacle")
        {
            this.GetComponent<Move>().actualSpeed = 0;
            this.GetComponent<Move>().enabled = false;
            GameManager.instance.GameOver();
        }
    }

    public void UpdateHeadColliderPosition()
    {
        headCollider.center = mainCamera.transform.localPosition;
    }

}
