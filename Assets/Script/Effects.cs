using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public static class Effects
{
    public static void Increase(params object[] item)       // Poner un aumento en una fila propia
    {
        if (item[0] is Player player)
        {
            for (int j = 0; j < 3; j++)
                if (player.increase[j].GetComponent<Panels>().cards.Count != 0)
                    for (int i = 0; i < player.field[j].GetComponent<Panels>().cards.Count; i++)
                        if (player.field[j].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player.field[j].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe && !player.field[j].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().IncreaseActive)
                            player.field[j].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(player.increase[j].GetComponent<Panels>().cards[0].GetComponent<CardDisplay>().card.power);
        }
    }   
    public static void Climate(params object[] item)        // Poner un clima
    {
        if (item[0] is Player player1 && item[1] is Player player2 && item[2] is int pos && item[3] is int delta)
        {
            for (int i = 0; i < player1.field[pos].GetComponent<Panels>().cards.Count; i++)
                if (player1.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player1.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe && !player1.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().ClimateActive)
                { player1.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(delta); player1.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().ClimateActive = true; }

            for (int i = 0; i < player2.field[pos].GetComponent<Panels>().cards.Count; i++)
                if (player2.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player2.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe && !player2.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().ClimateActive)
                { player2.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(delta); player2.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().ClimateActive = true; }
        }
    }   
    public static void RemoveMax(params object[] item)      // Eliminar la carta con mas poder del campo
    {
        if (item[0] is Player player)
        {
            GameObject panelMax = null; int index = 0;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject rowCard in row.GetComponent<Panels>().cards)
                {
                    if (panelMax == null && rowCard.GetComponent<CardDisplay>().card.IsUnity)
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
            if (panelMax != null)
                GameObject.Destroy(panelMax.GetComponent<Panels>().cards[index]);
        }
    }
    public static void RemoveMin(params object[] item)      // Eliminar la carta con menos poder del rival
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
    public static void TakeCard(params object[] item)       // Robar una carta
    {
        if (item[0] is Player player)
            player.TakeCard(1);
    }
    public static void MultiplyPower(params object[] item)  // Multiplica por n su ataque, siendo n la cantidad de cartas iguales a ella en el campo
    {
        if (item[0] is Player player && item[1] is CardDisplay card)
        {
            int counter = 0;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject cardRow in row.GetComponent<Panels>().cards)
                    if (card.card.name == cardRow.name)
                        counter++;
            }
            if (counter != 0)
                card.NewPower(counter * int.Parse(card.textPower.text));
        }
    }
    public static void ClearRow(params object[] item)       // Limpia la fila del campo (no vac´ıa, propia o del rival) con menos unidades
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
    public static void Average(params object[] item)        // Caclula el promedio de poder entre todas las cartas del campo. Luego lo iguala al poder de todas las cartas del campo
    {
        if (item[0] is Player player)
        {
            int counterUnity = 0;
            int sigmaUnity = 0;
            foreach (GameObject item2 in player.field)
            { sigmaUnity += item2.GetComponent<Panels>().PowerRow(); counterUnity += item2.GetComponent<Panels>().CounterUnity(); }

            foreach (GameObject item2 in player.field)
                for (int i = 0; i < item2.GetComponent<Panels>().cards.Count; i++)
                    item2.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().NewPower(sigmaUnity/counterUnity);
        }
    }
    public static void ReturnToHand(params object[] item)   // Efecto de Señuelo
    {

    }
    public static void ClimateOut(params object[] item)     // Despeja una carta Clima
    {
        if (item[0] is Player player && item[1] is int pos)
        {
            if (player.climate.GetComponent<Panels>().cards.Count != 0)
            {
                int delta = player.climate.GetComponent<Panels>().cards[0].GetComponent<CardDisplay>().card.power;
                for (int i = 0; i < player.field[pos].GetComponent<Panels>().cards.Count; i++)
                    if (player.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsUnity && !player.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHeroe)
                        player.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(delta);
                GameObject.Destroy(player.climate.GetComponent<Panels>().cards[0]);
            }
        }
    }  
    public static void JonSnow(params object[] item)
    {

    }
}
