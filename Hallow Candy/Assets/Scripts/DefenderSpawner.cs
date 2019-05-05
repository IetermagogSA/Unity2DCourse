using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] float offSet = 0.25f;

    public Defender defender;
    CandiesDisplay candiesDisplay;

    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        candiesDisplay = FindObjectOfType<CandiesDisplay>();

        //CreateDefendersParent();
    }

    private void CreateDefendersParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
            defenderParent.transform.position = new Vector2(0.2f, 0f);
        }
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    public Defender GetSelectedDefender()
    {
        return defender;
    }

    public void ResetSelectedDefender()
    {
        defender = null;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y) - offSet; // 0.25f is a small offset so that it looks good

        //worldPos.x = 1;
        //worldPos.y = 0.7f;

        return worldPos;
    }

    //public void SpawnDefenderToFollowMouse()
    //{
    //    if (defender)
    //    {
    //        Vector2 mousePos = new Vector2(Input.mousePosition.x + 2f, Input.mousePosition.y + 2f);
    //        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

    //        mouseDefender = Instantiate(defender, worldPos, transform.rotation) as Defender;

    //        mouseDefender.gameObject.layer = 0;

    //        // Disable some unwanted behaviour
    //        if (defender.GetDefenderCost() > 0)
    //        {
    //            mouseDefender.GetComponent<Animator>().enabled = false;
    //            if (mouseDefender.GetComponent<Shooter>())
    //            {
    //                mouseDefender.GetComponent<Shooter>().enabled = false;
    //            }
    //        }

    //        var boxColliders = mouseDefender.GetComponentsInChildren<BoxCollider2D>();
    //        foreach(var boxCollider in boxColliders)
    //        {
    //            boxCollider.enabled = false;
    //        }

    //        var spriteRenderers = mouseDefender.GetComponentsInChildren<SpriteRenderer>();
    //        foreach(var spriteRenderer in spriteRenderers)
    //        {
    //            spriteRenderer.sortingLayerName = "MouseDefender";
    //        }
    //    }
    //}

    //public void DestroyMouseDefender()
    //{
    //    GameObject.Destroy(mouseDefender.gameObject);
    //}

    public void SpawnDefender(GameObject parentObject)
    {
        if (defender && defender.GetDefenderCost() > 0)
        {
            candiesDisplay.DeceaseCandies(defender.GetDefenderCost());
            Defender myDefender = Instantiate(defender, new Vector2(parentObject.transform.position.x, parentObject.transform.position.y - offSet), transform.rotation) as Defender;

            float screenHeight = Screen.height;
            float screenWidth = Screen.width;
            int DEVICE_ASPECT_RATIO = Mathf.FloorToInt(screenWidth / screenHeight);

            float newScaleX = DEVICE_ASPECT_RATIO > 1 ? myDefender.transform.localScale.x * (1 + (float)DEVICE_ASPECT_RATIO / 10) : myDefender.transform.localScale.x;
            myDefender.transform.localScale = new Vector3(newScaleX, myDefender.transform.localScale.y, 1f);

            myDefender.transform.parent = parentObject.transform;


            FindObjectOfType<DefenderButton>().DeselectDefenderButtons();
            defender = null;

            //GameObject.Destroy(mouseDefender.gameObject);
        }
        else
        {
            if (candiesDisplay.GetCandiesToSpend() < defender.GetDefenderCost() || defender.GetDefenderCost() == 0)
            {
                defender = null;
                FindObjectOfType<DefenderButton>().DeselectDefenderButtons();

            }
        }
    }
}
