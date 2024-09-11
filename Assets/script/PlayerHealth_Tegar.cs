using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f; // Kesehatan pemain

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // Tambahkan logika kematian pemain, seperti menghentikan permainan atau memulai ulang level
        // Contoh: menghentikan permainan
        // Time.timeScale = 0;
        // atau memulai ulang level
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
