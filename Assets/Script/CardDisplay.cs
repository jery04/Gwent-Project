using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text textPower;
    public Image artWork;
    public Image portrait;

    void Start()
    {
        textPower.text = card.power.ToString();
        artWork.sprite = card.artWork;
        portrait.sprite = card.portrait;
    }

}
