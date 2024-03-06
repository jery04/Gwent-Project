//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
//{
//    public void OnPointerEnter(PointerEventData evenData)
//    {
//        //Debug.Log("OnPointerEnter");
//    }
//    public void OnPointerExit(PointerEventData evenData)
//    {
//        //Debug.Log("OnPointerExit");
//    }
//    public void OnDrop(PointerEventData evenData)
//    {
//        Debug.Log(evenData.pointerDrag.name + " was dropped on " + gameObject.name);
//        Drag item = evenData.pointerDrag.GetComponent<Drag>();
//        if (item != null)
//            item.parent = this.transform;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
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
        if (item != null)                                           // Si el objeto arrastrado tiene un componente Drag, establece el padre del objeto arrastrado al objeto actual
            item.parent = this.transform;
    }
}
