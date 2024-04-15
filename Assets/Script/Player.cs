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
    #region Propiedades
    public string playerName;                              // Nombre del jugador
    public List<Card> deck = new List<Card>();             // Mazo del jugador
    public int[] powerRound;                               // Puntos acumulados por rondas

    public bool myTurn;                                    // Dicta el turno del jugador
    public bool SkipRound;                                 // Dicta si el jugador pasa la ronda
    public bool oneMove;                                   // Dicta si el jugador ya ha jugado una carta
    public Text counterDeck;

    public GameObject hand;                                // Cartas de la mano
    public GameObject[] field;                             // Cartas del campo(Melee-Range-Siege)
    public GameObject[] increase;                          // Cartas de aumento
    public GameObject climate;                             // Cartas clima
    #endregion 

    public void Cementery()                                // Envía todas las cartas al cementerio
    {
        climate.GetComponent<Panels>().RemoveAll();        // Envía las cartas de climate al cementerio

        foreach (GameObject item in field)                 // Envía las cartas de increase al cementerio
            item.GetComponent<Panels>().RemoveAll();

        foreach (GameObject item in increase)              // Envía las cartas Melee, Range y Siege al cementerio
            item.GetComponent<Panels>().RemoveAll();
    }
    private void GeneralPower(int round)                   // Devuelve la puntuación del jugador al finalizar la ronda
    {
        int power = 0;
        foreach (GameObject item in field)
            power += item.GetComponent<Panels>().PowerRow();

        powerRound[round] = power;
    }
    private void BackImageAndDrag()
    {
        if (!myTurn)                                                        // Si no está en juego...
        {
            foreach (GameObject item in hand.GetComponent<Panels>().cards)
            {
                item.GetComponent<CardDisplay>().Back.enabled = true;       // Si no está jugando se activa el BackImage 
                item.GetComponent<Drag>().enabled = false;                  // Si no está jugando se desactiva el Script Drag
            }
            foreach(GameObject item in field)                               // Desactiva el Script Drop de field
                item.GetComponent<Drop>().enabled = false;
        }
        else                                                                // De lo contrario, si está en juego...
        {
            if (!oneMove)                                                   // Si no ha hecho ningún movimiento
            {
                foreach (GameObject item in hand.GetComponent<Panels>().cards)
                {
                    item.GetComponent<CardDisplay>().Back.enabled = false;      // Si está jugando se desactiva el BackImage 
                    item.GetComponent<Drag>().enabled = true;                   // Si está jugando y no ha hecho ningún movimiento se activa el Script Drag
                }
            }
            else
            {
                foreach (GameObject item in hand.GetComponent<Panels>().cards)
                {
                    item.GetComponent<CardDisplay>().Back.enabled = false;      // Si está jugando se desactiva el BackImage 
                    item.GetComponent<Drag>().enabled = false;                  // Si está jugando y ya hizo un movimiento y es heroe se desactiva el Script Drag
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
            int rand = Random.Range(1, deck.Count);
            GameObject a = Instantiate(prefarb, hand.transform);

            a.GetComponent<CardDisplay>().card = deck[rand];
            a.name = deck[rand].name;
            hand.GetComponent<Panels>().cards.Add(a);
            deck.RemoveAt(rand);

            yield return new WaitForSeconds(0.08f);
        }
    }
    public void TakeCard(int num = 0)                      // Tomar cartas del deck
    {
        int numChild = hand.transform.childCount;

        if (numChild == 0)
            StartCoroutine(For(10));                      // Tomar 10 iniciales 

        else if (num != 0 && numChild < 10)               // Toma 1 carta
            StartCoroutine(For(1));

        else if ((numChild != 0) && (numChild < 10))      // Tomar 2 cartas o menos
        {
            if (10 - numChild <= 2)
                StartCoroutine(For(10 - numChild));
            else
                StartCoroutine(For(2));
        }
    }

    void Start()
    {
        powerRound = new int[3] { 0, 0, 0 };              // Inicializa la puntuación de las ronndas en cero
    }
    public void Update()
    {
        GeneralPower(GameManager.round);                 // Actualiza el poder
        BackImageAndDrag();                              // Actualiza el Método
        counterDeck.text = deck.Count.ToString();
    }
}
