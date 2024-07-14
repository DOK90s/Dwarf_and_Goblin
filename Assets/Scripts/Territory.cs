using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory : MonoBehaviour
{
    [Header("Informazioni Territorio")]
    public string name;
    public List<Territory> neighboringTerritories;

    [Header("Cose da settare")]
    public float hoverColorIntensity = 1.5f;

    [Header("Tocca qualcosa qui e verrai stuprato")]
    public int troopsNumber;
    public GameObject turnManager;
    public TurnManager turnManagerScript;
    public Player owner;
    private Renderer thisRenderer;
    public Material territoryMaterial;
    public GameObject troopSprite;
    //private int PlayerTerritoryOrderList; //ordine per la lista del player DA FIXARE


    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.FindWithTag("TurnManager");
        turnManagerScript = turnManager.GetComponent<TurnManager>();
        thisRenderer = this.gameObject.GetComponent<Renderer>();
        FirstSetUP();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeOwnerSprite()
    {
        if(owner != null)
        {
            troopSprite.GetComponent<SpriteRenderer>().sprite = owner.faction.FactionMembers[0];
        }else
            troopSprite.GetComponent<SpriteRenderer>().sprite = turnManagerScript.monster.faction.FactionMembers[0];

    }

    public void OnLeftMouseClick()
    {
        if(turnManagerScript.turnPlayer == owner)
        {
            Debug.Log("Hai LEFTcliccato sul Territorio: " + name + " nel tuo turno");
            troopsNumber++;
        }
    }
    public void OnRightMouseClick()
    {
        Debug.Log("Hai RIGHTcliccato sul Territorio: " + name);
    }

    public void OnMouseEnter()
    {
        Debug.Log("Sei entrato nel Territorio: " + name);
        HoverColor();
        if(owner == turnManagerScript.turnPlayer)
        {
            turnManagerScript.SetHandCursor();
        }
        else
        if (owner != turnManagerScript.turnPlayer)
        {
            turnManagerScript.SetCrossCursor();
        }


    }

    public void OnMouseExit()
    {
        Debug.Log("Sei uscito dal Territorio: " + name);
        UpdateColor();
        turnManagerScript.SetBaseCursor();
    }

    public void HoverColor()
    {
        Material newMaterial = new Material(thisRenderer.material);
        Color originalColor = newMaterial.color;

        Color highlightColor = originalColor * hoverColorIntensity;

        newMaterial.color = highlightColor;

        thisRenderer.material.color = newMaterial.color;
    }

    public void UpdateColor()
    {
        if (owner != null)
        {
            thisRenderer.material = owner.playerMaterial;

        }else
        {
            thisRenderer.material = territoryMaterial;
        }
        
    }
    public void FirstSetUP()
    {
        UpdateColor();
        ChangeOwnerSprite();
        //AddToOwnerList();
    }

    /*public void AddToOwnerList()
    {
        if (owner != null)
        {
            PlayerTerritoryOrderList += 1;
            owner.territories.Add(this.gameObject);
        }
    }
    public void RemoveToOwnerList()
    {
        if (owner != null)
        {
            PlayerTerritoryOrderList -= 1;

            owner.territories.RemoveAt(PlayerTerritoryOrderList);
        }
    }*/
}
