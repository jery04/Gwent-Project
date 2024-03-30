using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public Sprite player;
    public int[] powerRound;
    public string playerName;
    public string handName;
    public List<Card> deck = new List<Card>();
    public string meleeName; 
    public string rangeName; 
    public string siegeName;
    public string leader;
    public string[] increaseName;
    public bool MyTurn;
    public bool oneMove;

    public Player(string playerName, string handName, List<Card> deck, string meleeName, string rangeName, string siegeName)
    {
        powerRound = new int[3] { 0, 0, 0 };
        this.playerName = playerName;
        this.handName = handName;
        this.deck = deck;
        this.meleeName = meleeName;
        this.rangeName = rangeName;
        this.siegeName = siegeName;
    }

    public void Cementery()
    {
        foreach (string item in increaseName)                                                 // Envía las cartas de Increase al cementerio
            GameObject.Destroy(GameObject.Find(item));

        foreach (GameObject item in GameObject.Find(meleeName).GetComponent<Panels>().cards)  // Envía las cartas de Melee al cementerio
            GameObject.Destroy(item);                                                           

        foreach (GameObject item in GameObject.Find(rangeName).GetComponent<Panels>().cards)  // Envía las cartas de Range al cementerio
            GameObject.Destroy(item);

        foreach (GameObject item in GameObject.Find(siegeName).GetComponent<Panels>().cards)  // Envía las cartas de Siege al cementerio
            GameObject.Destroy(item);
    }
    private void GeneralPower(int round)      // Devuelve la puntuacion del jugador al finalizar la ronda
    {
        int power = 0;
        power += GameObject.Find(meleeName).GetComponent<Panels>().PowerRow();
        power += GameObject.Find(rangeName).GetComponent<Panels>().PowerRow();
        power += GameObject.Find(siegeName).GetComponent<Panels>().PowerRow();
        powerRound[round - 1] = power;
    }
    private void BackImageAndDrag()
    {
        if (!MyTurn)        
        {
            foreach (GameObject item in GameObject.Find(handName).GetComponent<Panels>().cards)
            {
                item.GetComponent<CardDisplay>().Back.enabled = true;       // Si no está jugando se activa el BackImage 
                item.GetComponent<Drag>().enabled = false;                  // Si no está jugando se desactiva el Script Drag
            }    
        }
        else            
        {
            if (!oneMove)
            {
                foreach (GameObject item in GameObject.Find(handName).GetComponent<Panels>().cards)
                {
                    item.GetComponent<CardDisplay>().Back.enabled = false;      // Si está jugando se desactiva el BackImage 
                    item.GetComponent<Drag>().enabled = true;                   // Si está jugando y no ha hecho ningún movimiento se activa el Script Drag
                }
            }
            else
            {
                foreach (GameObject item in GameObject.Find(handName).GetComponent<Panels>().cards)
                {
                    item.GetComponent<CardDisplay>().Back.enabled = false;      // Si está jugando se desactiva el BackImage 
                    item.GetComponent<Drag>().enabled = false;                  // Si está jugando y ya hizo un movimiento se desactiva el Script Drag
                }
            }
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
