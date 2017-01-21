using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    private CameraFade fadePanel;
    private Image fadeImage;

	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        EventManager.Listen("level_complete", LevelComplete);
        EventManager.Listen("play_menu_button", Play);
        EventManager.Listen("back_to_menu", BackToMenu);
    }

    void OnDisable()
    {
        EventManager.Remove("level_complete", LevelComplete);
        EventManager.Remove("play_menu_button", Play);
        EventManager.Remove("back_to_menu", BackToMenu);
    }

    private void Play(object[] args)
    {
        StartCoroutine(FadeOutOnQuit(Color.white, ""));
    }

    private void BackToMenu(object[] args)
    {

    }

    private void LevelComplete(object[] args)
    {
        string key = "" + (int)args[0];
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
        StartCoroutine(FadeOutOnQuit(Color.black, "Menu"));
    }

    private IEnumerator FadeOutOnQuit(Color fadeColor, string sceneOnComplete)
    {
        if (fadePanel == null)
        {
            fadePanel = FindObjectOfType<CameraFade>();
            fadeImage = fadePanel.gameObject.GetComponent<Image>();
        }
        float timer = 0;
        while (timer < fadeDuration)
        {
            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(sceneOnComplete);
        StartCoroutine(FadeInOnStart(fadeColor));
    }

    private IEnumerator FadeInOnStart(Color fadeColor)
    {
        if(fadePanel == null)
        {
            fadePanel = FindObjectOfType<CameraFade>();
            fadeImage = fadePanel.gameObject.GetComponent<Image>();
        }
        float timer = 0;
        while (timer < fadeDuration)
        {
            fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1 - timer / fadeDuration);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
