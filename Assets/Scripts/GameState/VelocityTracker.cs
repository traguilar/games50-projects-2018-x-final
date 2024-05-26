using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    private Rigidbody rb;
    public List<Vector3> velocityList;
    public int listSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocityList = new List<Vector3>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocityList.Add(rb.velocity);
        if (velocityList.Count > listSize )
        {
            velocityList.RemoveAt(0);
        }

    }

    public void Debugg()
    {
        Debug.Log("Velocity History:");
        foreach (Vector3 velocity in velocityList)
        {
            Debug.Log(velocity);
        }
    }
}
