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
            {
                Panels panel = player.increase[j].GetComponent<Panels>();
                if (panel.cards.Count != 0)
                {
                    for (int i = 0; i < player.field[j].GetComponent<Panels>().cards.Count; i++)
                    {
                        CardDisplay thisCard = player.field[j].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>();
                        if (thisCard.card.isUnity && !thisCard.card.isHeroe && !thisCard.increaseActive)
                            thisCard.PowerDelta(panel.cards[0].GetComponent<CardDisplay>().Power());
                    }
                }
            }
        }
    }   
    public static void Climate(params object[] item)        // Afectan una o varias filas simultaneamente para ambos jugadores
    {
        if (item[0] is Player player1 && item[1] is Player player2 && item[2] is int affectedRow && item[3] is int harm)
        {
            for (int i = 0; i < player1.field[affectedRow].GetComponent<Panels>().cards.Count; i++)
            {
                CardDisplay thisCard = player1.field[affectedRow].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>();
                if (thisCard.card.isUnity && !thisCard.card.isHeroe && !thisCard.climateActive)
                    thisCard.PowerDelta(harm); thisCard.climateActive = true;
            }

            for (int i = 0; i < player2.field[affectedRow].GetComponent<Panels>().cards.Count; i++)
            {
                CardDisplay thisCard = player2.field[affectedRow].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>();
                if (thisCard.card.isUnity && !thisCard.card.isHeroe && !thisCard.climateActive)
                    thisCard.PowerDelta(harm); thisCard.climateActive = true;
            }
        }
    }   
    public static void RemoveMax(params object[] item)      // Eliminar la carta con más poder del campo
    {
        if (item[0] is Player player)
        {
            GameObject cardMax = null;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject thisCard in row.GetComponent<Panels>().cards)
                {
                    if (thisCard.GetComponent<CardDisplay>().card.isUnity)
                    {
                        if (cardMax == null)
                            cardMax = thisCard;

                        else if (thisCard.GetComponent<CardDisplay>().Power() > cardMax.GetComponent<CardDisplay>().Power())
                            cardMax = thisCard;
                    }
                }
            }
            if (cardMax != null)
                GameObject.Destroy(cardMax);
        }
    }
    public static void RemoveMin(params object[] item)      // Eliminar la carta con menos poder del rival
    {
        if (item[0] is Player player)
        {
            GameObject cardMax = null;
            foreach (GameObject row in player.field)
            {
                foreach (GameObject thisCard in row.GetComponent<Panels>().cards)
                {
                    if (thisCard.GetComponent<CardDisplay>().card.isUnity)
                    {
                        if (cardMax == null)
                            cardMax = thisCard;

                        else if (thisCard.GetComponent<CardDisplay>().Power() < cardMax.GetComponent<CardDisplay>().Power())
                            cardMax = thisCard;
                    }
                }
            }
            if (cardMax != null)
                GameObject.Destroy(cardMax);
        }
    }
    public static void DrawCard(params object[] item)       // Robar una carta
    {
        if (item[0] is Player player)
            player.TakeCard(1);
    } 
    public static void MultiplyPower(params object[] item)  // Multiplica por n su ataque, siendo n la cantidad de cartas iguales a ella en el campo
    {
        if (item[0] is Player player && item[1] is CardDisplay cardEffect)
        {
            int counter = 0;
            foreach (GameObject row in player.field)  
                foreach (GameObject thisCard in row.GetComponent<Panels>().cards)
                    if (cardEffect.name == thisCard.name)
                        counter++;
            if (counter != 0)
                cardEffect.NewPower((counter) * cardEffect.Power());
        }
    }
    public static void ClearRow(params object[] item)       // Limpia la fila del campo (propia o del rival) con menos unidades
    {
        if (item[0] is Player player)
        {
            Panels minRow = null;
            foreach (GameObject row in player.field)
            {
                Panels panelRow = row.GetComponent<Panels>();
                if (panelRow.CounterUnity() > 0)
                    if((minRow == null) || (panelRow.CounterUnity() < minRow.CounterUnity()))
                        minRow = panelRow;
            }
            if(minRow != null)
                minRow.RemoveAll();
        }
    }
    public static void Average(params object[] item)        // Caclula el promedio de poder entre todas las cartas del campo. Luego lo iguala al poder de todas las cartas del campo
    {
        if (item[0] is Player player)
        {
            int counterUnity = 0;
            int sigmaUnity = 0;
            foreach (GameObject row in player.field) 
            { 
                sigmaUnity += row.GetComponent<Panels>().PowerRow(); 
                counterUnity += row.GetComponent<Panels>().CounterUnity();
            }

            foreach (GameObject row in player.field)  
                for (int i = 0; i < row.GetComponent<Panels>().cards.Count; i++)
                    row.GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().NewPower(sigmaUnity/counterUnity);
        }
    }
    public static void ReturnToHand(params object[] item)   // Efecto de Señuelo
    {

    }
    public static void ClimateOut(params object[] item)     // Despeja una carta Clima
    {
        if (item[0] is Player player)
        {
            int pos = player.climate.GetComponent<Panels>().cards[0].GetComponent<CardDisplay>().card.affectedRow;
            if (player.climate.GetComponent<Panels>().cards.Count != 0)
            {
                int delta = player.climate.GetComponent<Panels>().cards[0].GetComponent<CardDisplay>().card.power;
                for (int i = 0; i < player.field[pos].GetComponent<Panels>().cards.Count; i++)
                    if (player.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.isUnity && !player.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.isHeroe)
                        player.field[pos].GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().PowerDelta(delta);
                GameObject.Destroy(player.climate.GetComponent<Panels>().cards[0]);
            }
        }
    }  
    public static void JonSnow(params object[] item)        // Efecto del líder(Jon Snow)
    {
        if (item[0] is Player player)
        {

        }
    }
    public static void Daenerys(params object[] item)       // Efecto del líder(Daenerys)
    {
        if (item[0] is Player player)
        {
            
        }
    }
    public static void NightKing(params object[] item)      // Efecto del líder(ReyNoche)
    {
        if (item[0] is Player player)
        {

        }
    }
}
