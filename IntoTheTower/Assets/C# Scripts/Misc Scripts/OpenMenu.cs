using System;
using Unity.VisualScripting;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject pausePanel;
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
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
