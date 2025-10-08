using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public GameObject player;
    public GameObject endGameScreen;

    private List<Vector2> levelCoord;

    private string combatPath = "Assets/Resources/LevelCoordCombat.txt";
    private string puzzlePath = "Assets/Resources/LevelCoordPuzzle.txt";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelCoord = new List<Vector2>();
        CreateCoord(combatPath);
        CreateCoord(puzzlePath);
        GetNextLevel();
    }

    private void CreateCoord(string filePath)
    {
        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(',');
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            levelCoord.Add(new Vector2(x, y));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNextLevel()
    {
        if (levelCoord.Count > 0)
        {
            int rand = UnityEngine.Random.Range(0, levelCoord.Count);
            Vector2 newPos = levelCoord[rand];
            player.transform.position = newPos;
            levelCoord.RemoveAt(rand);
        }
        else
        {
            endGameScreen.SetActive(true);
            MovePlayer move = player.GetComponent<MovePlayer>();
            move.canMove = false;
        }
    }
}
