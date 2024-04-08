using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using static Card;

public class CardDisplay : MonoBehaviour
{
    public Card card;                      // Almacena la carta    
    public Text textPower;                 // El poder (int)
    public Image artWork;                  // La imagen de la carta
    public Image portrait;                 // La imagen del marco
    public Image Back;                     // La parte posterior de la imagen
    public kind_card type_Card;            // El tipo de carta
    public card_position cardPosition;     // El tipo de carta

    public void Delta(int delta) => textPower.text = (int.Parse(textPower.text) + delta).ToString();    // Variar su poder (Aumentar-Disminuir)
    void Start()                           //Inicializador de parámetros
    {
        type_Card = card.typeCard;             
        cardPosition = card.cardPosition;
        textPower.text = card.power.ToString();
        artWork.sprite = card.artWork;
        portrait.sprite = card.portrait;
    }
    void Update()
    {
        if (card != null) textPower.text = textPower.text;      // Actualiza el poder
    }
}
