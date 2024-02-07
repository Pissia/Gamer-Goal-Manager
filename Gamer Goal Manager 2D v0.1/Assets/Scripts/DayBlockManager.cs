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

    public GameObject addGoalButton;
    public GameObject resetGoalsButton;
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

    public void SetGoal(string goalName, float goalExpValue)
    {
        for(int i = 0; i < goals.Length; i++)
        {
            if (goals[i].isActiveAndEnabled == false)
            {
                goals[i].gameObject.SetActive(true);
                goals[i].GetComponentInChildren<TextMeshProUGUI>().text = goalName;
                goals[i].GetComponent<GoalsScript>().expAmount = goalExpValue;
                activeGoals.Add(goals[i].gameObject);

                break;
            }
        }
    }

    public void ClearGoals()
    {       
        if (activeGoals.Any())
        {
            foreach (GameObject goal in activeGoals)
            {
                goal.GetComponent<GoalsScript>().ResetGoal();
                goal.SetActive(false);
            }            
        }
        activeGoals.Clear();
    }

    public void ResetGoals()
    {
        if (activeGoals.Any())
        {
            foreach (GameObject goal in activeGoals)
            {
                goal.GetComponent<GoalsScript>().ResetGoal();
            }
        }
    }

    public void EnterPlanningMode()
    {
        addGoalButton.SetActive(true);
        resetGoalsButton.SetActive(true);
        if(activeGoals != null)
        {
            ResetGoals();
        }
        
    }
    public void HideButtons()
    {
        addGoalButton.SetActive(false);
        resetGoalsButton.SetActive(false);
    }

    private void Start()
    {
        HideButtons();
    }

    //Rearranging goals in planning mode
    public void RearrangeGoals()
    {
        
        
        for(int i = 0; i < goals.Length; i++)
        {
            if(i == goals.Length && !goals[i].IsActive())
            {
                goals[i].gameObject.SetActive(false);
                activeGoals.Remove(goals[i].gameObject);
                break;
            }
            if(i < goals.Length-1 && !goals[i].IsActive() && !goals[i + 1].IsActive())
            {
                break;
            }
            if (!goals[i].IsActive() && i != goals.Length-1 && goals[i+1] !=null)
            {
                goals[i].GetComponentInChildren<TextMeshProUGUI>().text = goals[i + 1].GetComponentInChildren<TextMeshProUGUI>().text;
                goals[i].gameObject.SetActive(true);
                goals[i + 1].gameObject.SetActive(false);
                activeGoals.Remove(goals[i + 1].gameObject);

                if(i < goals.Length - 2)
                {
                    if (goals[i + 2] != null && !goals[i + 2].IsActive())
                    {
                        break;
                    }
                }
               
               // Debug.Log(goals.Length);
            }
         
        }
    }

}
