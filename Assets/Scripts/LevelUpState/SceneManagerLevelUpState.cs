using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerLevelUpState : MonoBehaviour
{
    public GameObject fader;
    private Fade fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = fader.GetComponent<Fade>();
        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
