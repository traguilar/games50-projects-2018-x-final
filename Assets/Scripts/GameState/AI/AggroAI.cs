using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroAI : MonoBehaviour
{

    public Transform player; // Reference to the player's transform
    public float force = 5f; 
    public float rotationSpeed = 50f; // Speed at which the bullet rotates towards the player
    public float detectionRadius = 10f; // Radius within which the bullet detects the player
    [SerializeField] private float timeBeforeAttack;
    private bool isInMovement;

    private Rigidbody rb;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (!isInMovement)
        {
            Attack();
        }
    }

    void Attack()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= detectionRadius)
        {
            StartCoroutine(LaunchAttack());
        }
    }

    private IEnumerator LaunchAttack()
    {
        yield return new WaitForSeconds(timeBeforeAttack);
        isInMovement = true;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);
        yield return new WaitForSeconds(timeBeforeAttack);
        isInMovement = false;
    }
}
