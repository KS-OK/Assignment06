using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class PlayerLives : MonoBehaviour
{

    public static int lives = 3;
    public Text lifeText;

    public GameObject player;
    public GameObject enemy;

    public Text writeScore;

    public void WriteDaScore()
    {
        string path = "Assets/scores.txt";

        writeScore.text = Score.CurrentScore.ToString();

        //get score
        string scoreToBeWritten = writeScore.text;

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(scoreToBeWritten);
        writer.Close();

        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("scores");

        Debug.Log("Done writing");
    }

    public void loseLife()
    {
        lives--;
        Debug.Log("Lives are now " + lives);
        if (lives == 0)
        {
            WriteDaScore();
            Debug.Log("GAME OVER");
            Debug.Log("Score ended up as " + Score.CurrentScore);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            lives = 3;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        string tag = col.tag;

        // Checks the tag of the triggering object
        // and compares it to the cases below.
        switch (tag)
        {
            case "Enemy":
                loseLife();
                lifeText.text = lives.ToString();
                Debug.Log("Enemy hit the player");
                player.transform.position = new Vector3(-9.3f, 0.54f, -4.94f);
                enemy.transform.position = new Vector3(8.77f, 1.53f, 9.52f);
                break;
        }
    }
}
