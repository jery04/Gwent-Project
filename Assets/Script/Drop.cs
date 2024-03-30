
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool CardPosition(Drop item, GameObject item2)
    {
        foreach (Card.card_position i in item.GetComponent<Panels>().cardPos)
        {
            if (i == item2.GetComponent<CardDisplay>().cardPosition)
                return true;
        }
        return false;
    }
    public void OnPointerEnter(PointerEventData eventData)            // Se ejecuta cuando el puntero entra en el área del objeto
    {

    }
    public void OnPointerExit(PointerEventData eventData)            //  Se ejecuta cuando el puntero sale del área del objeto.
    {

    }
    public void OnDrop(PointerEventData eventData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        Drag item = eventData.pointerDrag.GetComponent<Drag>();
 
        if (item != null && this.GetComponent<Panels>().itemsCounter < this.GetComponent<Panels>().maxItems && CardPosition(this, eventData.pointerDrag))             // Si el objeto tiene un componente Drag, coinciden las posiciones y cabe en la fila establece el padre del objeto arrastrado al objeto actual
        {
            item.parent = this.transform;                            // Cambia el padre
            this.GetComponent<Panels>().cards.Add(eventData.pointerDrag);
            GameObject.Find(GameManager.currentPlayer.handName).GetComponent<Panels>().cards.Remove(eventData.pointerDrag);
            GameManager.currentPlayer.oneMove = true;
        }                                               
    }
}
