using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SceneManagerGameState : MonoBehaviour
{
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
