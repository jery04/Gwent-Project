using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class DropCard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private string Position(Card.card_position pos)                 // Retorna cadena string con la posición de la carta
    {
        switch (pos)
        {
            case Card.card_position.M:
                return "melee";
            case Card.card_position.R:
                return "range";
            case Card.card_position.S:
                return "siege";
            case Card.card_position.MR:
                return "melee-range";
            case Card.card_position.MS:
                return "melee-siege";
            case Card.card_position.MRS:
                return "Mel-Ran-Sie";
            case Card.card_position.RS:
                return "range-siege";
            default:
                return "";
        }
    }
    private string KindCard(Card.kind_card kind)                    // Retorna cadena string con el tipo de carta
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
                return "increase";
            case Card.kind_card.leader:
                return "Leader";
        }
        return "";
    }
    public void OnPointerEnter(PointerEventData evenData)           // Se ejecuta cuando el puntero entra en el área del objeto
    {
        // Enviar la información de la carta el Panel de Datos
        if (this != null && !this.GetComponent<CardDisplay>().backImage.enabled)
        {
             GameObject.Find("Panel_Card").transform.GetChild(3).GetComponent<Text>().text = this.name;                                                // Name
             GameObject.Find("Panel_Card").transform.GetChild(5).GetComponent<Text>().text = this.GetComponent<CardDisplay>().card.faction;            // Facción
             GameObject.Find("Panel_Card").transform.GetChild(7).GetComponent<Text>().text = this.GetComponent<CardDisplay>().textPower.text;          // Power
             GameObject.Find("Panel_Card").transform.GetChild(9).GetComponent<Text>().text = KindCard(this.GetComponent<CardDisplay>().type_Card);     // Tipo de carta
             GameObject.Find("Panel_Card").transform.GetChild(11).GetComponent<Text>().text = Position(this.GetComponent<CardDisplay>().cardPosition); // Posición
             GameObject.Find("Panel_Card").transform.GetChild(13).GetComponent<Text>().text = this.GetComponent<CardDisplay>().card.description;       // descripción
             GameObject.Find("Panel_Card").transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().artWork.sprite;
             GameObject.Find("Panel_Card").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().portrait.sprite;
        }
    }
    public void OnPointerExit(PointerEventData evenData)            // Se ejecuta cuando el puntero sale del área del objeto.
    {
        if (this != null)                                           // Limpiar(vaciar datos) el Panel de Datos
        {
             GameObject.Find("Panel_Card").transform.GetChild(3).GetComponent<Text>().text = "";   // Name
             GameObject.Find("Panel_Card").transform.GetChild(7).GetComponent<Text>().text = "";   // Power
             GameObject.Find("Panel_Card").transform.GetChild(5).GetComponent<Text>().text = "";   // Facción
             GameObject.Find("Panel_Card").transform.GetChild(9).GetComponent<Text>().text = "";   // Tipo de carta
             GameObject.Find("Panel_Card").transform.GetChild(11).GetComponent<Text>().text = "";  // Posición
             GameObject.Find("Panel_Card").transform.GetChild(13).GetComponent<Text>().text = "";  // Descripción
             GameObject.Find("Panel_Card").transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().artWork.sprite;
             GameObject.Find("Panel_Card").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Panel");
        }
    }
    public void OnDrop(PointerEventData evenData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
    
    }
}
