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

    // Start is called before the first frame update

    private void InstantiateCard(string handName)
    {
        GameObject prefarb = Resources.Load<GameObject>("Card");
        int rand = Random.Range(1, 25);

        GameObject a = Instantiate(prefarb, GameObject.Find(handName).transform);
        a.GetComponent<CardDisplay>().card = dataCard.deckDemon[rand];
        a.GetComponent<Image>().sprite = dataCard.deckDemon[rand].artWork;
        a.transform.GetChild(0).GetComponent<Image>().sprite = dataCard.deckDemon[rand].portrait;
        a.transform.GetChild(1).GetComponent<Text>().text = dataCard.deckDemon[rand].power.ToString();

        cartas.Add(a);
        GameObject.Find(handName).GetComponent<Panels>().cards.Add(a);
    }
    public void Take(string handName)
    {
        int numChild = GameObject.Find(handName).transform.childCount;
        //dataCard.CreateCard();

        if (numChild == 0)
        {
            for (int i = 0; i < 10; i++)
                InstantiateCard(handName);
        }
        else if ((numChild != 0) && (numChild < 10))
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

    void Start()
    {
        dataCard.CreateCard();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
