using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planingModeIsOn = false;
    public Player player;
    public MainXPSlider mainXPSlider;

    public delegate void ExpirienceCangeHandler(float amount);
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
        mainXPSlider.UpdateLevelText(player.level);
        mainXPSlider.UpdateLevelProgress(player.currentXP, player.maxExpirienceOnLevel);
    }

    public void AddExpirience(float amount)
    {
        OnExpirinecChange?.Invoke(amount);
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
