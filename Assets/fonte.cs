using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fonte : MonoBehaviour
{
    public float disappearTime = 1f; // Temps avant disparition en secondes
    private bool isPlayerOnPlatform = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            Invoke("Disappear", disappearTime);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private void Disappear()
    {
        if (isPlayerOnPlatform)
        {
            // Mettez ici le code pour faire disparaître la plateforme
            gameObject.SetActive(false); // Désactiver la plateforme (ou détruire l'objet selon votre besoin)
        }
    }
}
