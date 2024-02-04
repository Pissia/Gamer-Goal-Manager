using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsScript : MonoBehaviour
{
    private Image goalDoneImage;
    public bool isActive;
    public DayBlockManager dayBlockManager;

    private void Start()
    {
        goalDoneImage = transform.Find("Goal Done Image").GetComponent<Image>();
        isActive = true;
    }

    public void GoalIsDone()
    {
        if (!GameManager.instance.planingModeIsOn)
        {
            gameObject.GetComponent<Button>().interactable = false;
            goalDoneImage.gameObject.SetActive(true);
            isActive = false;
        }else
        {
           ResetGoal();
            gameObject.SetActive(false); 
           dayBlockManager.RearrangeGoals();
        }
        
    }

    public void ResetGoal()
    {
        gameObject.GetComponent<Button>().interactable = true;
        goalDoneImage.gameObject.SetActive(false);
    }
}
