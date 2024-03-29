using UnityEngine;

public class CopShooter : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform target; 
    public float bulletSpeed = 10f;
    public float shootingInterval = 4f;
    private float shootingTimer;
    public float lifetime = 4f;


    private void Start()
    {
        GameObject racecar = GameObject.FindGameObjectWithTag("Player");
        if (racecar != null)
        {
            target = racecar.transform;
        }
        else
        {
            Debug.LogError("Racecar not found. Make sure your racecar is tagged correctly.");
        }
    }

    private void Update()
    {
        shootingTimer -= Time.deltaTime;

        if (shootingTimer <= 0)
        {
            Vector3 spawnPosition = transform.position + transform.up;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, transform.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.up * bulletSpeed; 

            shootingTimer = 3f;
            Destroy(bullet, lifetime);
        }
    }
}