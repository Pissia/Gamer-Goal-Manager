using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool planingModeIsOn = false;
    public Player player;

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
