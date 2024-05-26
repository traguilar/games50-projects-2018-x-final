using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalVictory : MonoBehaviour
{
    public TextMeshProUGUI text;
    private RectTransform rectTransform;
    private GameObject canvas;
    public float scrollSpeed;
    public float timeBeforeQuit;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = text.GetComponent<RectTransform>();
        StartCoroutine(Quit()); 
    }

    // Update is called once per frame
    void Update()
    {

        rectTransform.position += Vector3.up * Time.deltaTime * scrollSpeed;

    }

    private IEnumerator Quit()
    {
        yield return new WaitForSeconds(timeBeforeQuit);
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
