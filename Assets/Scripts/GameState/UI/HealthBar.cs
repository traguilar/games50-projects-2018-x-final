using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject player;
    private PlayerStats playerStats;


    private void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();

    }


    public void SetValue(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        SetMaxValue(playerStats.maxHealth);
        SetValue(playerStats.health);
    }
}

