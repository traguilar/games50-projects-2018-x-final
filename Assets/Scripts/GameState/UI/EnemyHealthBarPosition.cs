using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarPosition : MonoBehaviour
{
    public Transform enemy; // L'ennemi auquel la barre de vie est attach�e
    public Vector3 offset; // Offset pour ajuster la position de la barre de vie

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (enemy != null)
        {
            // Positionne la barre de vie au-dessus de l'ennemi avec un offset
            transform.position = enemy.position + offset;

            // Faire face � la cam�ra principale
            transform.LookAt(mainCamera.transform);
        }
    }
}
