using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    // Propiedades
    #region Property
    public string playerName;                              // Nombre del jugador
    public List<Card> deck = new List<Card>();             // Mazo del jugador
    public int[] powerRound;                               // Puntos acumulados por rondas
    public int takeCardStartGame = 0;                      // Cantidad de cartas cambiadas antes de la batalla

    public bool myTurn;                                    // Dicta el turno del jugador
    public bool SkipRound;                                 // Dicta si el jugador pasa la ronda
    public bool oneMove;                                   // Dicta si el jugador ya ha jugado una carta
    public Text counterDeck;

    // Paneles
    public GameObject hand;                                // Cartas de la mano
    public GameObject[] field;                             // Cartas del campo(Melee-Range-Siege)
    public GameObject[] increase;                          // Cartas de aumento
    public GameObject climate;                             // Cartas clima
    public GameObject panelTakeCard;                       // Panel para robar carta antes de la batalla
    public GameObject InfoTakeCard;                        // Boton-Info que indica poder robar cartas
    #endregion 

    // M�todos 
    public void Cementery()                                // Env�a todas las cartas al cementerio
    {
        climate.GetComponent<Panels>().RemoveAll();        // Env�a las cartas de climate al cementerio

        foreach (GameObject item in field)                 // Env�a las cartas de increase al cementerio
            item.GetComponent<Panels>().RemoveAll();

        foreach (GameObject item in increase)              // Env�a las cartas Melee, Range y Siege al cementerio
            item.GetComponent<Panels>().RemoveAll();
    }
    private void GeneralPower(int round)                   // Devuelve la puntuaci�n del jugador al finalizar la ronda
    {
        int power = 0;
        foreach (GameObject item in field)
            power += item.GetComponent<Panels>().PowerRow();

        powerRound[round] = power;
    }
    private void BackImageAndDrag()                        // Modifica el estado(Active) del Script Drag e im�genes
    {
        if (!myTurn)                                                        // Si no est� en juego...
        {
            foreach (GameObject item in hand.GetComponent<Panels>().cards)
            {
                item.GetComponent<CardDisplay>().Back.enabled = true;       // Si no est� jugando se activa el BackImage 
                item.GetComponent<Drag>().enabled = false;                  // Si no est� jugando se desactiva el Script Drag
            }
            foreach(GameObject item in field)                               // Desactiva el Script Drop de field
                item.GetComponent<Drop>().enabled = false;
        }
        else                                                                // De lo contrario, si est� en juego...
        {
            if (!oneMove)                                                   // Si no ha hecho ning�n movimiento
            {
                foreach (GameObject item in hand.GetComponent<Panels>().cards)
                {
                    item.GetComponent<CardDisplay>().Back.enabled = false;      // Si est� jugando se desactiva el BackImage 
                    item.GetComponent<Drag>().enabled = true;                   // Si est� jugando y no ha hecho ning�n movimiento se activa el Script Drag
                }
            }
            else
            {
                foreach (GameObject item in hand.GetComponent<Panels>().cards)
                {
                    item.GetComponent<CardDisplay>().Back.enabled = false;      // Si est� jugando se desactiva el BackImage 
                    item.GetComponent<Drag>().enabled = false;                  // Si est� jugando y ya hizo un movimiento y es heroe se desactiva el Script Drag
                }
            }
            foreach (GameObject item in field)                               // Activa el Script Drop de field
                item.GetComponent<Drop>().enabled = true;
        }
    }
    private IEnumerator For(int max)                       // Cantidad de cartas que puede tomar del deck
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        for (int i = 0; i < max; i++)
        {
            int rand = UnityEngine.Random.Range(1, deck.Count);
            GameObject a = Instantiate(prefarb, hand.transform);
            a.GetComponent<EventTrigger>().enabled = false;
            a.GetComponent<CardDisplay>().card = deck[rand];
            a.name = deck[rand].name;

            hand.GetComponent<Panels>().cards.Add(a);
            deck.RemoveAt(rand);

            yield return new WaitForSeconds(0.08f);
        }
    }
    public void TakeCard(int num = 0)                      // Tomar cartas del deck
    {
        int numChild = hand.GetComponent<Panels>().itemsCounter;

        if (numChild == 0)
            StartCoroutine(For(10));                      // Tomar 10 iniciales 

        else if((num != 0)&& (numChild < 10))
            StartCoroutine(For(1));

        else if (numChild < 10)      // Tomar 2 cartas o menos
        {
            if (10 - numChild <= 2)
                StartCoroutine(For(10 - numChild));
            else
                StartCoroutine(For(2));
        }
    }
    public void ButtonInfoTakeCard()                       // Modifica la visibilidad del bot�n Info
    {
        if(GameManager.round == 0 && myTurn && takeCardStartGame < 2)
            InfoTakeCard.SetActive(true);
        else 
            InfoTakeCard.SetActive(false);
    }           
    public void Active(bool active)                        // Modifica el estado(Active) del componente EventTrigger
    {
        for (int i = 0; i < hand.GetComponent<Panels>().itemsCounter; i++)
        {
            hand.GetComponent<Panels>().cards[i].GetComponent<EventTrigger>().enabled = active;
        }
    }
    public void ButtonTrigger(bool active)                 // Bot�n(Yes) tomar cartas antes de la batalla
    {
        Active(active);
        panelTakeCard.SetActive(false);
        takeCardStartGame += 1;
    }
    public void ButtonNot()                                // Bot�n(No) tomar cartas antes de la batalla
    {
        takeCardStartGame = 2;
        panelTakeCard.SetActive(false);
    }
    public void ActivePanelTakeCard()                      // Muestra el panel TakeCard
    {
        panelTakeCard.SetActive(true);
    }

    void Start()
    {
        powerRound = new int[3] { 0, 0, 0 };              // Inicializa la puntuaci�n de las ronndas en cero
    }
    public void Update()
    {
        ButtonInfoTakeCard();
        GeneralPower(GameManager.round);                 // Actualiza el poder
        counterDeck.text = deck.Count.ToString();
        BackImageAndDrag();                              // Actualiza el M�todo
        if (oneMove) takeCardStartGame = 2;              // Si juega una carta se desactiva la opcion TakeCard al inicio
    }
}
