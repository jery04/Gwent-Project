using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Panels : MonoBehaviour 
{
    public List<GameObject> cards = new List<GameObject>();                        // Cartas en un panel
    public List<Card.card_position> position = new List<Card.card_position>();     // Posiciones que acepta el panel 
    public int maxItems;                                                           // Máxima cantidad de cartas 
    public int itemsCounter;                                                       // (0) Cantidad de cartas actualmente

    public int CounterUnity()
    {
        int counter = 0;
        foreach(GameObject item in cards)
            if(item.GetComponent<CardDisplay>().card.IsUnity)
                counter++;
        return counter;
    }
    public void RemoveAll()                                                        // Remueve todas las cartas
    {
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject.Destroy(cards[i]);
            cards.RemoveAt(i);
        }
    }
    private void Remove()                                                          // (1) Remueve cartas innecesarias del panel
    {
        if(cards != null && cards.Count > 0) 
        { 
            for (int i = 0; i < cards.Count; i++) 
            { 
                if (cards[i] == null) 
                { 
                    cards.RemoveAt(i); 
                } 
                else if (cards[i].GetComponent<CardDisplay>().card.IsUnity && int.Parse(cards[i].GetComponent<CardDisplay>().textPower.text) <= 0)
                {
                    GameObject.Destroy(cards[i]);
                    cards.RemoveAt(i);
                }
            } 
        }
    }
    public int PowerRow()                                                          // (2) Poder acumulado del panel (fila)
    {
        int powerRow = 0;

        if (cards != null && cards.Count > 0)
        {
            foreach (GameObject item in cards)
                if(item != null && item.GetComponent<CardDisplay>().card.IsUnity)
                    powerRow += int.Parse(item.GetComponent<CardDisplay>().textPower.text);
        }

        return powerRow;
    }
    private void UnDragging()                                                      // (3) Toda carta que se coloque en el panel se descativa su Script Drag
    {
        if (cards != null && cards.Count > 0 && GameManager.currentPlayer.hand.name != this.name)
            foreach (GameObject item in cards)
                item.GetComponent<Drag>().enabled = false;
    }
    private void Start()
    {

    }
    private void Update()
    {
        Remove();                                                                   // Actualiza el Método (1)                                     
        itemsCounter = cards.Count;                                                 // Actualiza el contador (0)                              
        UnDragging();                                                               // ACtualiza el Método (3) 
    }
}

