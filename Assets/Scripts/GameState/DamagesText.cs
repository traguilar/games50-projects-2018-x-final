using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagesText : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(float damage, Vector3 position, string target)
    {
        textMeshPro = GetComponent<TextMeshPro>();

        textMeshPro.text = damage.ToString();
        if (target == "Player")
        {
            textMeshPro.color = Color.red;
        }
        else
        {
            textMeshPro.color = Color.white;
        }
        transform.position = position;

        // Gravity and fancy stuff ?
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-2, 2), Random.Range(3, 8),Random.Range(-3,-2));
        //Instantiate(gameObject, transform.position, Quaternion.identity);
        Destroy(gameObject, 2f);
    }
}
