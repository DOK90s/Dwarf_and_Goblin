using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> territoriesInScene;
    public int territoriesNumber = 0;
    public GameObject playerManager;
    private PlayerManager playerManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerManagerScript = playerManager.GetComponent<PlayerManager>();
        territoriesNumber = 0;
        int count = 1;
        foreach (Transform child in this.transform)
        {
            territoriesInScene.Add(child.gameObject);
            territoriesNumber++;
            child.GetComponent<Territory>().owner = null;
            child.GetComponent<Territory>().number = count;
            count++;
        }

        if (playerManagerScript != null && territoriesInScene.Count > 0)
        {
            SpawnPlayers();
        }
        else
        {
            Debug.LogError("playerManagerScript or territoriesInScene is not initialized");
        }

        //METTERE QUI LO SPAWN DEI PLAYER
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayers()
    {
        List<GameObject> cloneList = new List<GameObject>(territoriesInScene);
        int actualCount = 0;

        foreach (Player player in playerManagerScript.gameData.playersInGame)
        {
            int randomTerritory = Random.Range(0, cloneList.Count);
            GameObject playerfirstTerritory = cloneList[randomTerritory];

            Territory territoryScript = playerfirstTerritory.GetComponent<Territory>();
            if (territoryScript != null)
            {
                territoryScript.owner = player;
                territoryScript.AddToOwnerList();
                territoryScript.UpdateColor();
            }
            else
            {
                Debug.LogError("Territory script is missing on the game object");
            }
            cloneList.RemoveAt(randomTerritory);
            actualCount++;

        }
    }
}
