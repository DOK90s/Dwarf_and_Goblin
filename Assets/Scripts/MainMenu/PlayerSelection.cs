using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{

    public int playersNumber = 2;
    public TMP_Text playerNumberText;
    public GameObject player1Button;
    public TMP_Text player1name;
    public GameObject player2Button;
    public TMP_Text player2name;
    public GameObject player3Button;
    public TMP_Text player3name;
    public GameObject player4Button;
    public TMP_Text player4name;

    public GameObject player1Icon;
    public GameObject player2Icon;
    public GameObject player3Icon;
    public GameObject player4Icon;

    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    public List<Player> players2InLobby;
    public List<Player> players3InLobby;
    public List<Player> players4InLobby;

    public List<Player> currentLobby;
    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {

        playersNumber = 2;
        ShowPlayerButtons();
        SetPlayersColors();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPlayer()
    {
        if (playersNumber < 4)
        {
            playersNumber++;
            playerNumberText.text = playersNumber.ToString();
            ShowPlayerButtons();
        }
    }

    public void RemovePlayer()
    {
        if (playersNumber > 2)
        {
            playersNumber--;
            playerNumberText.text = playersNumber.ToString();
            ShowPlayerButtons();
        }
    }

    public void SetPlayersColors()
    {
        player1name.color = player1.playerColor;

        player1Icon.GetComponent<DynamicIcon>().borderColor = player1.playerColor;

        player2name.color = player2.playerColor;

        player2Icon.GetComponent<DynamicIcon>().borderColor = player2.playerColor;

        player3name.color = player3.playerColor;

        player3Icon.GetComponent<DynamicIcon>().borderColor = player3.playerColor;

        player4name.color = player4.playerColor;

        player4Icon.GetComponent<DynamicIcon>().borderColor = player4.playerColor;

        player1name.text = player1.playerName.ToString();
        player2name.text = player2.playerName.ToString();
        player3name.text = player3.playerName.ToString();
        player4name.text = player4.playerName.ToString();
    }

    public void StartGame()
    {
        SetPlayersInLobby();
        SceneManager.LoadScene(1);
        //apri la scena
    }
    public void SetPlayersInLobby()
    {
        currentLobby.Clear();
        switch (playersNumber)
        {
            case 2:
                currentLobby = players2InLobby;
                break;
            case 3:
                currentLobby = players3InLobby;
                break;
            case 4:
                currentLobby = players4InLobby;
                break;
        }

        gameData.playersInGame = currentLobby;
    }

    public void ShowPlayerButtons()
    {

        switch (playersNumber)
        {
            case 2:
                player1Button.SetActive(true);
                player2Button.SetActive(true);
                player3Button.SetActive(false);
                player4Button.SetActive(false);

                player1Icon.SetActive(true);
                player2Icon.SetActive(true);
                player3Icon.SetActive(false);
                player4Icon.SetActive(false);
                break;
            case 3:
                player1Button.SetActive(true);
                player2Button.SetActive(true);
                player3Button.SetActive(true);
                player4Button.SetActive(false);

                player1Icon.SetActive(true);
                player2Icon.SetActive(true);
                player3Icon.SetActive(true);
                player4Icon.SetActive(false);
                break;
            case 4:
                player1Button.SetActive(true);
                player2Button.SetActive(true);
                player3Button.SetActive(true);
                player4Button.SetActive(true);

                player1Icon.SetActive(true);
                player2Icon.SetActive(true);
                player3Icon.SetActive(true);
                player4Icon.SetActive(true);
                break;
        }
    }

}
