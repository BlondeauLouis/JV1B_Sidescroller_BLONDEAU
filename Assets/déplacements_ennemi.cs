using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform leftLimit; // Limite de gauche de la zone de déplacement
    public Transform rightLimit; // Limite de droite de la zone de déplacement
    public float moveSpeed = 2f; // Vitesse de déplacement des ennemis

    private bool movingRight = true; // Indique si l'ennemi se déplace vers la droite

    public int respawnIndex;

    private void Update()
    {
        // Détermine la direction du mouvement en fonction de la variable movingRight
        Vector3 direction = movingRight ? Vector3.right : Vector3.left;

        // Déplace l'ennemi dans la direction définie
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Si l'ennemi atteint la limite de droite, inverse sa direction et retourne son sprite
        if (transform.position.x >= rightLimit.position.x)
        {
            movingRight = false;
            FlipSprite();
        }
        // Si l'ennemi atteint la limite de gauche, inverse sa direction et retourne son sprite
        else if (transform.position.x <= leftLimit.position.x)
        {
            movingRight = true;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        // Inverse la direction du sprite de l'ennemi
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Envoie un message pour signaler au joueur de réapparaître
            collision.gameObject.SendMessage("RespawnPlayer", respawnIndex);
        }
    }
}
