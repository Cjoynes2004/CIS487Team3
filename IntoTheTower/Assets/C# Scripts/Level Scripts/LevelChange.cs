using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public GameObject player; //Player in scene
    public GameObject endGameScreen; //Temporary, will eventually be a cutscene or some sort of different scene - TO DO

    private List<Vector2> levelCoord; // List of all levelCoords based off of what the player has chosen
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // To add if statements so it can be combat or puzzle or both - TO DO
    {
        levelCoord = new List<Vector2>();
        CreateCoord("LevelCoordCombat");
        CreateCoord("LevelCoordPuzzle");
        GetNextLevel();
    }

    //Creates Level Coordinates for given .txt file 
    private void CreateCoord(string resourceName)
    {
        TextAsset textFile = Resources.Load<TextAsset>(resourceName);
        if (textFile == null)
        {
            Debug.LogError("Missing resource file: " + resourceName);
            return;
        }

        string[] lines = textFile.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Trim().Split(',');
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            levelCoord.Add(new Vector2(x, y));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gets next level or ends game if no levels left
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
