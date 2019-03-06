using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCandy : MonoBehaviour
{
    [SerializeField] int candyValue = 10;
    [SerializeField] float idleTime = 8f;
    [SerializeField] float collectSpeed = 1f;
    [SerializeField] float fallingSpeed = 1.5f;
    [SerializeField] bool fallingCandy = false;

    private Animator animator;
    bool moveToScore = false;
    Vector3 randomDropPos;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();

        if (!fallingCandy)
        {
            PlayPopupAnimation();
        }
        StartCoroutine(DestroyIdleCandy());

        randomDropPos = new Vector3(transform.position.x, Random.Range(1f, 5f));
    }

    public void PlayPopupAnimation()
    {
        animator.SetTrigger("popupTrigger");
    }

    private void Update()
    {
        if(moveToScore)
        {
            MoveToScore();
        }
        else if(fallingCandy)
        {
            Fall();
        }
    }

    private void Fall()
    {
        var movementThisFrame = fallingSpeed * Time.deltaTime;

        transform.parent.position = Vector2.MoveTowards(transform.position, randomDropPos, movementThisFrame);
    }

    public void CandyClicked()
    {
        FindObjectOfType<CandiesDisplay>().AddCandies(candyValue);

        GetComponent<BoxCollider2D>().enabled = false;

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
