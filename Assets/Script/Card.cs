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
    public string id;
    public int power;
    public Sprite artWork;
    public Sprite portrait;
    public enum card_position { M, R, S, MR, MS, RS, MRS };
    public enum kind_card { golden, silver, climate, clear, bait, increase };
    public kind_card typeCard;
    public card_position cardPosition;
    bool IsHero;
    bool IsLeader;

    // Constructor
    public Card(int power, Sprite artWork, Sprite portrait)
    {
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }
    public Card(int power, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition)
    {
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }
    public Card(int power, Sprite artWork, Sprite portrait, kind_card typeCard)
    {
        this.typeCard = typeCard;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }

    //Métodos
    public void Delta(int delta) => power += delta; 

}
