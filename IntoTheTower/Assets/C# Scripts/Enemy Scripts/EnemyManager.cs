using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour //Eventually make an AbstractManager to derive all managers from - TO DO
{
    public List<AbstractEnemy> enemies = new List<AbstractEnemy>(); //List of enemies in room
    public TrapdoorBehavior trapdoor;
    public Sprite openTrapdoorSprite;

    private SpriteRenderer trapdoorRender;
    private bool levelOver = false; // Turns true when room is over
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trapdoorRender = trapdoor.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame, checks if all enemies are dead
    void Update()
    {
        if (enemies.Count <= 0 && !levelOver)
        {
            for (int i = 0; i < trapdoor.openFlags.Count; i++)
            {
                if (!trapdoor.openFlags[i])
                {
                    trapdoor.openFlags[i] = true;
                    if (i == trapdoor.openFlags.Count - 1)
                    {
                        trapdoorRender.sprite = openTrapdoorSprite;
                    }
                    break;
                }
            }
            levelOver = true;
            trapdoorRender.sprite = openTrapdoorSprite;
        }
    }

    //Add enemy to list of enemies
    public void AddEnemy(AbstractEnemy enemy)
    {
        enemies.Add(enemy);
    }

    //Remove enemy from list of enemies
    public void RemoveEnemy(AbstractEnemy enemy)
    {
        enemies.Remove(enemy);
    }
}
