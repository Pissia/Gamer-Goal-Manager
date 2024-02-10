using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planingModeIsOn = false;
    public Player player;
    public MainXPSlider mainXPSlider;
    public MainXPSlider monkXPSlider;
    public MainXPSlider fighterXPSlider;
    public MainXPSlider socialXPSlider;

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
}
