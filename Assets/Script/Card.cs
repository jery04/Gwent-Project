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
    public enum kind_cardUnity { M, R, S, MR, MS, RS, MRS };
    public enum kind_card { golden, silver, climate, clear, lure };
    public kind_card typeCard;
    public kind_cardUnity typeUnity;
    bool IsHero;
    bool IsLeader;

    // Constructor
    public Card(int power, Sprite artWork, Sprite portrait)
    {
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }

    //Métodos
    public void Delta(int delta) => power += delta; 

}
