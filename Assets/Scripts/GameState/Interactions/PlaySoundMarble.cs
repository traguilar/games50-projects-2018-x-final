using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundMarble : MonoBehaviour
{
    private GameObject soundManager;
    private SucySounds sucySounds;
    private AudioSource sucySource;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager");
        sucySounds = soundManager.GetComponent<SucySounds>();
        sucySource = soundManager.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        if (collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Player"))
        {
            int randomSound = Random.Range(0, sucySounds.sounds.Count);
            sucySource.clip = sucySounds.sounds[randomSound];
            sucySource.Play();
        }


    }
}
