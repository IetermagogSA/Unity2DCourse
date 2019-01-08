using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandiesDisplay : MonoBehaviour
{
    [SerializeField] int candies = 100;

    TextMeshProUGUI candiesDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        candiesDisplayText = GetComponent<TextMeshProUGUI>();
        UpdateCandiesDisplay();
    }

    public void UpdateCandiesDisplay()
    {
        candiesDisplayText.text = candies.ToString();
    }

    public void AddCandies(int amountToAdd)
    {
        candies += amountToAdd;
        UpdateCandiesDisplay();
    }

    public void DeceaseCandies(int amountToDecrease)
    {
        if (amountToDecrease <= candies)
        {
            candies -= amountToDecrease;
            UpdateCandiesDisplay();
        }
    }
}
