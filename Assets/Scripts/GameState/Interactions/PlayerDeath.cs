using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    private PlayerStats playerStats;
    public GameObject fader;
    private Fade fade;
    private SphereCollider sphereCollider;
    private Rigidbody rb;
    public GameObject halo;
    public AudioClip choir;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        sphereCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        fader = GameObject.Find("Fade");
        fade = fader.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.health <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        fade.FadeIn();
        StartCoroutine(DeathAnimation());
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");



    }

    private IEnumerator DeathAnimation()
    {
        sphereCollider.enabled = false;
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = choir;
        audioSource.Play();
        Instantiate(halo, transform.position, Quaternion.identity);
        rb.velocity = Vector3.up * 2;
        yield return null;

    }
}
