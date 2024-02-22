using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRockFall : MonoBehaviour
{
    public Rigidbody2D rockRigidbody; // Référence vers le Rigidbody du rocher

    private bool rockIsActive = false; // Indique si le rocher est actuellement activé

    private void Start()
    {
        // Désactive le Rigidbody du rocher au début du jeu
        rockRigidbody.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le joueur entre en collision avec l'objet invisible
        if (other.CompareTag("Player") && !rockIsActive)
        {
            // Active le Rigidbody du rocher pour le faire tomber
            rockRigidbody.isKinematic = false;


            // Marque le rocher comme activé pour éviter qu'il ne soit déclenché plusieurs fois
            rockIsActive = true;
        }
    }
}
