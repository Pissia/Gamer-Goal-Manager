using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public float currentXP;

    public PlayerData (Player player)
    {
        playerName = player.playerName;
        level = player.level;
        currentXP = player.currentXP;

    }
}
