using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    List<GameObject> cartas = new List<GameObject>();
    DataBase dataCard = new DataBase();

    private void InstantiateCard(string handName)
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        int rand = Random.Range(1, 25);

        GameObject a = Instantiate(prefarb, GameObject.Find(handName).transform);
        a.GetComponent<CardDisplay>().card = dataCard.deckDemon[rand];
        //a.GetComponent<Image>().sprite = dataCard.deckDemon[rand].artWork;
        //a.transform.GetChild(0).GetComponent<Image>().sprite = dataCard.deckDemon[rand].portrait;
        //a.transform.GetChild(1).GetComponent<Text>().text = dataCard.deckDemon[rand].power.ToString();

        cartas.Add(a);
        GameObject.Find(handName).GetComponent<Panels>().cards.Add(a);
    }
    public void Take(string handName)                       // Tomar cartas del deck
    {
        int numChild = GameObject.Find(handName).transform.childCount;

        if (numChild == 0)                                 // Tomar 10 iniciales 
        {
            for (int i = 0; i < 10; i++)
                InstantiateCard(handName);
        }
        else if ((numChild != 0) && (numChild < 10))      // Tomar 2 cartas
        {
            if (10 - numChild <= 2)
            {
                for (int i = 0; i < (10 - numChild); i++)
                    InstantiateCard(handName);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                    InstantiateCard(handName);
            }
        }
    }

    public void ModifiedRow(string nameRow, int delta)
    {
        for (int i = 0; i < GameObject.Find(nameRow).GetComponent<Panels>().itemsCounter; i++)
            if (GameObject.Find(nameRow).GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().card.IsHero)
                GameObject.Find(nameRow).GetComponent<Panels>().cards[i].GetComponent<CardDisplay>().Delta(delta);   
    }
    public int GeneralPower()      // Devuelve la puntuacion del jugador al finalizar la ronda
    {
        int generalPower = 0;
        foreach(GameObject item in GameObject.Find("Melee").GetComponent<Panels>().cards)   // Acumulado de Melee
            generalPower += item.GetComponent<CardDisplay>().card.power;

        foreach (GameObject item in GameObject.Find("Range").GetComponent<Panels>().cards)  // Acumulado de Range
            generalPower += item.GetComponent<CardDisplay>().card.power;

        foreach (GameObject item in GameObject.Find("Siege").GetComponent<Panels>().cards)  // Acumulado de Siege
            generalPower += item.GetComponent<CardDisplay>().card.power;

        return generalPower;
    }
    void Start()
    {
        dataCard.CreateCard();                          // Crea las instancias de las cartas
    }

    void Update()
    {

    }
}
