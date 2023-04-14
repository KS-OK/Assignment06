using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

public class ReadScores : MonoBehaviour
{
    [SerializeField] Text txt_allscores;

    string[] scoreArray = new string[10];
    string myFilePath, fileName;

    int i;

    void Start()
    {
        fileName = "scores.txt";
        myFilePath = Application.dataPath + "/" + fileName;
        ReadFromTheFile();
    }

    void DisplayAllScores()
    {
        System.Array.Sort(scoreArray);
        Array.Reverse(scoreArray);
        foreach (string line in scoreArray)
        {
            txt_allscores.text += line + "\n";
        }

    }

    public void ReadFromTheFile()
    {
        scoreArray = File.ReadAllLines(myFilePath);
        DisplayAllScores();
    }
}
