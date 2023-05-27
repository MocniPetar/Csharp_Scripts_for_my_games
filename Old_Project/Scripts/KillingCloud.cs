using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillingCloud : MonoBehaviour
{
    public GameObject KillCloud, Player,Restart_Button,DeadMessage;
    public float SpeedOfCloud=10f;
    public Button RestartButton;

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("GameScene");
        RestartButton.onClick.AddListener(LevelRestart);
        KillCloud.transform.Translate(Vector2.up * SpeedOfCloud * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Igrac")
        {
            Player.SetActive(false);
            DeadMessage.SetActive(true);
            Restart_Button.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Restart_Button.SetActive(false);
            DeadMessage.SetActive(false);
        }
    }

    void LevelQuit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
