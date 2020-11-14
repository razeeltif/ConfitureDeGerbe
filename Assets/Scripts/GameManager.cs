using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using OVR;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        //reset game when pressing 'A'
        if(OVRInput.GetDown(OVRInput.Button.One)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }






    public void GameOver()
    {
        // TODO : ECRAN DE GAME OVER + INDIQUER RESET SUR 'A'
        Debug.Log("DEA DEA DEA DEA DEA DEAD EA DEA DEA");
    }

}
