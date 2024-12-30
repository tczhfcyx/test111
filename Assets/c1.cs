using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class c1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        byte[] bytes = BitConverter.GetBytes(1.2);
        byte[] bye = Encoding.UTF8.GetBytes("asdfghjkl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
