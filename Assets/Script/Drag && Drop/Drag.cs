
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parent = null;                                  // Almacena un objeto arrastrable de tipo Transform

    public void OnBeginDrag(PointerEventData evenData)              // se ejecuta cuando se comienza a arrastrar el objeto.
    {
        parent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);     // Traslada al objeto por la jerarqu�a de objetos.
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)                  // Se ejecuta mientras el objeto est� siendo arrastrado
    {
        this.transform.position = eventData.position;               // Actualiza la posici�n del objeto a la posici�n actual del puntero
    }
    public void OnEndDrag(PointerEventData eventData)               // Se ejecuta al finalizar el arrastre
    {
        this.transform.SetParent(parent);                           // Se cambia de padre en la jerarqu�a de objetos
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
