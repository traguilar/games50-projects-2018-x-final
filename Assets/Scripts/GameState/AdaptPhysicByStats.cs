using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptPhysicByStats : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.CompareTag("Player"))
        {
            PlayerStats playerStats = GetComponent<PlayerStats>();
            transform.localScale = Vector3.one * playerStats.size;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = playerStats.mass;
        }
        else if (this.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = GetComponent<EnemyStats>();
            transform.localScale = Vector3.one * enemyStats.size;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = enemyStats.mass;
        }
    }
}
