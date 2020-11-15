using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesMaster : MonoBehaviour
{


    public static ScenesMaster instance;
    public string[] levelsName;
    public int levelIndex = 0;

    
    private void Awake()
    {
        if(!instance){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        if(levelIndex < levelsName.Length)
        {
            SceneManager.LoadScene(levelsName[levelIndex]);
            levelIndex++;
        }
    }

}
