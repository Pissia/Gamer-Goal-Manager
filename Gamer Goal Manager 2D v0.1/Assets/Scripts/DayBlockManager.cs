using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayBlockManager : MonoBehaviour
{
    public GameObject chooseGoalMenu;

    public Button[] goal;

    [Header("Events")]

    public GameEvent chooseOptionsMenuIsOpen;
    public GameEvent chooseOptionsMenuIsClosed;
    public void ChooseGoalMenuSetActive()
    {
        if (chooseGoalMenu.active)
        {
            ChooseGoalMenuSetInactive();
        }
        else
        {
            chooseGoalMenu.SetActive(true);
            chooseOptionsMenuIsOpen.Raise();
        }
    }
    public void ChooseGoalMenuSetInactive()
    {
        chooseGoalMenu.SetActive(false);
        chooseOptionsMenuIsClosed.Raise();
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
