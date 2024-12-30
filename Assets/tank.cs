using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    public float s = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, s * Time.deltaTime, Space.Self);
    }
}
