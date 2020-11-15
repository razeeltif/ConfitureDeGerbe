using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateManager : MonoBehaviour
{

    public static SkateManager instance;

    public bool endDetected;


    private void Awake()
    {
        if(!instance){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
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
        else if (other.tag == "PlayerStopper")
        {
            gameObject.GetComponent<MoveUpdated>().CanMove = false;
            endDetected = true;
        }
        
        if (other.tag == "Checkpoint")
        {
            GameManager.instance.SaveCheckPoint(other.GetComponent<Checkpoint>().RespawnPoint.position);
        }

        
    }

    public void ResetPlayer()
    {
        GetComponent<MoveUpdated>().CanMove = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
