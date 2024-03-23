
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
    public void OnPointerEnter(PointerEventData evenData)            // Se ejecuta cuando el puntero entra en el área del objeto
    {
        GameObject.Find("Panel_Card").transform.GetChild(2).GetComponent<Text>().text = "2";
    }
    public void OnPointerExit(PointerEventData evenData)            //  Se ejecuta cuando el puntero sale del área del objeto.
    {

    }
    public void OnDrop(PointerEventData evenData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        Drag item = evenData.pointerDrag.GetComponent<Drag>();
        if (item != null && this.GetComponent<Panels>().itemsCounter < this.GetComponent<Panels>().maxItems && CardPosition(this, evenData.pointerDrag))             // Si el objeto tiene un componente Drag, establece el padre del objeto arrastrado al objeto actual
        {
            item.parent = this.transform;
            this.GetComponent<Panels>().itemsCounter++;
            this.GetComponent<Panels>().cards.Add(evenData.pointerDrag);
        }                                        
            
    }
}
