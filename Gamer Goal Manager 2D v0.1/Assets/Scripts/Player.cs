using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;

    public int level;
    public float currentXP;
    public float maxExpirienceOnLevel;

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

    private void OnEnable()
    {
        //Subscribe on event
        GameManager.instance.OnExpirinecChange += HandleExpirienceChange;
    }

    private void OnDisable()
    {
        //Unsubscribe from event
        GameManager.instance.OnExpirinecChange -= HandleExpirienceChange;
    }

    private void HandleExpirienceChange(float addXPMain, float addXPMonk, float addXPFighter, float addXPSocial)
    {
        currentXP += addXPMain;
        if (currentXP >= maxExpirienceOnLevel)
        {
            LevelUp();
        }
        currentXPMonk += addXPMonk;
        if (currentXPMonk >= maxExpirienceOnLevelMonk)
        {
            LevelUpMonk();
        }
        currentXPFighter += addXPFighter;
        if (currentXPFighter >= maxExpirienceOnLevelFighter)
        {
            LevelUpFighter();
        }
        currentXPSocial += addXPSocial;
        if (currentXPSocial >= maxExpirienceOnLevelSocial)
        {
            LevelUpSocial();
        }
    }

    private void LevelUp()
    {
        level++;
        currentXP = 0;
        maxExpirienceOnLevel += 100;
    }

    private void LevelUpMonk()
    {
        levelMonk++;
        currentXPMonk = 0;
        maxExpirienceOnLevelMonk += 100;
    }

    private void LevelUpFighter()
    {
        levelFighter++;
        currentXPFighter = 0;
        maxExpirienceOnLevelFighter += 100;
    }

    private void LevelUpSocial()
    {
        levelSocial++;
        currentXPSocial = 0;
        maxExpirienceOnLevelSocial += 100;
    }
}
