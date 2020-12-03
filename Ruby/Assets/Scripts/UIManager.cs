﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private string levelToLoad;
    public AudioClip beep;

    public static bool closeUserGuide = false;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playBtnSound()
    {
        audio.clip = beep;
        audio.Play();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
    }

    public void PlayBtnClicked()
    {
        levelToLoad = "StoryStartScene";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitBtnClicked()
    {
        playBtnSound();
        Application.Quit();
    }

    public void CreditBtnClicked()
    {
        levelToLoad = "RubyCredit";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }

    public void CreditExitBtnClicked()
    {
        levelToLoad = "RubyMainMenu";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }

    public void StartGameBtnClicked()
    {
        levelToLoad = "RubyChapter1Level1";
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }

    public void CloseUserGuide()
    {
        closeUserGuide = true;
    }
}
