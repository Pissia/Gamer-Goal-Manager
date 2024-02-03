using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsScript : MonoBehaviour
{
    private Image goalDoneImage;
    public bool isActive;

    private void Start()
    {
        goalDoneImage = transform.Find("Goal Done Image").GetComponent<Image>();
        isActive = true;
    }

    public void GoalIsDone()
    {
        gameObject.GetComponent<Button>().interactable = false;
        goalDoneImage.gameObject.SetActive(true);
        isActive = false;
    }

    public void ResetGoal()
    {
        gameObject.GetComponent<Button>().interactable = true;
        goalDoneImage.gameObject.SetActive(false);
    }
}
