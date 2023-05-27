using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public GameObject Play_Button, Player, Platform, MetreCounter,Pause_Button, Resume_Button,Quit_Button,Camera,KillWall;
    public Button StartButton, PauseButton, ResumeButton,QuitButton;

    private void Start()
    {
        StartButton.onClick.AddListener(PlayButton);
        PauseButton.onClick.AddListener(PauseButtonSet);
        ResumeButton.onClick.AddListener(ResumeButtonSet);
        QuitButton.onClick.AddListener(QuitButtonSet);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("MenuScene");
        Camera.SetActive(true);
        Play_Button.SetActive(true);
        KillWall.SetActive(false);
        Quit_Button.SetActive(false);
        Resume_Button.SetActive(false);
        Pause_Button.SetActive(false);
        Player.SetActive(false);
        Platform.SetActive(false);
        MetreCounter.SetActive(false);
    }

    void PlayButton()
    {
        Play_Button.SetActive(false);
        KillWall.SetActive(true);
        Pause_Button.SetActive(true);
        Player.SetActive(true);
        Platform.SetActive(true);
        MetreCounter.SetActive(true);
    }

    void PauseButtonSet()
    {
        Pause_Button.SetActive(false);
        Quit_Button.SetActive(true);
        Resume_Button.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeButtonSet()
    {
        Pause_Button.SetActive(true);
        Quit_Button.SetActive(false);
        Resume_Button.SetActive(false);
        Time.timeScale = 1;
    }

    void QuitButtonSet()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
