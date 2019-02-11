using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defender;
    [SerializeField] GameObject bloodySelector;

    DefenderSpawner defenderSpawner;

    CandiesDisplay candiesDisplay;

    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        candiesDisplay = FindObjectOfType<CandiesDisplay>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void Start()
    {
        LabelDefenderCost();
    }

    private void LabelDefenderCost()
    {
        TextMeshProUGUI defenderCostText = GetComponentInChildren<TextMeshProUGUI>();
        if(defenderCostText)
        {
            defenderCostText.text = defender.GetDefenderCost().ToString();
        }
        else
        {
            Debug.LogError("You have not set a cost label for " + name);
        }
    }
    private void Update()
    {
        if(candiesDisplay.GetCandiesToSpend() >= defender.GetDefenderCost())
        {
            sprite.color = Color.white;
        }
        else
        {
            sprite.color = Color.grey;
        }
    }
    private void OnMouseDown()
    {
        if (candiesDisplay.GetCandiesToSpend() >= defender.GetDefenderCost())
        {
            DeselectDefenderButtons();
            bloodySelector.SetActive(true);
            defenderSpawner.SetSelectedDefender(defender);
        }
    }

    public void DeselectDefender()
    {
        sprite.color = Color.grey;
    }

    private void DeselectDefenderButton()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("BloodyDefenderSelector");
        if (obj)
        {
            obj.SetActive(false);
        }
    }

    public void DeselectDefenderButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("BloodyDefenderSelector");
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
