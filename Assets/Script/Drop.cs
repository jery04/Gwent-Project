
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData evenData)            // Se ejecuta cuando el puntero entra en el área del objeto
    {
        //Debug.Log("OnPointerEnter"); Pruebas en Consola
    }
    public void OnPointerExit(PointerEventData evenData)            //  Se ejecuta cuando el puntero sale del área del objeto.
    {
        //Debug.Log("OnPointerExit"); Pruebas en Consola
    }
    public void OnDrop(PointerEventData evenData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        Drag item = evenData.pointerDrag.GetComponent<Drag>();
        if (item != null && this.GetComponent<Panels>().itemsCounter < this.GetComponent<Panels>().maxItems && this.GetComponent<Panels>().cardPosition == evenData.pointerDrag.GetComponent<CardDisplay>().cardPosition)             // Si el objeto tiene un componente Drag, establece el padre del objeto arrastrado al objeto actual
        {
            item.parent = this.transform;
            this.GetComponent<Panels>().itemsCounter++;
            this.GetComponent<Panels>().cards.Add(evenData.pointerDrag);
        }                                        
            
    }
}
