using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptMass : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = transform.localScale.x * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
