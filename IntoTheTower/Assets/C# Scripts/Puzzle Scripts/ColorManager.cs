using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour //Eventually make an AbstractManager to derive all managers from
{
    public List<MatchColors> colors = new List<MatchColors>(); //List of colors that will be matched
    public TrapdoorBehavior trapdoor; //Trapdoor for this room

    private bool levelOver = false; // Returns true when room is over.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colors.Count == 0 && !levelOver)
        {
            trapdoor.isOpen = true;
            levelOver = true;
        }
    }

    //Adds color to list
    public void AddColor(MatchColors color)
    {
        colors.Add(color);
    }

    //Removes color from list
    public void RemoveColor(MatchColors color)
    {
        colors.Remove(color);
    }
}
