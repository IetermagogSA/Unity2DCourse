using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCandy : MonoBehaviour
{
    [SerializeField] int candyValue = 10;
    [SerializeField] float idleTime = 8f;
    [SerializeField] float collectSpeed = 1f;

    private Animator animator;
    bool moveToScore = false;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        StartCoroutine(DestroyIdleCandy());
    }

    private void Update()
    {
        if(moveToScore)
        {
            MoveToScore();
        }
    }

    public void CandyClicked()
    {
        FindObjectOfType<CandiesDisplay>().AddCandies(candyValue);

        animator.SetTrigger("clickedTrigger");

        GetComponent<AudioSource>().Play();

        moveToScore = true;
    }

    private void MoveToScore()
    {
        var movementThisFrame = collectSpeed * Time.deltaTime;

        Vector3 candyDisplayPos = FindObjectOfType<CandiesDisplay>().transform.position;

        transform.parent.position = Vector2.MoveTowards(transform.position, candyDisplayPos, collectSpeed);
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
