using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using static Card;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text textPower;
    public Image artWork;
    public Image portrait;
    public Image Back;
    public kind_card type_Card;
    public card_position cardPosition;

    public void Delta(int delta) => textPower.text = (int.Parse(textPower.text) + delta).ToString();
    void Start()
    {
        type_Card = card.typeCard; 
        cardPosition = card.cardPosition;
        textPower.text = card.power.ToString();
        artWork.sprite = card.artWork;
        portrait.sprite = card.portrait;
    }
    private void Update()
    {
        if (card != null)
        {
            textPower.text = textPower.text;
            //if (Convert.ToInt32(textPower.text) < 0)
            //    this.transform.SetParent(GameObject.Find("Cementery").transform);
        }
    }
}
