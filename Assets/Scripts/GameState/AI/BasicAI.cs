using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed at which the bullet moves
    public float rotationSpeed = 50f; // Speed at which the bullet rotates towards the player
    public float detectionRadius = 10f; // Radius within which the bullet detects the player

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (player == null)
        {
            // Find the player by tag if not assigned
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Check if the player is within detection radius
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRadius)
            {
                // Calculate direction to the player
                Vector3 direction = (player.position - transform.position).normalized;

                // Calculate rotation step
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
                rb.MoveRotation(Quaternion.LookRotation(newDirection));

                // Apply force towards the player
                rb.AddForce(transform.forward * speed);
            }
        }
    }
}
