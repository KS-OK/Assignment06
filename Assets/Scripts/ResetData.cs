using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    private void Awake()
    {
        Score.CurrentScore = 0;
    }
}
