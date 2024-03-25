using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropCard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData evenData)            // Se ejecuta cuando el puntero entra en el área del objeto
    {
        if (this != null)
        {
            GameObject.Find("Panel_Card").transform.GetChild(2).GetComponent<Text>().text = this.GetComponent<CardDisplay>().textPower.text;
            GameObject.Find("Panel_Card").transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().card.artWork;
            GameObject.Find("Panel_Card").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = this.GetComponent<CardDisplay>().card.portrait;
        }
        
    }
    public void OnPointerExit(PointerEventData evenData)            //  Se ejecuta cuando el puntero sale del área del objeto.
    {
        GameObject.Find("Panel_Card").transform.GetChild(2).GetComponent<Text>().text = "";
        GameObject.Find("Panel_Card").transform.GetChild(0).GetComponent<Image>().sprite = null;
        GameObject.Find("Panel_Card").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = null;
    }
    public void OnDrop(PointerEventData evenData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
    
    }
}
