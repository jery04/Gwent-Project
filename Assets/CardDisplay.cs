using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text textPower;
    public Image artwork;
    public Image portrait;


    void Start()
    {
        textPower.text = card.power.ToString();
        artwork.sprite = card.artwork;
        portrait.sprite = card.portrait;
    }

}
