using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int Score = 0;
    public int BallNum = 3;
    public TMP_Text ScoreText;
    public bool isFinish;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        isFinish = Countdown.instance.isFinish;
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
        ScoreText.text = "skorunuz: " + Score;
    }
    public void DecreaseBall(int amount)
    {
        BallNum += amount;
        if (BallNum == 1)
            isFinish = true;

    }
}
