using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchHour : MonoBehaviour
{
    Text textObject;
    string changeableText;
    int speedInKMH;
    float speedinKMHfloat;
    int watchMode;
    public bool tap, tapRegistered;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        tap = false;
        watchMode = 0;
        speedInKMH = 0;
        textObject = gameObject.transform.Find("Canvas").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tap && !tapRegistered)
        {
            watchMode++;
            if (watchMode > 1) watchMode = 0; //A changer si on ajoute des nouveaux modes
            tapRegistered = true;
        }

        switch (watchMode)
        {
            case 0:
                speedinKMHfloat = player.GetComponent<MoveUpdated>().speedCoef * 50;
                speedInKMH = (int)speedinKMHfloat;
                changeableText = speedInKMH.ToString() + " Km/h";
                textObject.text = changeableText;
                break;
            case 1:
                changeableText = System.Math.Round(Time.timeSinceLevelLoad,1).ToString();
                textObject.text = changeableText + " s";
                break;
        }
    }
}
