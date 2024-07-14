using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{
    public GameData gameData;
    public Player turnPlayer;
    public Player monster;
    private int playerToCall;
    private int roundNumber; //un round è il numero del giro dei turni
    private int turnNumber;

    public TMP_Text playerText;
    public TMP_Text roundText; // che in realta sarebbe il turno del giocatore
    public TMP_Text phaseText; // che in realta sarebbe il turno del giocatore

    public TMP_Text buttonEndText;

    public int startingTerritoryRequest = 3; // non l'ho ancora usatoooo 
    private int dispositionCount = 0; // non l'ho ancora usatoooo 

    public int territoriesForTrooos = 3; // non l'ho ancora usatoooo 
    public int troopsGainedFromTerritories = 1; // non l'ho ancora usatoooo 

    public int troopsToSpawn;
    public string turnPhase;

    public List<Texture2D> cursors = new List<Texture2D>();


    // Start is called before the first frame update
    void Start()
    {
        StartTheGame();
    }
    public void StartTheGame()
    {
        playerToCall = 0;
        roundNumber = 1;
        turnNumber = 1;
        turnPlayer = gameData.turnOrder[playerToCall];
        playerText.text = turnPlayer.name;
        turnPhase = "Recruitment";
        roundText.text = "Turno: " + roundNumber;
        phaseText.text = turnPhase + " phase";
        buttonEndText.text = "End Phase";
        SetBaseCursor();
        StartTurnTroopCalc(); // NON SO SE VA QUI LA PIAZZO PER ORA
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurn()
    {
        playerToCall +=1;
        if(playerToCall >= gameData.turnOrder.Count)
        {
            roundNumber++;
            roundText.text = "Turno: " + roundNumber;
            phaseText.text = turnPhase + " phase";
            buttonEndText.text = "End Phase";
            playerToCall = 0;
        }
        turnPlayer = gameData.turnOrder[playerToCall];
        playerText.text = turnPlayer.name;
        turnNumber++;
        turnPhase = "Recruitment";
        StartTurnTroopCalc();

    }

    public void EndPhase()
    {
        switch(turnPhase)
        {
            case "Recruitment":
                turnPhase = "Tactic";
                buttonEndText.text = "End Phase";

                break;
                case "Tactic":
                turnPhase = "Combat";
                buttonEndText.text = "End Turn";

                break;
                case "Combat":
                buttonEndText.text = "End Phase";
                EndTurn();
                break;

        }

        roundText.text = "Turno: " + roundNumber;
        phaseText.text = turnPhase + " phase";
    }

    public void SetBaseCursor()
    {
        Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void SetHandCursor()
    {
        Cursor.SetCursor(cursors[1], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void SetCrossCursor()
    {
        Cursor.SetCursor(cursors[2], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void StartTurnTroopCalc()
    {
        if(turnPlayer.territories.Count >0)
        {
            troopsToSpawn = Mathf.FloorToInt((float)turnPlayer.territories.Count / territoriesForTrooos); // TO DO AGGIUNGERE TRUPPE BONUS PALAZZI
            Debug.Log("Truppe da spawnare: " + troopsToSpawn);
        }

    }
}
