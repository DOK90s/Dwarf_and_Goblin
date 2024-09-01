using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerManager : MonoBehaviour
{
    [Header("Impostazioni della partita")]
    public int totalPlayersNumber; // Quanti players ci sono nella partita

    [Header("Non toccare pls")]
    public GameData gameData; // Riferimento allo ScriptableObject

    private int playersCount = 0;

    void Start()
    {
        SetPlayers();
    }

    void Update()
    {

    }

    void SetPlayers()
    {
        //gameData.playersInGame.Clear();
        playersCount = 0;

        /*if (totalPlayersNumber < 2)
        {
            totalPlayersNumber = 2;
        }
        else if (totalPlayersNumber > 8)
        {
            totalPlayersNumber = 8;
        }

        if (gameData.allPossiblePlayers.Count < totalPlayersNumber)
        {
            Debug.LogError("Non ci sono abbastanza giocatori possibili per il numero totale di giocatori specificato.");
            return;
        }

        for (int i = 0; i < totalPlayersNumber; i++)
        {
            gameData.playersInGame.Add(gameData.allPossiblePlayers[i]);
        }*/

        foreach (Player player in gameData.playersInGame)
        {
            player.playerNum = playersCount + 1;
            player.isAlive = true;
            playersCount++;
        }

        if (gameData.playersInGame.Count > 0)
        {
            gameData.playersInGame[0].isHuman = true;
        }

        if (playersCount == totalPlayersNumber)
        {
            gameData.turnOrder = gameData.playersInGame;
            StartGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("Gioco Iniziato");
    }
}