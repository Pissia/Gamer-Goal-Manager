using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planingModeIsOn = false;
    public Player player;
    public MainXPSlider mainXPSlider;
    public MainXPSlider monkXPSlider;
    public MainXPSlider fighterXPSlider;
    public MainXPSlider socialXPSlider;

    public TextMeshProUGUI dayNameAndDate;
    private string dayName;
    private int dayNumber;
    private int monthNumber;




    public delegate void ExpirienceCangeHandler(float mainXP, float monkXP, float fighterXP, float socialXP);
    public event ExpirienceCangeHandler OnExpirinecChange;


    //Singleton check
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void Start()
    {
        GetCurrentDate();
        if (dayNameAndDate != null)
        {
            PrintCurrentDate();
        }
        
    }

    public void Update()
    {
        UpdateXPSliders();
    }

    private void UpdateXPSliders()
    {
        mainXPSlider.UpdateLevelText(player.level);
        mainXPSlider.UpdateLevelProgress(player.currentXP, player.maxExpirienceOnLevel);
        monkXPSlider.UpdateLevelText(player.levelMonk);
        monkXPSlider.UpdateLevelProgress(player.currentXPMonk, player.maxExpirienceOnLevelMonk);
        fighterXPSlider.UpdateLevelText(player.levelFighter);
        fighterXPSlider.UpdateLevelProgress(player.currentXPFighter, player.maxExpirienceOnLevelFighter);
        socialXPSlider.UpdateLevelText(player.levelSocial);
        socialXPSlider.UpdateLevelProgress(player.currentXPSocial, player.maxExpirienceOnLevelSocial);
    }

    public void AddExpirience(float mainXP, float monkXP, float fighterXP, float socialXP)
    {
        OnExpirinecChange?.Invoke(mainXP, monkXP, fighterXP, socialXP);
    }
    public void TurnOnPlanningMode()
    {
        planingModeIsOn = true;
    }
    public void TurnOffPlanningMode()
    {
        planingModeIsOn = false;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.playerName = data.playerName;
        player.level = data.level;
        player.currentXP = data.currentXP;
    }

    private void GetCurrentDate()
    {
        dayName = DateTime.Now.DayOfWeek.ToString();
        dayNumber = DateTime.Now.Day;
        monthNumber = DateTime.Now.Month;
    }

    private void PrintCurrentDate()
    {
        dayNameAndDate.text = dayName + " " + dayNumber + "/" + monthNumber;
    }
}
