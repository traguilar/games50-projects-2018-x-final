using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// To use the gameobject Fade, you have to put it in a Canvas
/// To activate a Fade, use Unity Events and Invoke this function in another script
/// That's all :)
/// </summary>
public class Fade : MonoBehaviour
{

    public float fadeTime;
    public Image image;
    private Color originalColor;
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = image.color;
        fadeTime = Constants.Instance.fadeTimer;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public IEnumerator FadeInCoroutine()
    {
        float elapsedTime = 0f;
        float startAlpha = 0f; 
        float targetAlpha = 1f;
        Color startColor = new Color(originalColor.r, originalColor.g, originalColor.b, startAlpha);
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);

        canvasGroup.blocksRaycasts = true;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeTime);
            yield return null;
        }
        image.color = targetColor;
        canvasGroup.blocksRaycasts = false;
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    public IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        float startAlpha = 1f;
        float targetAlpha = 0f;
        Color startColor = new Color(originalColor.r, originalColor.g, originalColor.b, startAlpha);
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);

        canvasGroup.blocksRaycasts = true;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeTime);
            yield return null;
        }
        image.color = targetColor;
        canvasGroup .blocksRaycasts = false;
    }


}
