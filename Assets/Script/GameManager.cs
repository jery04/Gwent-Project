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
    int round;
    int counterTurn;
    DataBase dataCard = new DataBase();
    Player player1;
    Player player2;
    static public Player currentPlayer;

    public void ChangeTurn()        // Cambia de turno
    {
        if (counterTurn != 2)
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
            if (player1.GeneralPower() > player2.GeneralPower())
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
        }
        Debug.Log(counterTurn + " " + round);
        playerUpdate();
    }
    private void playerUpdate()
    {
        player1.BackImageAndDrag();
        player2.BackImageAndDrag();
    }
    private void InstantiateCard(string handName, List<Card> deck)
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        int rand = Random.Range(1, deck.Count);

        GameObject a = Instantiate(prefarb, GameObject.Find(handName).transform);
        a.GetComponent<CardDisplay>().card = deck[rand];
        GameObject.Find(handName).GetComponent<Panels>().cards.Add(a);
        deck.RemoveAt(rand);
    }
    public void Take()                                     // Tomar cartas del deck
    {
        int numChild = GameObject.Find(currentPlayer.handName).transform.childCount;

        if (numChild == 0)                                 // Tomar 10 iniciales 
        {
            for (int i = 0; i < 10; i++)
                InstantiateCard(currentPlayer.handName, currentPlayer.deck);
        }
        else if ((numChild != 0) && (numChild < 10))      // Tomar 2 cartas
        {
            if (10 - numChild <= 2)
            {
                for (int i = 0; i < (10 - numChild); i++)
                    InstantiateCard(currentPlayer.handName, currentPlayer.deck);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                    InstantiateCard(currentPlayer.handName, currentPlayer.deck);
            }
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
        dataCard.CreateCard();                                                                                      // Crea las instancias de las cartas 
        player1 = new Player("Player1", "Hand1", dataCard.deckDemon, "Melee", "Range", "Siege");
        player2 = new Player("Player2", "Hand2", dataCard.deckHeavenly, "Melee (2)", "Range (2)", "Siege (2)");
        player1.MyTurn = true;                                                                                     // Inicia el juego con el jugador 1                                                     
        currentPlayer = player1;
        round = 1;                                                                                                 // Declara la ronda 1
        counterTurn = 1;                                                                                           // Declara el turno 1
    }
    void Update()
    {

    }
}
