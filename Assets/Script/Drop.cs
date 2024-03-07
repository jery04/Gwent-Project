
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    int countMaxObject = 0;
    int maxObject = 5;
    
    public void OnPointerEnter(PointerEventData evenData)            // Se ejecuta cuando el puntero entra en el área del objeto
    {
        // Debug.Log("OnPointerEnter"); Pruebas en Consola
    }
    public void OnPointerExit(PointerEventData evenData)            //  Se ejecuta cuando el puntero sale del área del objeto.
    {
        //Debug.Log("OnPointerExit"); Pruebas en Consola
    }
    public void OnDrop(PointerEventData evenData)                   // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        // Debug.Log(evenData.pointerDrag.name + " was dropped on " + gameObject.name);  Pruebas en Consola
        Drag item = evenData.pointerDrag.GetComponent<Drag>();
        if (item != null && countMaxObject < maxObject)
        {
            item.parent = this.transform;
            countMaxObject++;
            Debug.Log(countMaxObject);
        }                                        // Si el objeto arrastrado tiene un componente Drag, establece el padre del objeto arrastrado al objeto actual
            
    }
}
