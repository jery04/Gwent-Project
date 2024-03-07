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

    //public Transform parentObject;
    void Start()
    {
        
        //textPower.transform.SetParent(parentObject, false);
        //artWork.transform.SetParent(parentObject, false);
        //portrait.transform.SetParent(parentObject, false);

        //card.child.transform.SetParent();
        textPower.text = card.power.ToString();
        artWork.sprite = card.artWork;
        portrait.sprite = card.portrait;
    }

}