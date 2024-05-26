using UnityEngine;

public class SlowMo : MonoBehaviour
{
    public float targetTimeScale;
    public float tweenDuration = 1f;

    private float initTimeScale;
    private float elapsedTime = 0f;

    public bool isTweening = false;

    // Stripes
    private RectTransform topPanel;
    private RectTransform bottomPanel;
    private float topPanelOriginalPosition;
    private float bottomPanelOriginalPosition;
    [SerializeField] private float panelDeltaY;
    private float topPanelTargetPosition;
    private float bottomPanelTargetPosition;


    void Start()
    {
        panelDeltaY = 100f;
        topPanel = GameObject.Find("TopStripe").GetComponent<RectTransform>();
        bottomPanel = GameObject.Find("BotStripe").GetComponent<RectTransform>();
        initTimeScale = Time.timeScale;
        topPanelOriginalPosition = topPanel.position.y;
        bottomPanelOriginalPosition = bottomPanel.position.y;
        topPanelTargetPosition = topPanelOriginalPosition - panelDeltaY;
        bottomPanelTargetPosition = bottomPanelOriginalPosition + panelDeltaY;
    }

    void Update()
    {
        if (isTweening)
        {
            // Increment time elapsed
            elapsedTime += Time.unscaledDeltaTime;

            // Calculate the new interpolate timescale
            float newTimeScale = Mathf.Lerp(initTimeScale, targetTimeScale, elapsedTime / tweenDuration);

            // Calculate the new panelPositions
            float newTopPanelPosition = Mathf.Lerp(topPanelOriginalPosition, topPanelTargetPosition, elapsedTime / tweenDuration);
            float newBottomPanelPosition = Mathf.Lerp(bottomPanelOriginalPosition, bottomPanelTargetPosition, elapsedTime / tweenDuration);
            

            // Apply it
            Time.timeScale = newTimeScale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            // Comment changer la position des panels ?
            topPanel.position = new Vector3(topPanel.position.x, newTopPanelPosition, topPanel.position.z);
            bottomPanel.position = new Vector3(bottomPanel.position.x, newBottomPanelPosition, bottomPanel.position.z);

            // Check if tween ends
            if (elapsedTime >= tweenDuration)
            {
                Time.timeScale = targetTimeScale; // Set the timescale to the targeted one

                topPanel.position = new Vector3(topPanel.position.x, topPanelTargetPosition, topPanel.position.z);
                bottomPanel.position = new Vector3(bottomPanel.position.x, bottomPanelTargetPosition, bottomPanel.position.z);
            }
        }
        else
        {
            topPanel.position = new Vector3(topPanel.position.x, topPanelOriginalPosition, topPanel.position.z);
            bottomPanel.position = new Vector3(bottomPanel.position.x, bottomPanelOriginalPosition, bottomPanel.position.z);
        }



    }

    public void StartSlowMo()
    {
        elapsedTime = 0f; // Réinitialiser le temps écoulé
        isTweening = true; // Définir le booléen de tweening à true
    }
    public void StopSlowMo()
    {
        Time.timeScale = initTimeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
