using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] navigationButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
