using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainXPSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI levelText;

    public void UpdateLevelProgress(float currentXp, float maxOnLevelXp)
    {
        slider.value = currentXp / maxOnLevelXp;
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }
}
