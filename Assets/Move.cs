using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // get center camera (audio listener because reason)
    AudioListener MainCamera;

    public float speedCoef = 1f;
    public float maxHeight = 2f;
    public float minHeight = 1f;

    public float height = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        MainCamera = GetComponentInChildren<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
      /*  RaycastHit hit;
        Physics.Raycast(MainCamera.transform.position, Vector3.down, out hit, 100);

        if(hit.distance > 0){
            height = hit.distance;
        }*/

    height = MainCamera.transform.localPosition.y;

    if(height > maxHeight) height = maxHeight;
    if(height < minHeight) height = minHeight;

    float coef = Mathf.InverseLerp(maxHeight, minHeight, height);

    transform.eulerAngles =  new Vector3(transform.rotation.eulerAngles.x, MainCamera.transform.localRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    transform.Translate(transform.forward * coef * speedCoef);

    }
}
