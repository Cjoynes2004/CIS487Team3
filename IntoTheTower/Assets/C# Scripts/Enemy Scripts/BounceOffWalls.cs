using UnityEngine;

public class BounceOffWalls : AbstractEnemy
{
    public float enemySpeed; //Set to 5 by default in Unity, bare in mind speed doubles per hit

    private Vector3 moveDirection; //Direction that enemy moves in updates
    private float enemX; //X value for moveDirection, set to random at start
    private float enemY; //Y value for moveDirection, set to random at start
    private int enemyHealth; //Health of this enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        enemX = Random.value;
        enemY = Random.value;
        moveDirection = new Vector3 (enemX, enemY, 0f);
        enemyHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Normalize();
        transform.Translate(moveDirection * enemySpeed * Time.deltaTime, Space.World);
    }

    //What enemy does on collision, damages player and reflects
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPlayer player = collision.gameObject.GetComponent<HealthPlayer>();
        if (player != null)
        {
            player.PlayerHurt(1);
        }
        moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
    }

    //Damages enemy, halves size and multiplies speed by two, once dead activates base function
    public override void DamageEnemy(int dmgAmt)
    {
        enemyHealth -= dmgAmt;
        enemySpeed *= 2;
        transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);

        if (enemyHealth <= 0)
        {
            base.DamageEnemy(dmgAmt);
        }
    }
}
