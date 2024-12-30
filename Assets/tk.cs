using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tk : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 10 * Time.deltaTime, Space.Self);
        gameObject.transform.LookAt(obj.transform);
        Instantiate(obj, gameObject.transform);
    }
}
