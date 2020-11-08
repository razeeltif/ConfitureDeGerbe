using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRope : MonoBehaviour
{

    LineRenderer Rope;
    public GameObject LineEnd;

    // Start is called before the first frame update
    void Start()
    {
        Rope = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rope.SetPosition(0, gameObject.transform.position);
        Rope.SetPosition(1, LineEnd.transform.position);

    }
}
