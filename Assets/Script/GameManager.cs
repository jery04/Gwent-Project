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


    // Start is called before the first frame update

    public void TakeDemons(string nameDeck)
    {
        int numChild = GameObject.Find("Hand").transform.childCount;
        if ( numChild == 0 )
        {
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range(1, 25);
                GameObject.Find(nameDeck).transform.GetChild(rand).transform.SetParent(GameObject.Find("Hand").transform);
            }
        }
        else if((numChild != 0) && (numChild < 10))
        {
            if(10 - numChild <= 2)
            {
                for (int i = 0; i < (10 - numChild); i++)
                {
                    int rand = Random.Range(1, 25);
                    GameObject.Find(nameDeck).transform.GetChild(rand).transform.SetParent(GameObject.Find("Hand").transform);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int rand = Random.Range(1, 25);
                    GameObject.Find(nameDeck).transform.GetChild(rand).transform.SetParent(GameObject.Find("Hand").transform);
                }
            }
        }
    }
    public void TakeHeavenly(string nameDeck)
    {
        int numChild = GameObject.Find("Hand (2)").transform.childCount;
        if (numChild == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range(1, 25);
                GameObject.Find(nameDeck).transform.GetChild(rand).transform.SetParent(GameObject.Find("Hand (2)").transform);
            }
        }
        else if ((numChild != 0) && (numChild < 10))
        {
            if (10 - numChild <= 2)
            {
                for (int i = 0; i < (10 - numChild); i++)
                {
                    int rand = Random.Range(1, 25);
                    GameObject.Find(nameDeck).transform.GetChild(rand).transform.SetParent(GameObject.Find("Hand (2)").transform);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int rand = Random.Range(1, 25);
                    GameObject.Find(nameDeck).transform.GetChild(rand).transform.SetParent(GameObject.Find("Hand (2)").transform);
                }
            }
        }
    }
    void Start()
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        DataBase dataCard = new DataBase();
        dataCard.CreateCard();
        
        for (int i = 1; i < 25; i++)
        {
            GameObject a = Instantiate(prefarb, GameObject.Find("Deck").transform);
            a.GetComponent<CardDisplay>().card = dataCard.deckDemon[i];
            a.GetComponent<Image>().sprite = dataCard.deckDemon[i].artWork;
            a.transform.GetChild(0).GetComponent<Image>().sprite = dataCard.deckDemon[i].portrait;
            a.transform.GetChild(1).GetComponent<Text>().text = dataCard.deckDemon[i].power.ToString();
            cartas.Add(a);
            GameObject.Find("Deck").GetComponent<Panels>().cards.Add(a);
        }

        for (int i = 1; i < 25; i++)
        {
            GameObject a = Instantiate(prefarb, GameObject.Find("Deck (2)").transform);
            a.GetComponent<CardDisplay>().card = dataCard.deckHeavenly[i];
            a.GetComponent<Image>().sprite = dataCard.deckHeavenly[i].artWork;
            a.transform.GetChild(0).GetComponent<Image>().sprite = dataCard.deckHeavenly[i].portrait;
            a.transform.GetChild(1).GetComponent<Text>().text = dataCard.deckHeavenly[i].power.ToString();
            cartas.Add(a);
            GameObject.Find("Deck (2)").GetComponent<Panels>().cards.Add(a);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
