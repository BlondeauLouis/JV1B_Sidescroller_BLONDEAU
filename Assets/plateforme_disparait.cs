using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearTime = 1f; // Temps avant disparition en secondes
    public float fallSpeed = 5f; // Vitesse de chute de la plateforme

    private Rigidbody2D rb;
    private bool isPlayerOnPlatform = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static; // Désactiver la physique au début pour que la plateforme ne tombe pas immédiatement
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            Invoke("StartFalling", disappearTime); // Démarrer la chute après le délai de disparition
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private void StartFalling()
    {
        if (isPlayerOnPlatform)
        {
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic; // Activer la physique pour permettre à la plateforme de tomber
                rb.gravityScale = fallSpeed; // Appliquer la vitesse de chute
            }

            Invoke("Disappear", 1f); // Ajouter un délai avant la disparition si nécessaire
        }
    }

    private void Disappear()
    {
        // Ajoutez ici le code pour faire disparaître la plateforme
        gameObject.SetActive(false); // Ou tout autre effet visuel de votre choix
    }
}
