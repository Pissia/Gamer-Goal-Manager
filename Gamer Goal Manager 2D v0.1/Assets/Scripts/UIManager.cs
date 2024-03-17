using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] navigationButtons;
    public GameObject planningModeUI;

    public GameEvent planningModeIsOn;
    public GameEvent planningModeOff;

    private bool iconMenuIsOpen;
    public GameObject iconSelectionMenu;

    public void HideButtons()
    {
        for(int i = 0; i < navigationButtons.Length; i++)
        {
            navigationButtons[i].gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        for( int i = 0;i < navigationButtons.Length; i++)
        {
            navigationButtons[i].gameObject.SetActive(true);
        }
    }

    public void ShowPlannningModeUI()
    {
        planningModeIsOn.Raise();
        planningModeUI.SetActive(true);
    }
    public void HidePlanningModeUI()
    {
        if (!navigationButtons[0].IsActive())
        {
            ShowButtons();
        }
        planningModeOff.Raise();
        planningModeUI.SetActive(false);
    }

    public void ShowOrHideIconSelectionMenu()
    {
        if (iconMenuIsOpen)
        {
            iconMenuIsOpen = false;
            iconSelectionMenu.SetActive(false);
        }
        else
        {
            iconMenuIsOpen = true;
            iconSelectionMenu.SetActive(true);
        }
    }

    
}
