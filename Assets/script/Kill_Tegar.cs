using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 10f; // Damage yang diberikan oleh musuh

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Periksa apakah objek yang bertabrakan adalah pemain
        if (collision.gameObject.CompareTag("Player"))
        {
            // Dapatkan komponen PlayerHealth dari pemain
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Panggil fungsi untuk mengurangi kesehatan pemain
                playerHealth.TakeDamage(damage);


            }
        }
    }
}
