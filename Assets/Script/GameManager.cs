using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static int round;
    public bool SkipRound;
    public GameObject panelGameOver;
    public GameObject panelRound;
    DataBase dataCard;
    Player player1;
    Player player2;
    static public Player currentPlayer;
    Player start;
    Player playerEnd;

    public void CallPanelRound()
    {
        StartCoroutine(PanelRound());
        IEnumerator PanelRound()
        {
            panelRound.SetActive(true);
            Transform panel = panelRound.GetComponent<CanvasGroup>().transform;
            panel.GetChild(3).GetComponent<Image>().sprite = Winner(player1, player2, round).image;
            yield return new WaitForSeconds(3);

            panelRound.SetActive(false);
        }
    }
    private Player Winner()
    {
        int winner1=0;
        int winner2=0;
        for (int i = 0; i < round+1; i++)
        {
            if (player1.powerRound[i] > player2.powerRound[i] && player1.powerRound[i] > player2.powerRound[i])
                winner1++;
            else winner2++;
        }
        if(winner1 == 2 || winner2 == 2) 
        {
            if (winner1 > winner2)
                return player1;
            else return player2;
        }
        return null;
    }
    public void ButtonSkipTurn()
    {
        currentPlayer.oneMove = false;
        if (!SkipRound)
        {
            if (player1.myTurn)
            {
                player1.myTurn = false; player2.myTurn = true;
                currentPlayer = player2;
            }
            else
            {
                player2.myTurn = false; player1.myTurn = true;
                currentPlayer = player1;
            }
        }
        else
            ButtonSkipRound();
    }
    public void ButtonSkipRound()
    {
        if (playerEnd == currentPlayer)
        {
            if (round == 2 || Winner() != null)
                PanelGameOver();
            else
            {
                CallPanelRound();
                SkipRound = false;
                currentPlayer.oneMove = false;
                if (player1.powerRound[round] > player2.powerRound[round])
                {
                    player1.myTurn = true; player2.myTurn = false;
                    currentPlayer = player1;
                    start = player1;
                    playerEnd = player2;
                }
                else
                {
                    player1.myTurn = false; player2.myTurn = true;
                    currentPlayer = player2;
                    start = player2;
                    playerEnd = player1;
                }
                round += 1;

                player1.Cementery();
                player2.Cementery();
                player1.TakeCard();
                player2.TakeCard();
            }
        }
        else
        {
            ButtonSkipTurn();
            SkipRound = true;
        }
    }
    private void PanelGameOver()
    {
        panelGameOver.SetActive(true);
        Transform panel = panelGameOver.GetComponent<CanvasGroup>().transform;

        //Player1
        panel.GetChild(6).GetComponent<Text>().text = player1.powerRound[0].ToString();
        panel.GetChild(7).GetComponent<Text>().text = player1.powerRound[1].ToString();
        panel.GetChild(8).GetComponent<Text>().text = player1.powerRound[2].ToString();

        //Player2
        panel.GetChild(9).GetComponent<Text>().text = player2.powerRound[0].ToString();
        panel.GetChild(10).GetComponent<Text>().text = player2.powerRound[1].ToString();
        panel.GetChild(11).GetComponent<Text>().text = player2.powerRound[2].ToString();

        //Winner
        if(Winner() != null)
        panel.GetChild(18).GetComponent<Image>().sprite = Winner().image;
    }
    private Player Winner(Player one, Player two, int round)
    {
        if (one.GetComponent<Player>().powerRound[round] > two.GetComponent<Player>().powerRound[round])
            return one;

        else return two;
    }
    public void ModifiedRow(string nameRow, int delta)
    {
        for (int i = 0; i < GameObject.Find(nameRow).GetComponent<Panels>().itemsCounter; i++)
            if (GameObject.Find(nameRow).GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHero)
                GameObject.Find(nameRow).GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(delta);   
    }

    void Start()
    {
        dataCard = new DataBase();
        dataCard.CreateCard();                                                                                     // Crea las instancias de las cartas 

        round = 0;                                                                                                 // Declara la ronda 1

        player1 = GameObject.Find("Player1").GetComponent<Player>();
        player2 = GameObject.Find("Player2").GetComponent<Player>();
        player1.deck = dataCard.deckDemon;
        player2.deck = dataCard.deckHeavenly;                                                                                   
          
        currentPlayer = player1;
        start = player1;  // Inicia el juego con el jugador 1       
        playerEnd = player2;// Declara el turno 1
        player1.TakeCard();
        player2.TakeCard();

    }
    void Update()
    {

    }
}
