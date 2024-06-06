using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingRange = 15f;
    public float bulletSpeed = 20f;
    private Transform player;
    public float initialShootingInterval = 2f; // initial shooting interval in seconds
    public float decreaseFactor = 0.1f; // the factor by which the shooting interval decreases after each shot
    private float currentShootingInterval;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        currentShootingInterval = initialShootingInterval;
        StartCoroutine(ShootingRoutine());
    }

    IEnumerator ShootingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentShootingInterval);
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= shootingRange)
            {
                Shoot();
                currentShootingInterval = Mathf.Max(0.1f, currentShootingInterval - decreaseFactor); // ensure the interval doesn't go below 0.1 seconds
            }
        }
    }

   void Shoot()
{
    // Calculate the direction towards the player
    Vector2 direction = (player.position - transform.position).normalized;

    // Calculate the two offset directions
    Vector2 direction1 = Quaternion.Euler(0, 0, 10) * direction; // rotate 10 degrees clockwise
    Vector2 direction2 = Quaternion.Euler(0, 0, -10) * direction; // rotate 10 degrees counter-clockwise

    // Instantiate the first bullet and set its velocity
    GameObject bullet1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    bullet1.GetComponent<Rigidbody2D>().velocity = direction1 * bulletSpeed;

    // Instantiate the second bullet and set its velocity
    GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    bullet2.GetComponent<Rigidbody2D>().velocity = direction2 * bulletSpeed;
}
}