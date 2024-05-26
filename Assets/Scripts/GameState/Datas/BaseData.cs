using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseData : MonoBehaviour
{
    public Dictionary<string, float> playerBaseData = new Dictionary<string, float>();
    public Dictionary<string, float> enemyBaseData = new Dictionary<string, float>();
    public List<AudioClip> musics = new List<AudioClip>();
    public List<Vector3> enemySpawnPoints;
    public float radius;
    public int numberSpawnPoints;
    // Start is called before the first frame update
    void Awake()
    {
        // player date
        playerBaseData["Health"] = 20;
        playerBaseData["Stamina"] = 8f; // change
        playerBaseData["Mass"] = 0.5f;
        playerBaseData["Size"] = 0.5f;
        playerBaseData["Bounciness"] = 0.5f; // optional
        playerBaseData["StaminaRegen"] = 1.90f;

        enemyBaseData["Health"] = 10f;
        //enemyBaseData["Stamina"] = 5f;
        enemyBaseData["Mass"] = 0.5f;
        enemyBaseData["Size"] = 0.5f;
        enemyBaseData["Bounciness"] = 0.5f; // optional

        SetEnemySpawnPoints(numberSpawnPoints, radius);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetEnemySpawnPoints(int numberSpawns, float radius)
    {
        enemySpawnPoints.Clear();
        float angleIncrement = 2 * Mathf.PI / numberSpawns;
        for (int i = 0; i < numberSpawns; i++)
        {
            float angle = i * angleIncrement;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);
            enemySpawnPoints.Add(new Vector3(x, 1, z));
        }
    }
}
