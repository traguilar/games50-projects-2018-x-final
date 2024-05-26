using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Slider slider;
    public Image fill;
    public GameObject enemy;
    private EnemyStats enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        enemyStats = enemy.GetComponent<EnemyStats>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        SetMaxHealth();
        SetHealth();
    }

    void SetMaxHealth()
    {
        slider.maxValue = enemyStats.maxHealth;
    }

    void SetHealth()
    {
        slider.value = enemyStats.health;
    }
}
