using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] float offSet = 0.25f;

    Defender defender;
    public Defender mouseDefender;
    CandiesDisplay candiesDisplay;

    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        candiesDisplay = FindObjectOfType<CandiesDisplay>();

        CreateDefendersParent();
    }

    private void Update()
    {
        if(mouseDefender)
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            mouseDefender.transform.position = worldPos;
        }
    }

    private void CreateDefendersParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;

        SpawnDefenderToFollowMouse();
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y) - offSet; // 0.25f is a small offset so that it looks good

        return worldPos;
    }

    public void SpawnDefenderToFollowMouse()
    {
        if (defender)
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x + 2f, Input.mousePosition.y + 2f);
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            mouseDefender = Instantiate(defender, worldPos, transform.rotation) as Defender;

            mouseDefender.gameObject.layer = 0;

            // Disable some unwanted behaviour
            mouseDefender.GetComponent<Animator>().enabled = false;
            if (mouseDefender.GetComponent<Shooter>())
            {
                mouseDefender.GetComponent<Shooter>().enabled = false;
            }

            var boxColliders = mouseDefender.GetComponentsInChildren<BoxCollider2D>();
            foreach(var boxCollider in boxColliders)
            {
                boxCollider.enabled = false;
            }

            var spriteRenderers = mouseDefender.GetComponentsInChildren<SpriteRenderer>();
            foreach(var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.sortingLayerName = "MouseDefender";
            }
                
        }
    }

    public void SpawnDefender()
    {
        if (defender)
        {
            candiesDisplay.DeceaseCandies(defender.GetDefenderCost());
            Defender myDefender = Instantiate(defender, GetSquareClicked(), transform.rotation) as Defender;
            myDefender.transform.parent = defenderParent.transform;
            defender = null;

            GameObject.Destroy(mouseDefender.gameObject);
        }
    }
}
