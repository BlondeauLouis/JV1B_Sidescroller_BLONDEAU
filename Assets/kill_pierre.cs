using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_pierre : MonoBehaviour
{
    public int respawnIndex;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Envoie un message pour signaler au joueur de réapparaître
            collision.gameObject.SendMessage("RespawnPlayer", respawnIndex);
        }
    }
}