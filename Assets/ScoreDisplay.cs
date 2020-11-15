using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    float timeStamp;

    int deathCount;

    Text deathObject;
    Text timeObject;

    bool printed;

    public GameObject gameManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        printed = false;
        deathObject = transform.Find("DeathScore").GetComponent<Text>();
        timeObject = transform.Find("TimeScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<SkateManager>().endDetected && !printed)
        {
            deathCount = gameManager.GetComponent<GameManager>().deathCount;
            timeStamp = Time.timeSinceLevelLoad;
            printed = true;
        }
        else if(player.GetComponent<SkateManager>().endDetected && printed)
        {
            deathObject.text = deathCount.ToString();
            timeObject.text = timeStamp.ToString();
        }
    }
}
