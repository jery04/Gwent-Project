using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        DataBase dataCard = new DataBase();
        GameObject prefarb = Resources.Load<GameObject>("Card");
        Card cartaPrueba = new Card(8, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.M);

        GameObject b = Instantiate(prefarb, GameObject.Find("Hand").transform);
        b.AddComponent<CardDisplay>();
        b.GetComponent<CardDisplay>().card = cartaPrueba;
        b.AddComponent<Drag>();
        b.AddComponent<CanvasGroup>();
        b.AddComponent<LayoutElement>();
        b.GetComponent<CardDisplay>().artWork.sprite = cartaPrueba.artWork;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
