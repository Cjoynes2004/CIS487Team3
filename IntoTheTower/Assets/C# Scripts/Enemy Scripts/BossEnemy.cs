using System.Collections;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed, spawnRadius;
    [SerializeField]
    private int timeDelay, min, max, bulletCount;
    [SerializeField]
    private GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeDelay = Random.Range(min, max);
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            // Loop for each bullet
            for (int i = 0; i < bulletCount; i++)
            {
                // Calculate angle around circle
                float angle = i * Mathf.PI * 2f / bulletCount;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // Create the bullet
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = transform.position + (Vector3)direction * spawnRadius;

                // Get Rigidbody2D
                Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

                // Rotate bullet to face outward
                float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                rb.rotation = rotZ;

                // Launch it outward
                rb.linearVelocity = direction * bulletSpeed;
            }
            yield return new WaitForSeconds(timeDelay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
