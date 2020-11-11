using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    static public MusicPlayer instance;





    private void Awake()
    {
        if(!instance){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }
}
