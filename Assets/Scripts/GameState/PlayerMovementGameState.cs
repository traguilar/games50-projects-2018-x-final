using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGameState : MonoBehaviour
{
    // References
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    private SlowMo slowMoScript;
    private PlayerStats playerStats;


    public bool isDrag = false;
    private float lineWidth = 0.05f;
    [SerializeField] private Vector3 launchDirection;
    private Rigidbody rb;

    // Tests
    public float playerForce;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        slowMoScript = GetComponent<SlowMo>();
        playerStats = GetComponent<PlayerStats>();
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    // Update is called once per frame
    void Update()
    {
        Launch();

        DragToggle();

        DrawTrajectory();

        RegenStamina();

        if (isDrag && !slowMoScript.isTweening)
        {
            slowMoScript.StartSlowMo();
        }
        else if (!isDrag && slowMoScript.isTweening)
        {
            slowMoScript.StopSlowMo();
            slowMoScript.isTweening = false;
        }
        // Debug 
        //print(Time.timeScale);

    }

    void DragToggle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }
    }

    void DrawTrajectory()
    {
        if (isDrag)
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            Plane plane = new Plane(Vector3.up, transform.position); 

            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 point = ray.GetPoint(distance);
                Vector3 direction = new Vector3(point.x - transform.position.x, 0, point.z - transform.position.z);

                // Debug 
                //Debug.DrawLine(transform.position, transform.position + direction, Color.red);
                //Debug.Log("Direction vector (X,Z): " + new Vector2(direction.x, direction.z));

                // Draw the line
                Vector3 newPoint = transform.position - direction;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, newPoint);

                // change the value of launchDirection
                launchDirection = newPoint ;
            }
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }
    }

    void Launch()
    {
        if (isDrag && Input.GetMouseButtonUp(0))
        {
            Vector3 forceDirection = (launchDirection - transform.position).normalized;
            float forceFactor = Mathf.Min((launchDirection - transform.position).magnitude, playerStats.stamina);
            Vector3 force = forceDirection * (forceFactor);
            rb.AddForce(force, ForceMode.Impulse);
            playerStats.stamina -= forceFactor;
            //print(forceFactor);

        }
    }
    

    void RegenStamina()
    {
        if (playerStats.stamina < playerStats.maxStamina)
        {
            playerStats.stamina += playerStats.staminaRegen * Time.deltaTime;
        }
        else if (playerStats.stamina > playerStats.maxStamina)
        {
            playerStats.stamina = playerStats.maxStamina;
        }
    }

}
