using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSelect : MonoBehaviour
{
    private Sprite icon;
    // Start is called before the first frame update
    void Start()
    {
       icon = gameObject.GetComponent<Image>().sprite;
    }

    public void SetThisIcon()
    {
        GameManager.instance.SetPlayerIconTo(icon);
    }

}
