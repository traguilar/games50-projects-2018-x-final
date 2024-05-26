using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float stamina;
    public int maxStamina;
    public float size;
    public float mass;
    public float staminaRegen;

    private LevelMaker levelMaker;
    // Start is called before the first frame update
    void Start()
    {
        levelMaker = GameObject.Find("LevelMaker").GetComponent<LevelMaker>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
