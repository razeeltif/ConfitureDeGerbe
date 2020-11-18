using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OVR;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;
    int tutoPhase;

    public GameObject tutoText;
    public GameObject tutoLoopObj;
    public GameObject deathToDisplay;
    public GameObject tutoObject;

    public Checkpoint actualCheckpoint = null;

    private Vector3 initialPlayerPosition;

    private Vector3 LastCheckpointPosition = Vector3.zero;

    [HideInInspector]
    public int deathCount;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = SkateManager.instance.transform.position;
        tutoPhase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SkateManager.instance.endDetected && OVRInput.GetDown(OVRInput.Button.One))
        {
            //load next level
        }
        else if (SkateManager.instance.endDetected && OVRInput.GetDown(OVRInput.Button.Three))
        {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //reset game when pressing 'A'
        else if (OVRInput.GetDown(OVRInput.Button.One)){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if(SkateManager.instance.endDetected)
            {
                ScenesMaster.instance.LoadNextLevel();
            }
            else
            {
                deathToDisplay.SetActive(false);
                deathCount++;
                LoadLastCheckPoint();
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two)){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ScenesMaster.instance.LoadNextLevel();
        }

        if(SceneManager.GetActiveScene().name == "TutoScene")
        {
            tutoObject.SetActive(true);
            tutoPhase = Tutoriel(tutoPhase, tutoText.GetComponent<Text>(), SkateManager.instance.GetComponent<MoveUpdated>().speedCoef, Camera.main.transform.rotation.eulerAngles.z);
            if (tutoPhase == 4) tutoLoopObj.SetActive(false);
        }
    }


    public void GameOver()
    {
        SkateManager.instance.alive = false;
        deathToDisplay.SetActive(true);
    }


    public int Tutoriel(int phase, Text textObject, float pSpeed, float eulerCasqueZ)
    {
        switch (phase) {
            case 0:
                textObject.text = "Pull the Handle";
                if (pSpeed > 0.1f) phase++;
                break;
            case 1:
                //Le joueur doit se baisser pour accélérer (aller chercher vitesse)
                textObject.text = "Crouch to accelerate";
                if (pSpeed > 0.5f) phase++;
            break;
            case 2:
                //Le joueur doit se lever pour ralentir (aller chercher vitesse)
                textObject.text = "Get up to slow down";
                if (pSpeed < 0.2f) phase++;
                break;
            case 3:
                //Le joueur doit se balance pour tourner (aller chercher le X du joueur sur pls frame différentes)
                textObject.text = "balance right and left to turn";
                if (eulerCasqueZ > 15 || eulerCasqueZ < -15) phase++;
                break;
            case 4:
                //Le joueur doit esquiver ses premiers obstacles
                textObject.text = "Dodge the obstacles";
                break;
        }
        return phase;
    }

        public void SaveCheckPoint(Vector3 checkpointPosition)
    {
        LastCheckpointPosition = checkpointPosition;
    }

    public void LoadLastCheckPoint()
    {
        SkateManager.instance.alive = true;
        SkateManager.instance.GetComponent<MoveUpdated>().Stop();

        // no checkpoint passed, spawn at the beginning
        if(LastCheckpointPosition == Vector3.zero)
        {
            SkateManager.instance.transform.position = initialPlayerPosition;
        }
        else
        {
            SkateManager.instance.transform.position = LastCheckpointPosition;
        }

    }



}
