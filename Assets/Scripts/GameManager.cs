using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using OVR;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;
    int tutoPhase;
    public GameObject player;
    public GameObject tutoText;
    public GameObject tutoLoopObj;

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

        tutoPhase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //reset game when pressing 'A'
        if(OVRInput.GetDown(OVRInput.Button.One)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(SceneManager.GetActiveScene().name == "TutoScene")
        {
            tutoPhase = Tutoriel(tutoPhase, tutoText.GetComponent<Text>(), player.GetComponent<Move>().actualSpeed, Camera.main.transform.rotation.eulerAngles.z);
            if (tutoPhase == 4) tutoLoopObj.SetActive(false);
        }
    }






    public void GameOver()
    {
        // TODO : ECRAN DE GAME OVER + INDIQUER RESET SUR 'A'
        Debug.Log("DEA DEA DEA DEA DEA DEAD EA DEA DEA");
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
    }
