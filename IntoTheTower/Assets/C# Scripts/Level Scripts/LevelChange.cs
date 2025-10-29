using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public GameObject player; //Player in scene
    public GameObject endGameScreen;
    public TextMeshProUGUI winText;

    private List<Vector2> levelCoord; // List of all levelCoords based off of what the player has chosen
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        string selectedMode = GameMode.chosenMode;
        levelCoord = new List<Vector2>();
        if (selectedMode == "Both")
        {
            CreateCoord("LevelCoordPuzzle");
            CreateCoord("LevelCoordCombat");
        }
        else if (selectedMode == "Combat")
        {
            CreateCoord("LevelCoordCombat");
        }
        else if (selectedMode == "Puzzle")
        {
            CreateCoord("LevelCoordPuzzle");

        }
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
            winText.text = "You've reached the bottom of the tower!";
            Time.timeScale = 0f;
        }
    }
}
