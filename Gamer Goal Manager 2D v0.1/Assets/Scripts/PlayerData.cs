using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public float currentXP;

    public int levelMonk;
    public float currentXPMonk;
    public float maxExpirienceOnLevelMonk;

    public int levelFighter;
    public float currentXPFighter;
    public float maxExpirienceOnLevelFighter;

    public int levelSocial;
    public float currentXPSocial;
    public float maxExpirienceOnLevelSocial;

    public string dayName;
    public int dayNumber;
    public int monthNumber;

    public PlayerData (Player player)

    {
        playerName = player.playerName;
        level = player.level;
        currentXP = player.currentXP;

    }
}
