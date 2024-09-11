using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Objek yang akan diikuti oleh kamera, dapat diatur melalui inspector
    public Transform target;

    // Offset untuk menyesuaikan posisi kamera terhadap objek
    public Vector3 offset;

    // Kecepatan kamera saat mengikuti objek
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        if (target != null)
        {
            // Tentukan posisi yang diinginkan oleh kamera dengan offset
            Vector3 desiredPosition = target.position + offset;

            // Haluskan perpindahan kamera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Terapkan posisi baru ke kamera
            transform.position = smoothedPosition;
        }
    }
}
