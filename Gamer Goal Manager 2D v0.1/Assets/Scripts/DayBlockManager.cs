using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayBlockManager : MonoBehaviour
{
    public GameObject chooseGoalMenu;

    public Button[] goal;
  
    public void ChooseGoalMenuSetActive()
    {
        if (chooseGoalMenu.active)
        {
            chooseGoalMenu.SetActive(false);
        } else chooseGoalMenu.SetActive(true);
    }
    public void ChooseGoalMenuSetInactive()
    {
        chooseGoalMenu.SetActive(false);
    }

    public void SetGoal(string goalName)
    {
        for(int i = 0; i < goal.Length; i++)
        {
            if (goal[i].isActiveAndEnabled == false)
            {
                goal[i].gameObject.SetActive(true);
                goal[i].GetComponentInChildren<TextMeshProUGUI>().text = goalName;

                break;
            }
        }
    }

}
