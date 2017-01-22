using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject greyPanel;
    [SerializeField] private GameObject UIPanel;

    void Start()
    {
        greyPanel.SetActive(false);
        UIPanel.SetActive(false);
        EventManager.Listen("pause", PauseGame);
    }
    void OnDisable()
    {
        EventManager.Remove("pause", PauseGame);
    }

    public void BackButtonUIInGame()
    {
        EventManager.Send("resume");
        greyPanel.SetActive(false);
        UIPanel.SetActive(false);
    }

    public void RestartButtonUIInGame()
    {
        EventManager.Send("resume");
        greyPanel.SetActive(false);
        UIPanel.SetActive(false);
        EventManager.Send("restart_current");
    }

    public void BackToMenuButtonUIInGame()
    {
        EventManager.Send("resume");
        greyPanel.SetActive(false);
        UIPanel.SetActive(false);
        EventManager.Send("play_menu_button", "Menu");
    }

    private void PauseGame(object[] args)
    {
        greyPanel.SetActive(true);
        UIPanel.SetActive(true);
    }
}
