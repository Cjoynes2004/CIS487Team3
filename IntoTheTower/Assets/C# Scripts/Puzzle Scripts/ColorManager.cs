using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour //Eventually make an AbstractManager to derive all managers from
{
    public List<MatchColors> colors = new List<MatchColors>();
    public LevelChange levelManager;

    private bool levelOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colors.Count == 0 && !levelOver)
        {
            levelManager.GetNextLevel();
            levelOver = true;
        }
    }

    public void AddColor(MatchColors color)
    {
        colors.Add(color);
    }

    public void RemoveColor(MatchColors color)
    {
        colors.Remove(color);
    }
}
