﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using OVR;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           if(OVRInput.GetDown(OVRInput.Button.One)){
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           }
    }
}
