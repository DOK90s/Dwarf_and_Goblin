using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Faction", menuName = "Faction", order = 1)]
public class Faction : ScriptableObject
{
    public List <Sprite> FactionMembers = new List <Sprite>();

    public string factionName;
    public Factions faction;
    public enum Factions // non l'ho ancora usatoooo 
    {
        Goblins,
        Dwarfs,
        Monsters
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
