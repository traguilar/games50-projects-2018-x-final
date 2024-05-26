using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BetweenEnemyCollision : MonoBehaviour
{
    private Rigidbody rb;
    private VelocityTracker velocityTrackerThis;
    private VelocityTracker velocityTrackerEnemy;
    private EnemyStats enemyStats;
    private EnemyStats enemyStatsThis;
    private Vector3 preCollisionThisVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocityTrackerThis = GetComponent<VelocityTracker>();
        enemyStatsThis = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            velocityTrackerEnemy = collision.gameObject.GetComponent<VelocityTracker>();
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();

            preCollisionThisVelocity = velocityTrackerThis.velocityList[velocityTrackerThis.velocityList.Count - 1];
            Vector3 preCollisionEnemyVelocity = velocityTrackerEnemy.velocityList[velocityTrackerEnemy.velocityList.Count - 1];

            Vector2 playerVelocity = new Vector2(preCollisionThisVelocity.x, preCollisionThisVelocity.z);
            Vector2 enemyVelocity = new Vector2(preCollisionEnemyVelocity.x, preCollisionEnemyVelocity.z);
            float playerMass = rb.mass;
            float enemyMass = rbEnemy.mass;

            Vector2 playerP = playerVelocity * playerMass;
            float playerPValue = playerP.magnitude;
            Vector2 enemyP = enemyVelocity * enemyMass;
            float enemyPValue = enemyP.magnitude;
            Vector2 sumP = playerP + enemyP;
            float sumPValue = sumP.magnitude;

            string target;
            if (playerPValue >= enemyPValue)
            {
                print("Enemy damaged");
                target = "Enemy";
            }
            else
            {
                print("Player damaged");
                target = "This";
            }

            if (target == "Enemy")
            {
                enemyStats = collision.gameObject.GetComponent<EnemyStats>();
                enemyStats.health -= 1;
            }
            /*else if (target == "This")
            {
                enemyStatsThis.health -= 1;
            }*/
        }

    }
}
