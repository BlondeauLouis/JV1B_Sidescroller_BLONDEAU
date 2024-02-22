using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRockFall : MonoBehaviour
{
    public Rigidbody2D rockRigidbody; // R�f�rence vers le Rigidbody du rocher

    private bool rockIsActive = false; // Indique si le rocher est actuellement activ�

    private void Start()
    {
        // D�sactive le Rigidbody du rocher au d�but du jeu
        rockRigidbody.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si le joueur entre en collision avec l'objet invisible
        if (other.CompareTag("Player") && !rockIsActive)
        {
            // Active le Rigidbody du rocher pour le faire tomber
            rockRigidbody.isKinematic = false;


            // Marque le rocher comme activ� pour �viter qu'il ne soit d�clench� plusieurs fois
            rockIsActive = true;
        }
    }
}
