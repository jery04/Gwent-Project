using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class DropCard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private string Position(Card.card_position pos)
    {
        switch (pos)
        {
            case Card.card_position.M:
                return "Melee";
            case Card.card_position.R:
                return "Range";
            case Card.card_position.S:
                return "Siege";
            case Card.card_position.MR:
                return "Melee-Range";
            case Card.card_position.MS:
                return "Melee-Siege";
            case Card.card_position.MRS:
                return "Mel-Ran-Sie";
            case Card.card_position.RS:
                return "Range-Siege";
        }
        return "";
    }
    private string KindCard(Card.kind_card kind)
    {
        switch (kind)
        {
            case Card.kind_card.golden:
                return "Golden";
            case Card.kind_card.silver:
                return "Silver";
            case Card.kind_card.climate:
                return "Climate";
            case Card.kind_card.clear:
                return "Clear";
            case Card.kind_card.bait:
                return "Bait";
            case Card.kind_card.increase:
                return "Increase";
            case Card.kind_card.leader:
                return "Leader";
        }
        return "";
    }
    public void OnPointerEnter(PointerEventData evenData)            // Se ejecuta cuando el puntero entra en el área del objeto
    {

        if (this != null && !this.GetComponent<CardDisplay>().Back.enabled)
        {
            GameObject.Find("Panel_Card").transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().card.artWork;
            GameObject.Find("Panel_Card").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().card.portrait;
            GameObject.Find("Panel_Card").transform.GetChild(2).GetComponent<Text>().text = this.GetComponent<CardDisplay>().textPower.text;   
            GameObject.Find("Panel_Card").transform.GetChild(4).GetComponent<Text>().text = KindCard(this.GetComponent<CardDisplay>().type_Card);
            GameObject.Find("Panel_Card").transform.GetChild(6).GetComponent<Text>().text = Position(this.GetComponent<CardDisplay>().cardPosition);
        }

    }
    public void OnPointerExit(PointerEventData evenData)            //  Se ejecuta cuando el puntero sale del área del objeto.
    {
        if (this != null)
        {
            GameObject.Find("Panel_Card").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Panel");
            GameObject.Find("Panel_Card").transform.GetChild(2).GetComponent<Text>().text = "";
            GameObject.Find("Panel_Card").transform.GetChild(4).GetComponent<Text>().text = "";
            GameObject.Find("Panel_Card").transform.GetChild(6).GetComponent<Text>().text = "";
        }
    }
    public void OnDrop(PointerEventData evenData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
    
    }
}
