using UnityEngine;

public class NPCChase : MonoBehaviour
{
    public Transform target;  // Target yang akan dikejar (NPC2)
    public float chaseSpeed = 5.0f;
    public float stopDistance = 1.0f;

    private bool isChasing = true;

    void Update()
    {
        // Periksa apakah target masih ada sebelum melanjutkan
        if (target == null)
        {
            if (isChasing)
            {
                StopChase();
            }
            return; // Keluar dari Update jika target sudah dihancurkan
        }

        if (isChasing)
        {
            // Dapatkan arah menuju target
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Gerakkan NPC1 menuju target
            transform.position += direction * chaseSpeed * Time.deltaTime;

            // Cek jarak antara NPC1 dan target
            float distance = Vector3.Distance(transform.position, target.position);

            // Jika jarak cukup dekat
            if (distance < stopDistance)
            {
                // Berhenti mengejar dan lakukan serangan
                StopChase();
                AttackTarget();
            }
        }
    }

    void StopChase()
    {
        // Logika untuk menghentikan pengejaran
        Debug.Log("Chase stopped.");
        isChasing = false;  // Set flag untuk menghentikan pengejaran
        chaseSpeed = 0f;    // Set kecepatan gerak NPC1 menjadi 0 untuk membuatnya diam
    }

    void AttackTarget()
    {
        // Logika untuk menyerang target
        Debug.Log("Attacking target!");

        // Jika NPC1 berhasil menangkap NPC2, maka NPC2 menghilang
        if (target != null)
        {
            Destroy(target.gameObject);
            Debug.Log("NPC2 caught and destroyed!");

            // Set target ke null setelah dihancurkan untuk menghindari akses lebih lanjut
            target = null;
        }
    }
}
