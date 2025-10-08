using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public GameObject healthbar;
    public GameObject gameover;
    public int playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerHurt(int dmg)
    {
        playerHealth -= dmg;
        GameObject temp = healthbar.transform.parent.gameObject;
        if (temp.CompareTag("Healthbar"))
        {
            Destroy(healthbar);
            healthbar = temp;
        }
        else if (playerHealth == 0)
        {
            MovePlayer player = gameObject.GetComponent<MovePlayer>();
            player.canMove = false;
            gameover.gameObject.SetActive(true);
        }
    }
}
