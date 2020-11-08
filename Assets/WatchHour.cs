using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchHour : MonoBehaviour
{
    Text textObject;
    string Speedtext;
    int speedInKMH;
    float speedinKMHfloat;
    // Start is called before the first frame update
    void Start()
    {
        speedInKMH = 0;
        textObject = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedinKMHfloat = gameObject.transform.parent.parent.parent.parent.parent.GetComponent<Move>().actualSpeed * 50;
        speedInKMH = (int) speedinKMHfloat;
        Speedtext = speedInKMH.ToString() + " Km/h";
        textObject.text = Speedtext;
    }
}
