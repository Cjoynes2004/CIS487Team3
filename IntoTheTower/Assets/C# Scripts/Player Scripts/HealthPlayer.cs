using UnityEngine;

public class HealthPlayer: MonoBehaviour
{
    public GameObject healthbar; //Healthbar of player, will be replaced by parent objects
    public GameObject gameover; //gameover text, will eventaully be a canvas to restart or go to menu scene - TO DO
    public int playerHealth; //Health of the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Damages Player, replaces child heart with parent heart and erases child
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

    public void PlayerHeal(int heal)
    {
        //To be implemented - TO DO
    }
}
