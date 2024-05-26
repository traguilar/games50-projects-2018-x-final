using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Rigidbody rb;
    private EnemyStats enemyStats;
    private SphereCollider sphereCollider;
    public GameObject halo;
    private bool isDead = false;
    public AudioClip choir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStats.health <= 0 && !isDead)
        {
            StartCoroutine(Death());
        }
        if (isDead)
        {
            rb.velocity = Vector3.up * 1;
            sphereCollider.enabled = false;
        }
    }

    private IEnumerator Death()
    {
        // Particle
        // SOund
        // Destroy or make it disappear fancier
        isDead = true;

        Instantiate(halo, transform.position, Quaternion.Euler(-90, 0, 0));
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = choir;
        audioSource.volume = 0.3f;
        audioSource.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
