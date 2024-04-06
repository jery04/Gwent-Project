using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    // Propiedades (Campo)
    public int power;                                                                   // Poder
    public Sprite artWork;                                                              // Imagen principal
    public Sprite portrait;                                                             // Imagen del marco
    public enum card_position { M, R, S, MR, MS, RS, MRS, I, C};                        // Posiciones en que se puede ubicar
    public enum kind_card { golden, silver, climate, clear, bait, increase, leader };   // Tipos de carta
    public kind_card typeCard;                                                          // Tipo de carta
    public card_position cardPosition;                                                  // Tipo de posición
    public bool IsHero;

    // Constructores (Sobrecargado)
    public Card(int power, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard)
    {
        this.typeCard = typeCard;
        this.IsHero = IsHeroe;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }
    public Card(int power, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition)
    {
        this.IsHero = IsHeroe;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }
}
