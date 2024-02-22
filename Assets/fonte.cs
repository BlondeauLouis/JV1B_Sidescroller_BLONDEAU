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
            // Mettez ici le code pour faire dispara�tre la plateforme
            gameObject.SetActive(false); // D�sactiver la plateforme (ou d�truire l'objet selon votre besoin)
        }
    }
}
