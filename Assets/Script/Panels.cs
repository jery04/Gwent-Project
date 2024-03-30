using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Panels : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public List<Card.card_position> cardPos = new List<Card.card_position>();
    public int maxItems;
    public int itemsCounter;

    private void Remove()
    {
        if(cards != null && cards.Count > 0)
        { 
            for(int i = 0; i < cards.Count ;i++)
                if (cards[i] == null)
                    cards.RemoveAt(i);
        }
    }
    public int PowerRow()
    {
        int powerRow = 0;

        if (cards != null && cards.Count > 0)
        {
            foreach (GameObject item in cards)
                powerRow += int.Parse(item.GetComponent<CardDisplay>().textPower.text);
        }

        return powerRow;
    }

    private void UnDragging()
    {
        if (cards != null && cards.Count > 0 && GameManager.currentPlayer.handName != this.name)
        {
            foreach (GameObject item in cards)
                item.GetComponent<Drag>().enabled = false;
        }
    }
    private void Start()
    {

    }
    private void Update()
    {
        Remove();
        UnDragging();
        itemsCounter = cards.Count;
    }
}

