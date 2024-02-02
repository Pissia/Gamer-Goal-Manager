using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCategory : MonoBehaviour
{
    public GameObject chooseCategoryContainer;
    public GameObject categoryContainer;
    
    public void OpenCategory()
    {
        chooseCategoryContainer.SetActive(false);
        categoryContainer.SetActive(true);
    }
    public void CloseCategory()
    {
        chooseCategoryContainer.SetActive(true);
        categoryContainer.SetActive(false);
    }
}
