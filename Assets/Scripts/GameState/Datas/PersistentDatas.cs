using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PersistentDatas : MonoBehaviour
{
    public int level;
    public int nbEnemies;
    public Dictionary<string, float> playerBonuses = new Dictionary<string, float>();
    public List<string> activeBonuses;
    public int numberLevels;
    /*
     * possible bonuses
     * max stamina
     * max health
     * regenstamina
     * size
     * mass
     * damping optional
     * bouciness optional
     */


    // Start is called before the first frame update
    void Awake()
    {
        RestartParameters();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBonuses()
    {
        // Clear the bonuses
        List<string> keys = new List<string>(playerBonuses.Keys);

        // Réinitialiser les bonus
        foreach (string key in keys)
        {
            playerBonuses[key] = 0f;
        }
        // Set the bonuses
        foreach (string bonus in activeBonuses)
        {
            if (bonus == "Health")
            {
                playerBonuses[bonus] += 2f;
            }
            else if (bonus == "Stamina")
            {
                playerBonuses[bonus] += 1f;
            }
            else if (bonus == "StaminaRegen")
            {
                playerBonuses[bonus] += 0.2f;
            }
            else if (bonus == "Mass")
            {
                playerBonuses[bonus] += 0.2f;
            }
            else if (bonus == "Size")
            {
                playerBonuses[bonus] += 0.2f;
            }
 
        }
    }

    public void RestartParameters()
    {
        level = 1;
        nbEnemies = 2;
        playerBonuses["Health"] = 0f;
        playerBonuses["Stamina"] = 0f;
        playerBonuses["Mass"] = 0f;
        playerBonuses["Size"] = 0f;
        playerBonuses["Bounciness"] = 0f; // optional
        playerBonuses["StaminaRegen"] = 0f;

        activeBonuses = new List<string>();
        numberLevels = 5;
    }
}
