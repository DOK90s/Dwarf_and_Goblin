using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicIcon : MonoBehaviour
{
    public bool isGoblin;
    public Color borderColor;

    public GameObject border;
    public Image bordersprite;
    public GameObject goblinImage;
    public GameObject dwarfImage;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        bordersprite = border.GetComponent<Image>();
        borderColor = player.playerColor;
        bordersprite.color = borderColor;
        /*borderImage = border.GetComponent<Image>();
        border.GetComponent<Image>().color = new Color32(255, 255, 225, 100);*/
        //goblinImage.GetComponent<Sprite>() = player.playerIcon.goblinImage;s
        goblinImage.GetComponent<Image>().sprite = player.playerIcon.goblinSprite;
        dwarfImage.GetComponent<Image>().sprite = player.playerIcon.dwarfSprite;

        if (isGoblin)
        {
            goblinImage.SetActive(true);
            dwarfImage.SetActive(false);
        }
        else 
        { 
            goblinImage.SetActive(false);
            dwarfImage.SetActive(true);
        }

        /*switch (owner)
        {
            case 1:
                playerIcon = Resources.Load<Player>("PlayerIcons/Player1_icon");
                break;
            case 2:
                playerIcon = Resources.Load<Sprite>("PlayerIcons/Player2_icon");
                break;
            case 3:
                playerIcon = Resources.Load<Sprite>("PlayerIcons/Player3_icon");
                break;
            case 4:
                playerIcon = Resources.Load<Sprite>("PlayerIcons/Player4_icon");
                break;

        }*/
    }

    public void SwitchFaction()
    {
        if (isGoblin)
        {
            goblinImage.SetActive(false);
            dwarfImage.SetActive(true);
            isGoblin = false;
            player.isGoblin = false;
        }
        else
        {
            goblinImage.SetActive(true);
            dwarfImage.SetActive(false);
            isGoblin = true;
            player.isGoblin = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
