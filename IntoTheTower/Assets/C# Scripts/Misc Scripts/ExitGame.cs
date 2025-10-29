using System;
using Unity.VisualScripting;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame, if player presses esc key application is closed
    void Update()
    {
        bool isEsc = Input.GetKeyDown(KeyCode.Escape);
        if (isEsc)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}
