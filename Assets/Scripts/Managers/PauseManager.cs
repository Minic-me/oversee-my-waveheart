using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    void Start()
    {
        EventManager.Listen("resume", ResumeGame);
    }
    void OnDisable()
    {
        EventManager.Remove("resume", ResumeGame);
    }

    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            EventManager.Send("pause");
        }
    }

    private void ResumeGame(object[] args)
    {
        Time.timeScale = 1;
    }
}
