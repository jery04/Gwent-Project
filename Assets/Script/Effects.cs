using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public static class Effects
{
    public static void Increase(params object[] item)
    {
        if (item[0] is Player player)
        {
            for (int i = 0; i < player.GetComponent<Panels>().cards.Count; i++)
                if (player.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe)
                    player.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(5);
        }
    }
    public static void TakeCard(params object[] item)
    {
        if (item[0] is Player player)
            player.TakeCard(1);
    }
    public static void DiminishPower(params object[] item)
    {
        if (item[0] is Player player1 && item[1] is Player player2)
        {
            for (int i = 0; i < player1.GetComponent<Panels>().cards.Count; i++)
                if (player1.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player1.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe)
                    player1.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(2);

            for (int i = 0; i < player2.GetComponent<Panels>().cards.Count; i++)
                if (player2.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player2.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe)
                    player2.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(2);
        }
    }
    public static void ClearRow(params object[] item)
    {
        if (item[0] is Player player)
        {
            GameObject minRow = player.field[0];
            foreach (GameObject row in player.field)
                if (((row.GetComponent<Panels>().CounterUnity() > 0) && (row.GetComponent<Panels>().CounterUnity() < minRow.GetComponent<Panels>().CounterUnity())))
                    minRow = row;
            minRow.GetComponent<Panels>().RemoveAll();
        }
    }
    public static void RemoveMax(params object[] item)
    {
        if (item[0] is Player player)
        {
            GameObject panelMax = null; int index = 0;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject rowCard in row.GetComponent<Panels>().cards)
                {
                    if(panelMax == null && rowCard.GetComponent<CardDisplay>().card.IsUnity)
                    {
                        panelMax = row;
                        index = row.GetComponent<Panels>().cards.IndexOf(rowCard);
                    }
                      
                    else if (int.Parse(rowCard.GetComponent<CardDisplay>().textPower.text) > int.Parse(panelMax.GetComponent<Panels>().cards[index].GetComponent<CardDisplay>().textPower.text))
                    {
                        panelMax = row;
                        index = row.GetComponent<Panels>().cards.IndexOf(rowCard);
                    }
                }
            }
            if(panelMax != null)
                GameObject.Destroy(panelMax.GetComponent<Panels>().cards[index]);
        }
    }
    public static void RemoveMin(params object[] item)
    {
        if (item[0] is Player player)
        {
            GameObject panelMin = null; int index = 0;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject rowCard in row.GetComponent<Panels>().cards)
                {
                    if (panelMin == null && rowCard.GetComponent<CardDisplay>().card.IsUnity)
                    {
                        panelMin = row;
                        index = row.GetComponent<Panels>().cards.IndexOf(rowCard);
                    }

                    else if (int.Parse(rowCard.GetComponent<CardDisplay>().textPower.text) < int.Parse(panelMin.GetComponent<Panels>().cards[index].GetComponent<CardDisplay>().textPower.text))
                    {
                        panelMin = row;
                        index = row.GetComponent<Panels>().cards.IndexOf(rowCard);
                    }
                }
            }
            if (panelMin != null)
                GameObject.Destroy(panelMin.GetComponent<Panels>().cards[index]);
        }
    }
    public static void MultiplyPower(params object[] item)
    {
        if (item[0] is Player player && item[1] is GameObject card)
        {
            int counter = 0;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject cardRow in row.GetComponent<Panels>().cards)
                    if (card.name == cardRow.name)
                        counter++;
            }
            if(counter != 0)
                card.GetComponent<CardDisplay>().Delta(counter * int.Parse(card.GetComponent<CardDisplay>().textPower.text));
        }
    }
    public static void ReturnToHand(params object[] item)
    {

    }
    public static void ClimateOut(params object[] item)
    {

    }
}
