using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Damages : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 preCollisionPlayerVelocity;
    private VelocityTracker velocityTrackerPlayer;
    private VelocityTracker velocityTrackerEnemy;
    public GameObject damageText;

    public UnityEvent<float, Vector3, string> showDamagesText;
    public GameObject damageTextPrefab;

    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocityTrackerPlayer = GetComponent<VelocityTracker>();
        playerStats = this.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            velocityTrackerEnemy = collision.gameObject.GetComponent<VelocityTracker>();
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();

            preCollisionPlayerVelocity = velocityTrackerPlayer.velocityList[velocityTrackerPlayer.velocityList.Count - 1];
            Vector3 preCollisionEnemyVelocity = velocityTrackerEnemy.velocityList[velocityTrackerEnemy.velocityList.Count - 1];

            Vector2 playerVelocity = new Vector2(preCollisionPlayerVelocity.x, preCollisionPlayerVelocity.z);
            Vector2 enemyVelocity = new Vector2(preCollisionEnemyVelocity.x, preCollisionEnemyVelocity.z);
            float playerMass = rb.mass;
            float enemyMass = rbEnemy.mass;

            Vector2 playerP = playerVelocity * playerMass;
            float playerPValue = playerP.magnitude;
            Vector2 enemyP = enemyVelocity * enemyMass;
            float enemyPValue = enemyP.magnitude;
            Vector2 sumP = playerP + enemyP;
            float sumPValue = sumP.magnitude;

            /*
            print("playerPValue: " + playerPValue);
            print("enemyPValue: " + enemyPValue);
            print("SumPValue: " + sumPValue);*/

            string target;
            // Damages (to be continued)
            if (playerPValue >= enemyPValue)
            {
                print("Enemy damaged");
                target = "Enemy";
            }
            else
            {
                print("Player damaged");
                target = "Player";
            }

            ContactPoint contact = collision.contacts[0];
            Vector3 collisionPoint = contact.point;

            // Method to invoke the damagesText Initialize function
            // Change it to make int and on the UI
            GameObject damageTextInstance = Instantiate(damageTextPrefab, collisionPoint, Quaternion.identity);
            damageTextInstance.GetComponent<DamagesText>().Initialize(Mathf.RoundToInt(sumPValue), collisionPoint, target);

            // Damage gestion
            if (target == "Player")
            {
                DamageThePlayer(Mathf.RoundToInt(sumPValue));
            }
            else if (target == "Enemy")
            {
                DamageTheEnemy(Mathf.RoundToInt(sumPValue), collision.gameObject);
            }
        }
    }

    void DamageThePlayer(int damages)
    {
        playerStats.health -= damages;
    }

    void DamageTheEnemy(int damages, GameObject enemy)
    {
        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
        enemyStats.health -= damages;
    }


}
