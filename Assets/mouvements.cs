using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement du joueur
    public float jumpForce = 10f; // Force de saut du joueur
    public float iceMoveSpeedMultiplier = 5f; // Multiplicateur de vitesse sur la glace

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isOnIce = false;
    private SpriteRenderer spriteRenderer;

    public Transform[] respawnPoints;
    public Rigidbody2D rockRigidbody;

    private Vector3 initialRockPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        initialRockPosition = rockRigidbody.transform.position;
        rockRigidbody.gameObject.SetActive(false);
    }

    private void Update()
    {
        // G�rer les mouvements horizontaux
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
        if (isOnIce)
        {
            // Appliquer le mouvement horizontal sur la glace avec la vitesse r�duite
            rb.AddForce(Vector2.right * horizontalInput * moveSpeed * iceMoveSpeedMultiplier);
        }
        else
        {
            // Appliquer le mouvement horizontal normal
            rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        }

        // G�rer le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifier si le joueur est au sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Ice"))
        {
            isOnIce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // V�rifier si le joueur quitte le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Ice"))
        {
            isOnIce = false;
        }
    }

    public void RespawnPlayer(int respawnIndex)
    {
        // V�rifie si l'index de r�apparition est valide
        if (respawnIndex >= 0 && respawnIndex < respawnPoints.Length)
        {
            // D�place le joueur vers le point de r�apparition correspondant � l'index
            transform.position = respawnPoints[respawnIndex].position;

            // R�active le joueur
            gameObject.SetActive(true);

            rockRigidbody.transform.position = initialRockPosition;

            rockRigidbody.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid respawn index!");
        }
    }
}
