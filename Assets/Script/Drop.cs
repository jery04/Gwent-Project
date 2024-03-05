using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData evenData)
    {
        //Debug.Log("OnPointerEnter");
    }
    public void OnPointerExit(PointerEventData evenData)
    {
        //Debug.Log("OnPointerExit");
    }
    public void OnDrop(PointerEventData evenData)
    {
        Debug.Log(evenData.pointerDrag.name + " was dropped on " + gameObject.name);
        Drag item = evenData.pointerDrag.GetComponent<Drag>();
        if (item != null)
            item.parent = this.transform;
    }
}
