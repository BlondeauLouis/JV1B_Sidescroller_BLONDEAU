using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement du joueur
    public float jumpForce = 10f; // Force de saut du joueur

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Gérer les mouvements horizontaux
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMove = horizontalInput * moveSpeed;

        // Inverser l'axe du sprite si le joueur va vers la gauche
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Appliquer le mouvement horizontal
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        // Gérer le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifier si le joueur est au sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Vérifier si le joueur quitte le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
