using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int defenderCost = 50;

    public int GetDefenderCost()
    {
        return defenderCost;
    }
}
