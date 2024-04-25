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
    public Card card;                               // Almacena la carta    
    public Text textPower;                          // El poder (int)
    public Image artWork;                           // La imagen de la carta
    public Image portrait;                          // La imagen del marco
    public Image backImage;                         // La parte posterior de la imagen
    public kind_card type_Card;                     // El tipo de carta
    public card_position cardPosition;              // El tipo de carta

    public int Power() => Convert.ToInt32(textPower.text);                                                   // Retorna su poder
    public void NewPower(int delta) => textPower.text = delta.ToString();                                    // Coloca un nuevo poder
    public void PowerDelta(int delta) => textPower.text = (int.Parse(textPower.text) + delta).ToString();    // Variar su poder (Aumentar-Disminuir)
    void Start()                                    // Inicializa propiedades
    {
        if(card != null)
        {
            type_Card = card.typeCard;
            cardPosition = card.cardPosition;
            textPower.text = card.power.ToString();
            artWork.sprite = card.artWork;
            portrait.sprite = card.portrait;
            textPower.enabled = false;
        }
    }
    void Update()                                   // Actualiza propiedades
    {
        if (card != null)                           // Actualiza el poder
            textPower.text = textPower.text;    
    }
}
