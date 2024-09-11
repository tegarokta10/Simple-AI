using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Kecepatan musuh saat mengejar pemain
    public float speed = 5f;

    // Jarak minimal musuh akan mulai mengejar pemain
    public float chaseRange = 10f;

    // Referensi ke objek pemain
    private Transform player;

    void Start()
    {
        // Cari objek dengan tag "Player" dan ambil transform-nya
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Hitung jarak antara musuh dan pemain
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Jika pemain berada dalam jangkauan pengejaran
            if (distanceToPlayer <= chaseRange)
            {
                // Arahkan musuh menuju pemain
                Vector2 direction = (player.position - transform.position).normalized;

                // Gerakkan musuh ke arah pemain dengan kecepatan yang ditentukan
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }

    // Menggambar chase range untuk visualisasi di editor Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
