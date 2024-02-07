using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public int level;
    public float currentXP;
    public float maxExpirienceOnLevel;

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

    private void HandleExpirienceChange(float addedExpirience)
    {
        currentXP += addedExpirience;
        if (currentXP >= maxExpirienceOnLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        currentXP = 0;
        maxExpirienceOnLevel += 100;
    }
}
