using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{
    [Header("Informazioni")]
    public string playerName;
    public Material playerMaterial;

    [Header("Non toccare pls")]
    public int playerNum = 0;
    public bool isHuman = false;
    public bool isAlive = false;
    public List <GameObject> territories = new List <GameObject>();
    public Faction faction;

    public int troopsFromTerritories = 0;
    public int troopsBonus = 0;
    public int totalTroops = 0;


    // Start is called before the first frame update
    void Awake()
    {
        ResetPlayerTroops();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetPlayerTroops()
    {
        troopsFromTerritories = 0;
        troopsBonus = 0;
        totalTroops = 0;
    }
    public void CalcPlayerTroops()
    {
        totalTroops = troopsFromTerritories + troopsBonus;
    }

}
