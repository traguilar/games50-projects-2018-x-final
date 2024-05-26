using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Fade fade;
    public TextMeshProUGUI gameOverText;
    public GameObject buttons;
    private AudioSource audioSource;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        StartCoroutine(GameOverCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GameOverCoroutine()
    {
        fade.FadeOut();
        // SOunds
        audioSource.clip = gameOverSound;
        audioSource.Play();
        // Game Over text
        gameOverText.gameObject.SetActive(true);
        yield return 2.0f;
        // When over Make appear a Button to restart
        buttons.gameObject.SetActive(true);
        // Pressing the button make the game go to the main title

    }

    public void Replay()
    {

        StartCoroutine(ReplayCoroutine());  
    }
    public IEnumerator ReplayCoroutine()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1.5f);
        GameObject constants = GameObject.Find("Constants");
        PersistentDatas persistentDatas = constants.GetComponent<PersistentDatas>();
        persistentDatas.RestartParameters();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


}
