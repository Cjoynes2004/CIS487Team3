using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform aim;   //Position of the aiming reticle as Unity Object
    public GameObject bullet;   //bullet that player shoots
    public float reticleDistance;   //distance of reticle from player
    public float bulletSpeed;   //Speed of the player
    public SoundManager sfx;    //Sound effect of the bullet when shot

    private Vector2 mousePos;   //Position of mouse on screen
    private Vector2 playerPos;  //Player's position
    private Vector2 reticlePos; //Position of the reticle in code
    private bool onLeftClick; //Is true when player clicks mouse
    // Start is called once before the first execution of Update after the MonoBehaviour is created, adjusts aim
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
            sfx.PlaySound();
        }
    }
}
