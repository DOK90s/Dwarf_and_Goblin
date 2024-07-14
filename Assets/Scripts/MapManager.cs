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
        foreach (Transform child in this.transform)
        {
            territoriesInScene.Add(child.gameObject);
            territoriesNumber++;
            //DAGLI UN ORDINE
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
