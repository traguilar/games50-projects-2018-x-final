using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManagerMainMenu : MonoBehaviour
{
    public UnityEvent FadeIn;
    public UnityEvent FadeOut;
    // Start is called before the first frame update
    void Start()
    {
        FadeOut.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
