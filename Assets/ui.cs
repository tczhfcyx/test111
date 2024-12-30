using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public Rect rect;
    public GUIContent content;
    public GUIStyle sty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Label(rect, content,sty);
        if(GUI.Button(rect,content))
        {
            SceneManager.LoadScene("111");

        }
        
    }
}
