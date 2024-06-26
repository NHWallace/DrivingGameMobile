using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public const string HighScoreKey = "HighScore";

    private float score;

    private void Update()
    {
        score += Time.deltaTime * 5;

        scoreText.text = ((int)score).ToString();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, (int)score);
        }
    }
}
