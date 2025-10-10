using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    //Damages enemy on collisin and erases bullet regardless
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AbstractEnemy enemy = collision.gameObject.GetComponent<AbstractEnemy>();
        if (enemy)
        {
            enemy.DamageEnemy(1);
        }
        Destroy(gameObject);
    }
}
