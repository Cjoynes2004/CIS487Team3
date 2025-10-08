using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform aim;
    public GameObject bullet;
    public float reticleDistance;
    public float bulletSpeed;

    private Vector2 mousePos;
    private Vector2 playerPos;
    private Vector2 reticlePos;
    private bool onLeftClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AimAdjust();
    }

    //Adjusts aim every frame to move reticle to where mouse is pointing
    private void AimAdjust()
    {
        playerPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - playerPos).normalized;
        reticlePos = playerPos + direction * reticleDistance;
        aim.position = reticlePos;
    }

    // Update is called once per frame
    void Update()
    {
        AimAdjust();
        ShootWeapon();
    }

    //Checks to see if player clicks mouse, if so shoots bullet
    private void ShootWeapon()
    {
        onLeftClick = Input.GetMouseButtonDown(0);
        MovePlayer move = GetComponent<MovePlayer>();
        if (onLeftClick && move.canMove)
        {
            //Create bullet at reticle
            Vector2 direction = (mousePos - playerPos).normalized;
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = reticlePos;

            //Rotate bullet to face direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0, 0, angle + 90);

            //Shoots bullet
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * bulletSpeed;
            }
        }
    }
}
