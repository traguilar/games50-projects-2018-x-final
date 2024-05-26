using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaker : MonoBehaviour
{
    public List<GameObject> levelPrefabs;
    public GameObject playerPrefab;
    public List<GameObject> enemyPrefabs;

    private PersistentDatas persistentDatas;
    private BaseData baseData;
    private Constants constants;
    private Fade fade;

    public GameObject level;
    public GameObject player;
    public PlayerStats playerStats;
    public List<GameObject> enemies;

    private bool isGameOn = true;


    // Start is called before the first frame update
    void Start()
    {
        persistentDatas = GameObject.Find("Constants").GetComponent<PersistentDatas>();
        baseData = GameObject.Find("Constants").GetComponent<BaseData>();
        constants = GameObject.Find("Constants").GetComponent<Constants>();
        /*
        persistentDatas = Constants.Instance.GetComponent<PersistentDatas>();  
        baseData = Constants.Instance.GetComponent<BaseData>();
        constants = Constants.Instance.GetComponent<Constants>();  */
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        

        // Make a level appears and set the parameters
        level = InstantiateLevel(persistentDatas.level);

        // Make the player appears and set his parameters
        player = InstantiatePlayer();
        playerStats = player.GetComponent<PlayerStats>();
        SetPlayerStats();

        // Instantiate enemies and set their parameters
        InstantiateEnemies();
        foreach (var item in enemies)
        {
            SetEnemyStats(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckVictory() && isGameOn && persistentDatas.level < 5)
        {
            StartCoroutine(Victory());
            isGameOn = false;
        }
        else if (CheckVictory() && isGameOn && persistentDatas.level == persistentDatas.numberLevels)
        {
            StartCoroutine(FinalVictory());
        }
    }

    // Instantiate Functions
    GameObject InstantiateLevel(int levelNumber)
    {
        GameObject level = Instantiate(levelPrefabs[levelNumber - 1], Vector3.zero, Quaternion.identity);
        return level;
    }

    GameObject InstantiatePlayer()
    {
        GameObject player = Instantiate(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        return player;
    }

    GameObject InstantiateEnemy(Vector3 position)
    {
        int index = Random.Range(0, enemyPrefabs.Count);
        GameObject enemy = Instantiate(enemyPrefabs[index], position, Quaternion.identity);
        return enemy;
    }

    void InstantiateEnemies()
    {
        List<Vector3> spawnPoints = baseData.enemySpawnPoints;
        for (int i = 0; i < persistentDatas.nbEnemies; i++)
        {
            GameObject enemy = InstantiateEnemy(spawnPoints[i]); // Change it to make them apperas randomly on the spawnpoints
            enemies.Add(enemy);

        }
    }

    // Set parameters functions

    public void SetPlayerStats()
    {
        playerStats.maxHealth = (int)baseData.playerBaseData["Health"] + (int)persistentDatas.playerBonuses["Health"];
        playerStats.health = playerStats.maxHealth;
        playerStats.maxStamina = (int)baseData.playerBaseData["Stamina"] + (int)persistentDatas.playerBonuses["Stamina"];
        playerStats.stamina = playerStats.maxStamina;
        playerStats.size = baseData.playerBaseData["Size"] + persistentDatas.playerBonuses["Size"];
        playerStats.mass = baseData.playerBaseData["Mass"] + persistentDatas.playerBonuses["Mass"];
        playerStats.staminaRegen = baseData.playerBaseData["StaminaRegen"] + persistentDatas.playerBonuses["StaminaRegen"];
    }

    public void SetEnemyStats(GameObject enemy)
    {
        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
        enemyStats.maxHealth = (int)baseData.enemyBaseData["Health"];
        enemyStats.health = enemyStats.maxHealth;
        enemyStats.mass = baseData.enemyBaseData["Mass"];
        enemyStats.size = baseData.enemyBaseData["Size"];

    }

    public bool CheckVictory()
    {

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator Victory()
    {
        // Change level 
        persistentDatas.level += 1;
        persistentDatas.nbEnemies += 1;
        fade.FadeIn();
        // Victory music // // // ///
        yield return new WaitForSeconds(constants.fadeTimer);
        // Cange Scene
        SceneManager.LoadScene("LevelUpState");

    }

    private IEnumerator FinalVictory()
    {
        fade.FadeIn();
        // Victory music // // // ///
        yield return new WaitForSeconds(constants.fadeTimer);
        // Cange Scene
        SceneManager.LoadScene("FinalVictory");
    }
}
