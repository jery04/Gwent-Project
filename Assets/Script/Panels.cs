using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Panels : MonoBehaviour 
{
    public List<GameObject> cards = new List<GameObject>();                        // Cartas en un panel
    public List<Card.card_position> position = new List<Card.card_position>();     // Posiciones que acepta el panel 
    public int maxItems;                                                           // M�xima cantidad de cartas 
    public int itemsCounter;                                                       // (0) Cantidad de cartas actualmente

    public int CounterUnity()                                                      // Cantidad de cartas de tipo Unidad
    {
        int counter = 0;
        foreach(GameObject item in cards)
            if(item.GetComponent<CardDisplay>().card.isUnity)
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
    public void Remove()                                                           // (1) Remueve cartas innecesarias del panel
    {
        if(cards.Count > 0) 
        { 
            for (int i = 0; i < cards.Count; i++) 
            { 
                if (cards[i] == null) 
                {
                    cards.RemoveAt(i);
                } 
                else if (cards[i].GetComponent<CardDisplay>().card.isUnity && cards[i].GetComponent<CardDisplay>().Power() <= 0)
                {
                    GameObject.Destroy(cards[i]);
                    cards.RemoveAt(i);
                }
            } 
        }
        itemsCounter = cards.Count;                                                 // Actualiza el contador (0)   
    }
    public int PowerRow()                                                          // (2) Poder acumulado del panel (fila)
    {
        int powerRow = 0;

        if (cards != null && cards.Count > 0)
        {
            foreach (GameObject item in cards)
                if(item != null && item.GetComponent<CardDisplay>().card.isUnity)
                    powerRow += item.GetComponent<CardDisplay>().Power();
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
    private void Update()                                                          // Actualizaci�n de propiedades
    {
        Remove();                                                                   // Actualiza el M�todo (1)                                                         
        UnDragging();                                                               // ACtualiza el M�todo (3) 
    }
}

