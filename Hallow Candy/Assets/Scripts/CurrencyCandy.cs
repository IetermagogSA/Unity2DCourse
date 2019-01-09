using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCandy : MonoBehaviour
{
    [SerializeField] int candyValue = 10;
    [SerializeField] float idleTime = 10f;

    private void Awake()
    {
        StartCoroutine(DestroyIdleCandy());
    }

    public void CandyClicked()
    {
        FindObjectOfType<CandiesDisplay>().AddCandies(candyValue);
        Destroy(transform.parent.gameObject);
    }

    IEnumerator DestroyIdleCandy()
    {
        yield return new WaitForSeconds(idleTime);
        Destroy(transform.parent.gameObject);

    }
}
