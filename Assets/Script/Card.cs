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
    // Campo
    public int power;
    public Sprite artWork;
    public Sprite portrait;
    public enum card_position { M, R, S, MR, MS, RS, MRS, I, C};
    public enum kind_card { golden, silver, climate, clear, bait, increase, leader };
    public kind_card typeCard;
    public card_position cardPosition;
    public bool IsHero;

    // Constructor
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
