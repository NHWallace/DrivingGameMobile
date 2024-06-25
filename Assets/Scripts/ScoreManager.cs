using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private float score;

    private void Update()
    {
        score += Time.deltaTime * 5;

        scoreText.text = ((int)score).ToString();
    }
}
