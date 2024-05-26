using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticle : MonoBehaviour
{
    // Create multiple particles sprites ?
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 collisionPoint = contact.point;
            collisionPoint = new Vector3(collisionPoint.x, collisionPoint.y, collisionPoint.z - 0.5f);
            Instantiate(particle,collisionPoint,Quaternion.identity);
        }
    }
}
