using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public string playerName;
    public string handName;
    public List<Card> deck = new List<Card>();
    public string meleeName; 
    public string rangeName; 
    public string siegeName;
    public bool MyTurn;

    public Player(string playerName, string handName, List<Card> deck, string meleeName, string rangeName, string siegeName)
    {
        this.playerName = playerName;
        this.handName = handName;
        this.deck = deck;
        this.meleeName = meleeName;
        this.rangeName = rangeName;
        this.siegeName = siegeName;
        this.Start();
    }

    public void Cementery()
    {
        foreach (GameObject item in GameObject.Find(meleeName).GetComponent<Panels>().cards)  // Envía las cartas en Melee al cementerio
            GameObject.Destroy(item);                                                           

        foreach (GameObject item in GameObject.Find(rangeName).GetComponent<Panels>().cards)  // Envía las cartas en Range al cementerio
            GameObject.Destroy(item);

        foreach (GameObject item in GameObject.Find(siegeName).GetComponent<Panels>().cards)  // Envía las cartas en Siege al cementerio
            GameObject.Destroy(item);
    }
    public int GeneralPower()      // Devuelve la puntuacion del jugador al finalizar la ronda
    {
        int generalPower = 0;

        generalPower += GameObject.Find(meleeName).GetComponent<Panels>().PowerRow();
        generalPower += GameObject.Find(rangeName).GetComponent<Panels>().PowerRow();
        generalPower += GameObject.Find(siegeName).GetComponent<Panels>().PowerRow();

        return generalPower;
    }
    public void BackImageAndDrag()
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
            foreach (GameObject item in GameObject.Find(handName).GetComponent<Panels>().cards)
            {
                item.GetComponent<CardDisplay>().Back.enabled = false;      // Si está jugando se desactiva el BackImage 
                item.GetComponent<Drag>().enabled = true;                   // Si está jugando se activa el Script Drag
            }   
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MyTurn = false;             
    }
    // Update is called once per frame
    public void Update()
    {

    }
}
