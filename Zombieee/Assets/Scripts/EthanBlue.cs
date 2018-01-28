using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EthanBlue : HitObject
{
    public Text scoreText;
    public Image hpFill;
    private int health;
    public int score;
    public int hitBy;
    private float time;

    public void Initialize()
    {
        health = 100;
        score = 0;
        hitBy = 0;
        time = 0f;
        UpdateHealthFill();
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Blue : " + score;
    }

    void UpdateHealthFill()
    {
        hpFill.fillAmount = health / 100f;
    }

    public override bool Hit(float direction)
    {
        hitBy++;
        health -= 5;
        if (health <= 0f)
        {
            health = 0;
            gameObject.SetActive(false);
        }
        UpdateHealthFill();
        return false;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 10f)
        {
            time -= 10f;
            if (health < 100)
            {
                health++;
                UpdateHealthFill();
            }
        }
    }
}
