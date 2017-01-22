using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject selectionLevelMenu;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject fadePanel;

    private int _numberLevelSelected;

    void Start()
    {
        _numberLevelSelected = -1;
        HideAll();
        startMenu.SetActive(true);
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
        if (PlayerPrefs.GetInt("game_ended") == 1)
        {
            HideAll();
            selectionLevelMenu.SetActive(true);
        }
        else
        {
            fadePanel.SetActive(true);
            EventManager.Send("play_menu_button", "level_1");
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
}
