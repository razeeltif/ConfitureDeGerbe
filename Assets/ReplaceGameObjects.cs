﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ReplaceGameObjects : ScriptableWizard
{

    public bool copyValues = true;
    public GameObject NewType;
    public GameObject[] OldObjects;



    [MenuItem("Custom/Replace GameObjects")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        //Transform[] Replaces;
        //Replaces = Replace.GetComponentsInChildren<Transform>();

        foreach (GameObject go in OldObjects)
        {
            GameObject newObject;
            newObject = (GameObject)PrefabUtility.InstantiatePrefab(NewType);
            newObject.transform.position = go.transform.position;
            newObject.transform.rotation = go.transform.rotation;
            newObject.transform.parent = go.transform.parent;

            DestroyImmediate(go);

        }

    }
}


