using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        IEnumerator PanelRound()
        {
            panelRound.SetActive(true);
            Transform panel = panelRound.GetComponent<CanvasGroup>().transform;
            panel.GetChild(3).GetComponent<Image>().sprite = Winner(player1, player2).image;
            yield return new WaitForSeconds(2f);
            panelRound.SetActive(false);
        }
        StartCoroutine(PanelRound());
        if (round == 3 && SkipRound)
            PanelGameOver();
    }
    public void ButtonSkipTurn()
    {
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
        {
            ButtonSkipRound();
        }
        currentPlayer.oneMove = false;
    }
    public void ButtonSkipRound()
    {
        if (playerEnd == currentPlayer)
        {
            if (player1.powerRound[round - 1] > player2.powerRound[round - 1])
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
            SkipRound = false;
            currentPlayer.oneMove = false;
            player1.Cementery();
            player2.Cementery();
            TakeCard(player1);
            TakeCard(player2);

            CallPanelRound();
            round += 1;
        }
        else
        {
            ButtonSkipTurn();
            SkipRound = true;
        }
    }
    private void PanelGameOver()
    {
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
        panel.GetChild(18).GetComponent<Image>().sprite = Winner(player1, player2).image;
    }
    private Player Winner(Player one, Player two)
    {
        if (one.GetComponent<Player>().powerRound[round-1] > two.GetComponent<Player>().powerRound[round-1])
            return one;

        else return two;
    }
    private IEnumerator For(int max, Player currentPlayer)                       // Cantidad de cartas que toma del deck
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        for (int i = 0; i < max; i++)
        {
            int rand = Random.Range(1, currentPlayer.deck.Count);
            GameObject a = Instantiate(prefarb, currentPlayer.hand.transform);

            a.GetComponent<CardDisplay>().card = currentPlayer.deck[rand];
            currentPlayer.hand.GetComponent<Panels>().cards.Add(a);
            currentPlayer.deck.RemoveAt(rand);

            yield return new WaitForSeconds(0.08f);
        }
    }           
    public void TakeCard(Player currentPlayer)                                     // Tomar cartas del deck
    {
        int numChild = currentPlayer.hand.transform.childCount;

        if (numChild == 0)
            StartCoroutine(For(10, currentPlayer));                                // Tomar 10 iniciales 


        else if ((numChild != 0) && (numChild < 10))      // Tomar 2 cartas o menos
        {
            if (10 - numChild <= 2)
                StartCoroutine(For(10 - numChild, currentPlayer));
            else
                StartCoroutine(For(2, currentPlayer));
        }
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

        round = 1;                                                                                                 // Declara la ronda 1

        player1 = GameObject.Find("Player1").GetComponent<Player>();
        player2 = GameObject.Find("Player2").GetComponent<Player>();
        player1.deck = dataCard.deckDemon;
        player2.deck = dataCard.deckHeavenly;                                                                                   
          
        currentPlayer = player1;
        start = player1;  // Inicia el juego con el jugador 1       
        playerEnd = player2;// Declara el turno 1
        TakeCard(player1);
        TakeCard(player2);

    }
    void Update()
    {

    }
}
