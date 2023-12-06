using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasergun : MonoBehaviour
{
  public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 3f;

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

        // Start a coroutine to wait for the specified interval before allowing shooting again
        StartCoroutine(ResetShootInterval());
    }

    IEnumerator ResetShootInterval()
    {
        // Wait for the specified interval
        yield return new WaitForSeconds(shootInterval);

        // Set canShoot to true, allowing shooting again
        canShoot = true;
    }
}
