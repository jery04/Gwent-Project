using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public string playerName;
    public int generalPower;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        generalPower = 0;          // Inicializa en cero
        MyTurn = false;             
    }
    public int GeneralPower()      // Devuelve la puntuacion del jugador al finalizar la ronda
    {
        int generalPower = 0;
        foreach (GameObject item in GameObject.Find(meleeName).GetComponent<Panels>().cards)   // Acumulado de Melee
            generalPower += int.Parse(item.GetComponent<CardDisplay>().textPower.text);

        foreach (GameObject item in GameObject.Find(rangeName).GetComponent<Panels>().cards)  // Acumulado de Range
            generalPower += int.Parse(item.GetComponent<CardDisplay>().textPower.text);

        foreach (GameObject item in GameObject.Find(siegeName).GetComponent<Panels>().cards)  // Acumulado de Siege
            generalPower += int.Parse(item.GetComponent<CardDisplay>().textPower.text);

        return generalPower;
    }
    // Update is called once per frame
    void Update()
    {
        generalPower = GeneralPower();
    }
}
