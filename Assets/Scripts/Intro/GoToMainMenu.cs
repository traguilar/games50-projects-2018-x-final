using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GoToMainMenu : MonoBehaviour
{
    public bool isEnterPressed;
    public float timeToPress;
    public UnityEvent FadeIn;
    public UnityEvent FadeOut;
    private float elapsedTime;

    [SerializeField] private float timePressed;

    private CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        cameraMovement = GameObject.FindObjectOfType<CameraMovement>();
        timePressed = 0;
        isEnterPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        // Manage the key pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isEnterPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Return)) 
        { 
            isEnterPressed = false; 
        }

        if (isEnterPressed)
        {
            timePressed += Time.deltaTime;
        }
        if (timePressed > timeToPress)
        {
            // Fade In To ADD !!!!!!!!!!
            FadeIn.Invoke();
            StartCoroutine(changeScene());
        }
        if (elapsedTime > cameraMovement.totalTime)
        {
            FadeIn.Invoke();
            StartCoroutine(changeScene());
        }

        // Debug Fadeout
        if (Input.GetKeyDown(KeyCode.A))
        {
            FadeOut.Invoke();
            StartCoroutine(changeScene());
        }


    }

    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(Constants.Instance.fadeTimer);
        SceneManager.LoadScene("MainMenu");
    }
}
