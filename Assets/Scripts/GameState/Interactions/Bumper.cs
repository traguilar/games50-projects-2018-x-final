using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float bumpForce = 2f; // Coefficient pour ajuster la force de rebond
    private AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet collisionné a le tag "Player" ou "Enemy"
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            // Essayez d'obtenir le Rigidbody de l'objet collisionné
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null) // Assurez-vous que l'objet a un Rigidbody
            {
                // Obtenir la vitesse actuelle de l'objet collisionné
                Vector3 collisionVelocity = rb.velocity;

                // Obtenir le vecteur normal au point de collision
                RaycastHit hit;
                if (Physics.Raycast(other.transform.position, collisionVelocity, out hit))
                {
                    Vector3 normal = hit.normal;
                    Vector3 reflectedVelocity = Vector3.Reflect(collisionVelocity, normal);

                    // Appliquer la vitesse réfléchie avec le coefficient de bumpForce
                    rb.velocity = reflectedVelocity * bumpForce;

                    // Optionnel : Ajoutez un feedback visuel ou sonore ici
                }
            }
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}
