using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCandy : MonoBehaviour
{
    [SerializeField] int candyValue = 10;
    [SerializeField] float idleTime = 8f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
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
        animator.SetTrigger("expiredTrigger");

        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(transform.parent.gameObject);
    }
}
