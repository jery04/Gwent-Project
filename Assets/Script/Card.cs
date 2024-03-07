using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public GameObject child;
    public int power;
    public Sprite artWork;
    public Sprite portrait;
    //public enum kind_cardUnity { M, R, S, MR, MS, RS, MRS };
    //public enum kind_card { golden, silver, climate, clear, lure };
    //public kind_card card;
    //public kind_cardUnity unity;
}
