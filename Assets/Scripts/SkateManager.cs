using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateManager : MonoBehaviour
{
    public Camera mainCamera;

    SphereCollider headCollider;


    void Awake()
    {
        headCollider = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // UpdateHeadColliderPosition();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeadlyObstacle")
        {
            GetComponentInParent<MoveUpdated>().speedCoef = 0;
            GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
            GetComponentInParent<MoveUpdated>().enabled = false;
            GameManager.instance.GameOver();
        }
        else if(other.tag == "Teleport")
            {
            this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, other.gameObject.transform.Find("RespawnPoint").transform.position.z);
        }
    }

    public void UpdateHeadColliderPosition()
    {
        headCollider.center = mainCamera.transform.localPosition;
    }

}
