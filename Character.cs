using UnityEngine;

public class RandomCrowdAgent : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 120.0f;
    public float sensorLength = 1.0f;  // Raycast sensor length set to 1 unit
    public float changeDirectionInterval = 2.0f;

    private float changeDirectionTimer;
    private Vector3 randomDirection;

    // Material asli dan alternatif yang akan digunakan saat menabrak rintangan
    public Material originalMaterial;
    public Material alternateMaterial;

    // Status apakah material saat ini adalah material asli atau alternatif
    private bool usingOriginalMaterial = true;

    void Start()
    {
        SetRandomDirection();

        // Mengatur material awal objek ke material asli
        GetComponent<Renderer>().material = originalMaterial;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        AvoidObstacles();

        changeDirectionTimer += Time.deltaTime;
        if (changeDirectionTimer >= changeDirectionInterval)
        {
            SetRandomDirection();
            changeDirectionTimer = 0f;
        }
    }

    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward;
        transform.rotation = Quaternion.LookRotation(randomDirection);
    }

    void AvoidObstacles()
    {
        RaycastHit hit;
        Vector3 avoidanceDirection = Vector3.zero;
        bool obstacleDetected = false;

        // Forward Sensor
        if (Physics.Raycast(transform.position, transform.forward, out hit, sensorLength))
        {
            avoidanceDirection += hit.normal;
            obstacleDetected = true;
        }

        // Right Sensor
        if (Physics.Raycast(transform.position, transform.right, out hit, sensorLength))
        {
            avoidanceDirection += hit.normal;
            obstacleDetected = true;
        }

        // Left Sensor
        if (Physics.Raycast(transform.position, -transform.right, out hit, sensorLength))
        {
            avoidanceDirection += hit.normal;
            obstacleDetected = true;
        }

        // Back Sensor
        if (Physics.Raycast(transform.position, -transform.forward, out hit, sensorLength))
        {
            avoidanceDirection += hit.normal;
            obstacleDetected = true;
        }

        // Jika ada rintangan terdeteksi, agen akan berbelok menjauhi rintangan tersebut
        if (obstacleDetected)
        {
            Quaternion rotation = Quaternion.LookRotation(avoidanceDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // Ganti material saat menabrak rintangan
            ToggleMaterial();
        }
    }

    void ToggleMaterial()
    {
        // Jika saat ini menggunakan material asli, ganti dengan material alternatif
        if (usingOriginalMaterial)
        {
            GetComponent<Renderer>().material = alternateMaterial;
        }
        // Jika saat ini menggunakan material alternatif, ganti kembali ke material asli
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }

        // Membalik status penggunaan material
        usingOriginalMaterial = !usingOriginalMaterial;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * sensorLength);  // Forward
        Gizmos.DrawRay(transform.position, -transform.forward * sensorLength); // Back
        Gizmos.DrawRay(transform.position, transform.right * sensorLength);    // Right
        Gizmos.DrawRay(transform.position, -transform.right * sensorLength);   // Left
    }
}
