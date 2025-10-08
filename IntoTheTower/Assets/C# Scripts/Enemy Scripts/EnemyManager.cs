using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour //Eventually make an AbstractManager to derive all managers from
{
    public List<AbstractEnemy> enemies = new List<AbstractEnemy>();
    public LevelChange levelManager;

    private bool levelOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0 && !levelOver)
        {
            levelManager.GetNextLevel();
            levelOver = true;
        }
    }

    public void AddEnemy(AbstractEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(AbstractEnemy enemy)
    {
        enemies.Remove(enemy);
    }
}
