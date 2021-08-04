using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int gameScore = 0;

    private void Start()
    {
        scoreText.text = gameScore.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddPointsToScore()
    {
        gameScore += pointsPerBlock;
        scoreText.text = gameScore.ToString();

    }
}
