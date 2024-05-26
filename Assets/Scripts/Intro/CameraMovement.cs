using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 firstPos;
    [SerializeField] private Vector3 secondPos;
    [SerializeField] private Vector3 thirdPos;
    [SerializeField] private Vector3 fourthPos;

    [SerializeField] private float firstPauseTime;
    [SerializeField] private float secondPauseTime;
    [SerializeField] private float thirdPauseTime;
    [SerializeField] private float fourthPauseTime;

    [SerializeField] private float travelTime12;
    [SerializeField] private float travelTime23;
    [SerializeField] private float travelTime34;

    public float totalTime;

    public List<AudioClip> clipList;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Presentation());
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the final position is set
    }

    private IEnumerator Presentation()
    {
        // Move to the first position and wait
        transform.position = firstPos;
        yield return new WaitForSeconds(1);
        audioSource.clip = clipList[0];
        audioSource.Play();
        yield return new WaitForSeconds(firstPauseTime);

        // Move to the second position
        yield return MoveToPosition(secondPos, travelTime12);
        yield return new WaitForSeconds(secondPauseTime);

        // Move to the third position
        yield return MoveToPosition(thirdPos, travelTime23);
        yield return new WaitForSeconds(thirdPauseTime);

        // Move to the fourth position
        yield return MoveToPosition(fourthPos, travelTime34);
        yield return new WaitForSeconds(fourthPauseTime);
    }
}
