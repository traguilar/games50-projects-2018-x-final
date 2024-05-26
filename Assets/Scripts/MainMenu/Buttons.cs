using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Buttons : MonoBehaviour
{
    public UnityEvent FadeIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        // Fade
        StartCoroutine(GoToPlay());
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public IEnumerator GoToPlay()
    {
        FadeIn.Invoke();
        yield return new WaitForSeconds(Constants.Instance.fadeTimer);
        SceneManager.LoadScene("GameState");
    }
}
