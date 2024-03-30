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
    public GameObject panelRound;
    int counterTurn;
    DataBase dataCard;
    Player player1;
    Player player2;
    static public Player currentPlayer;

    public void ChangeTurn()        // Cambia de turno
    {
        if (counterTurn == 1)
        {
            counterTurn += 1;

            if (player1.MyTurn)
            {
                player1.MyTurn = false; player2.MyTurn = true;
                currentPlayer = player2;
            }
            else
            {
                player2.MyTurn = false; player1.MyTurn = true;
                currentPlayer = player1;
            }
        }
           
        else if (counterTurn == 2)
        {
            
            if (player1.powerRound[round - 1] > player2.powerRound[round-1])
            {
                player1.MyTurn = true; player2.MyTurn = false;
                currentPlayer = player1;
            }
            else
            {
                player1.MyTurn = false; player2.MyTurn = true;
                currentPlayer = player2;
            }
            player1.Cementery();
            player2.Cementery();
            counterTurn = 1;
            round += 1;

                                                                                 // Inicia el juego con el jugador 1                                                                                  // Declara el turno 1
        }
        currentPlayer.oneMove = false;
    }
    private void  PanelRound()
    {
        Transform panel = GameObject.Find("PanelRound").GetComponent<CanvasGroup>().transform;

        //Player1
        panel.GetChild(6).GetComponent<Text>().text = player1.powerRound[0].ToString();
        panel.GetChild(7).GetComponent<Text>().text = player1.powerRound[1].ToString();
        panel.GetChild(8).GetComponent<Text>().text = player1.powerRound[2].ToString();

        //Player2
        panel.GetChild(9).GetComponent<Text>().text = player2.powerRound[0].ToString();
        panel.GetChild(10).GetComponent<Text>().text = player2.powerRound[1].ToString();
        panel.GetChild(11).GetComponent<Text>().text = player2.powerRound[2].ToString();

        //Winner
        panel.GetChild(18).GetComponent<Image>().sprite = Winner(player1, player2).player;
    }
    private Player Winner(Player one, Player two)
    {
        int oneSigma = 0;
        int twoSigma = 0;
        for (int i = 0; i < 3; i++)
        {
            oneSigma += one.GetComponent<Player>().powerRound[i];
            twoSigma += two.GetComponent<Player>().powerRound[i];
        }
        if (oneSigma > twoSigma)
            return one;
        else return two;
    }
    private IEnumerator For(int max)                       // Cantidad de cartas que toma del deck
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        for (int i = 0; i < max; i++)
        {
            int rand = Random.Range(1, currentPlayer.deck.Count);
            GameObject a = Instantiate(prefarb, GameObject.Find(currentPlayer.handName).transform);

            a.GetComponent<CardDisplay>().card = currentPlayer.deck[rand];
            GameObject.Find(currentPlayer.handName).GetComponent<Panels>().cards.Add(a);
            currentPlayer.deck.RemoveAt(rand);

            yield return new WaitForSeconds(0.08f);
        }
    }           
    public void Take()                                     // Tomar cartas del deck
    {
        int numChild = GameObject.Find(currentPlayer.handName).transform.childCount;

        if (numChild == 0)                                // Tomar 10 iniciales 
            StartCoroutine(For(10));

        else if ((numChild != 0) && (numChild < 10))      // Tomar 2 cartas o menos
        {
            if (10 - numChild <= 2)
                StartCoroutine(For(10 - numChild));
            else
                StartCoroutine(For(2));
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
        counterTurn = 1;

        player1 = GameObject.Find("Player1").GetComponent<Player>();
        player2 = GameObject.Find("Player2").GetComponent<Player>();
        player1.deck = dataCard.deckDemon;
        player2.deck = dataCard.deckHeavenly;                                                                                   
          
        currentPlayer = player1;                                                                                   // Inicia el juego con el jugador 1                                                                                  // Declara el turno 1
        Take();

    }
    void Update()
    {
        if (round == 4)
        {
            panelRound.SetActive(true);
            PanelRound();
        }
    }
}
