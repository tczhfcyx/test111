using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dq : MonoBehaviour
{
    public Transform a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,60*Time.deltaTime);
        transform.LookAt(a);
     
    }
}
