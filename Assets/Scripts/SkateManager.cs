using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateManager : MonoBehaviour
{

    public static SkateManager instance;

    public bool endDetected;

    public bool alive = true;


    private void Awake()
    {
        if(!instance){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
    }


    public void OnTriggerEnter(Collider other)
    {
        //Debug.LogError(other.name);
        if (other.tag == "DeadlyObstacle")
        {
            instance.GetComponent<MoveUpdated>().Stop();
            GameManager.instance.GameOver();
        }
        else if(other.tag == "Teleport")
            {
            this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, other.gameObject.transform.Find("RespawnPoint").transform.position.z);
        }
        else if (other.tag == "PlayerStopper")
        {

            GetComponent<MoveUpdated>().Stop();
            endDetected = true;
        }
        
        if (other.tag == "Checkpoint")
        {
            GameManager.instance.SaveCheckPoint(other.GetComponent<Checkpoint>().RespawnPoint.position);
        }

        
    }

}
