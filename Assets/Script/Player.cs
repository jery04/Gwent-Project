using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public string playerName;
    public Sprite image;
    public List<Card> deck = new List<Card>();
    public int[] powerRound;

    public bool myTurn;  
    public bool SkipRound; 
    public bool oneMove;

    public GameObject hand;
    public GameObject[] field;
    public GameObject[] increase;
    public static GameObject climate;

    public void Cementery()
    {
        //foreach (GameObject item in climate.GetComponent<Panels>().cards)  // Envía las cartas de climate al cementerio
        //    GameObject.Destroy(item);

        //foreach (GameObject item in increase)                            // Envía las cartas de increase al cementerio
        //    GameObject.Destroy(item.GetComponent<Panels>().cards[0]);

        foreach(GameObject item in field)                                // Envía las cartas melee, range y siege al cementerio
            foreach (GameObject item2 in item.GetComponent<Panels>().cards)
                GameObject.Destroy(item2);
    }
    private void GeneralPower(int round)      // Devuelve la puntuacion del jugador al finalizar la ronda
    {
        int power = 0;
        foreach (GameObject item in field)
            power += item.GetComponent<Panels>().PowerRow();

        powerRound[round - 1] = power;
    }
    private void BackImageAndDrag()
    {
        if (!myTurn)        
        {
            foreach (GameObject item in hand.GetComponent<Panels>().cards)
            {
                item.GetComponent<CardDisplay>().Back.enabled = true;       // Si no está jugando se activa el BackImage 
                item.GetComponent<Drag>().enabled = false;                  // Si no está jugando se desactiva el Script Drag
            }
            foreach(GameObject item in field)                               // Desactiva el Script Drop de field
                item.GetComponent<Drop>().enabled = false;
        }
        else            
        {
            if (!oneMove)
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

    // Start is called before the first frame update
    void Start()
    {
        powerRound = new int[3] { 0, 0, 0 };
    }
    // Update is called once per frame
    public void Update()
    {
        GeneralPower(GameManager.round);
        BackImageAndDrag();
    }
}
