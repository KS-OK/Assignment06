using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class CreateCoins : MonoBehaviour
{
    public GameObject newCoin;
    private bool canceled = false;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // create new coins with delay of 2 seconds repeating every 1 second using the SpawnCoin method
        //Invoke("SpawnCoin", 1);    
    }

    void SpawnCoin()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = 1.0f; // start at height 1
        float z = Random.Range(-10.0f, 10.0f);
        Instantiate(newCoin, new Vector3(x, y, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.CurrentScore.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canceled)
            {
                CancelInvoke();
                canceled = true;
            }
            else
            {
                Invoke("SpawnCoin", 1);
                canceled = false;
            }
        }
    }

    public static void scoreCount()
    {
        //score++;
        Score.CurrentScore += 100;
        Debug.Log("Score is now " + Score.CurrentScore);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("Collision occurred");
        scoreCount();
        SpawnCoin();
    }
}
