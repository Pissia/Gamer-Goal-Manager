using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetGoal : MonoBehaviour
{
    public Button option;
    public GameObject dayBlockManager;

    public TextMeshProUGUI optionText;

    public void SetGoalToThisOption()
    {
        
        dayBlockManager.GetComponent<DayBlockManager>().SetGoal(optionText.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
