using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    private float health;
    private float healthTo;
    private int energy;
    public Image healthFill;
    public Image energyFill;
    private float time;
    private int seconds;
    private int hitCount;
    private int shotsFired;

    public void Initialize()
    {
        health = 1000;
        healthTo = 1000;
        energy = 50;

        time = 0f;
        seconds = 0;
        hitCount = 0;
        shotsFired = 0;

        UpdateHealthFill();
        UpdateEnergyFill();
    }

    public bool GetEnergy()
    {
        if (energy <= 0)
            return false;
        energy--;
        UpdateEnergyFill();
        shotsFired++;
        return true;
    }

    public void GotHit()
    {
        hitCount++;
        healthTo -= 10;
        if ( healthTo <= 0)
        {
            healthTo = 0;
        }
    }

    void UpdateEnergyFill()
    {
        energyFill.fillAmount = energy / 50f;
    }

    void UpdateHealthFill()
    {
        if ( health == 0f)
        {
            Utility.endRect.Initialize(shotsFired, Utility.gameRect.gameObjects.GetComponent<ZombieInstantiater>().zombiesSpawned , hitCount);
            Utility.gameRect.gameObject.SetActive(false);
            Utility.gameRect.gameObjects.SetActive(false);
        }
        healthFill.fillAmount = health / 1000f;
    }

    private void Update()
    {
        if ( healthTo != health)
        {
            if (Mathf.Abs(health - healthTo) < 0.5f)
                health = healthTo;
            else if (health > healthTo)
            {
                if (health - healthTo > 10f)
                    health -= Random.Range(5f,10f);
                else
                    health -= Random.Range(0.1f, 0.5f);
            }
            else
            {
                if (healthTo - health > 10f)
                    health += Random.Range(5f, 10f);
                else
                    health += Random.Range(0.1f, 0.5f);
            }
            UpdateHealthFill();
        }
        time += Time.deltaTime;

        if ( time >= 1f)
        {
            time -= 1f;
            if ( energy < 50)
            {
                energy++;
                UpdateEnergyFill();
            }
            seconds++;

            if ( seconds == 10)
            {
                seconds = 0;
                if (healthTo + 10 > 1000)
                    healthTo = 1000;
                else
                    healthTo += 10;
            }
        }
    }
}
