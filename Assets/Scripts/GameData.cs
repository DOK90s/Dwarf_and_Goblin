using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/Data", order = 2)]
public class GameData : ScriptableObject
{
    public List<Player> playersInGame;
    public List<Player> allPossiblePlayers;
    public List<Player> turnOrder;
}