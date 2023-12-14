using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class astroidstart : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float minShootInterval = 2f;
    public float maxShootInterval = 5f;

    private bool canShoot = true;

    void Update()
    {
        // Check for input (e.g., spacebar) and trigger shooting
        if (canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate bullet at the fire point position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set canShoot to false to prevent shooting until the next interval
        canShoot = false;

        // Start a coroutine to wait for a random interval before allowing shooting again
        StartCoroutine(ResetShootInterval());
    }

    IEnumerator ResetShootInterval()
    {
        // Wait for a random interval between min and max
        float randomInterval = Random.Range(minShootInterval, maxShootInterval);
        yield return new WaitForSeconds(randomInterval);

        // Set canShoot to true, allowing shooting again
        canShoot = true;
    }
}
