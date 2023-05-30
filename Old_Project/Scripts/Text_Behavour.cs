using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Text_Behavour : MonoBehaviour
{
    public Rigidbody2D PlayerRb;
    public TextMeshProUGUI MetersPassed;
    public GameObject Player,PlayText;
    private Transform PlayerPos;
    private double PlayerY;
    private Touch TextTouch;

    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.GetComponent<Transform>();
        PlayerY = Math.Round(PlayerPos.position.y) / 10;

        if (PlayerRb.velocity.y > 0)
        {
            MetersPassed.text = "" + PlayerY;
        }
    }
}
