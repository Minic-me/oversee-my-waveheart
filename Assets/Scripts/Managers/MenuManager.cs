using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject selectionLevelMenu;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject fadePanel;

    private bool _gameEnded;

    private int _numberLevelSelected;

    void Start()
    {
        EventManager.Listen("game_ended", GameEnded);
        _gameEnded = false;
        _numberLevelSelected = -1;
        HideAll();
        startMenu.SetActive(true);
    }

    void OnDisable()
    {
        EventManager.Remove("game_ended", GameEnded);
    }

    private void GameEnded(object[] args)
    {
        _gameEnded = true;
    }

    private void HideAll()
    {
        startMenu.SetActive(false);
        selectionLevelMenu.SetActive(false);
        credits.SetActive(false);
        fadePanel.SetActive(false);
    }

    public void PlayButtonStartMenu()
    {
        if (_gameEnded)
        {
            HideAll();
            selectionLevelMenu.SetActive(true);
        }
        else
        {
            fadePanel.SetActive(true);
            EventManager.Send("play_menu_button", "level_2");
        }
    }
    public void CreditsButtonStartMenu()
    {
        HideAll();
        credits.SetActive(true);
    }
    public void BackButtonCreditMenu()
    {
        HideAll();
        startMenu.SetActive(true);
    }
    public void QuitButtonStartMenu()
    {
        Application.Quit();
    }

    public void Level1ButtonSelectionMenu()
    {
        _numberLevelSelected = 1;
        EventManager.Send("play_menu_button", "level_" + _numberLevelSelected);
    }
    public void Level2ButtonSelectionMenu()
    {
        _numberLevelSelected = 2;
        EventManager.Send("play_menu_button", "level_" + _numberLevelSelected);
    }
    public void Level3ButtonSelectionMenu()
    {
        _numberLevelSelected = 3;
        EventManager.Send("play_menu_button", "level_" + _numberLevelSelected);
    }
    public void Level4ButtonSelectionMenu()
    {
        _numberLevelSelected = 4;
        EventManager.Send("play_menu_button", "level_" + _numberLevelSelected);
    }
    public void Level5ButtonSelectionMenu()
    {
        _numberLevelSelected = 5;
        EventManager.Send("play_menu_button", "level_" + _numberLevelSelected);
    }
}
