using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private Button playButton;
    [SerializeField] private NotificationManager notificationManager;
    [SerializeField] private int maxEnergy;
    [SerializeField] private float energyRechargeTime;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        OnApplicationFocus(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) { return; }
        CancelInvoke(nameof(EnergyRecharged));


        int highScore = PlayerPrefs.GetInt(ScoreManager.HighScoreKey, 0);
        highScoreText.text = $"High Score: {highScore}";

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if(energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if (energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if ( DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
            else
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);
            }
        }

        energyText.text = $"Play ({energy})";
    }

    private void EnergyRecharged()
    {
        energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text = $"Play ({energy})";
        playButton.interactable = true;
    }

    public void Play()
    {
        if (energy <= 0) { return; }

        if (energy == maxEnergy)
        {
            DateTime energyReadyTime = DateTime.Now.AddMinutes(energyRechargeTime);
            PlayerPrefs.SetString(EnergyReadyKey, energyReadyTime.ToString());
            #if UNITY_ANDROID
            notificationManager.ScheduleNotification(energyReadyTime);
            #endif
        }
        energy--;
        PlayerPrefs.SetInt(EnergyKey, energy);

        SceneManager.LoadScene(1);
    }
}
