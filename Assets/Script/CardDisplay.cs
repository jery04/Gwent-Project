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
    public kind_card type_Card;
    public kind_cardUnity type_Unity;

    void Start()
    {
        type_Card = card.typeCard;
        type_Unity = card.typeUnity;
        textPower.text = card.power.ToString();
        artWork.sprite = card.artWork;
        portrait.sprite = card.portrait;
    }

}
