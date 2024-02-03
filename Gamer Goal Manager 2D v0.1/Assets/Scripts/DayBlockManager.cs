using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayBlockManager : MonoBehaviour
{
    public GameObject chooseGoalMenu;

    public Button[] goals;
    private List<GameObject> activeGoals = new List<GameObject>();

    [Header("Events")]

    public GameEvent chooseOptionsMenuIsOpen;
    public GameEvent chooseOptionsMenuIsClosed;
    public void ChooseGoalMenuSetActive()
    {
        if (chooseGoalMenu.activeSelf)
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
        for(int i = 0; i < goals.Length; i++)
        {
            if (goals[i].isActiveAndEnabled == false)
            {
                goals[i].gameObject.SetActive(true);
                goals[i].GetComponentInChildren<TextMeshProUGUI>().text = goalName;
                activeGoals.Add(goals[i].gameObject);

                break;
            }
        }
    }

    public void ResetGoals()
    {
        
        Debug.Log("active goals in list" + activeGoals.Count);
        
        if (activeGoals.Any())
        {
            foreach (GameObject goal in activeGoals)
            {
                goal.GetComponent<GoalsScript>().ResetGoal();
                goal.SetActive(false);
            }            
        }
        activeGoals.Clear();
        Debug.Log("active goals in list" + activeGoals.Count);
    }




}
