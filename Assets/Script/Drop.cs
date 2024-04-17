
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private void ActiveEffect(CardDisplay item)                                     // Activa el efecto según la carta
    {
        Player player1 = GameObject.Find("GameManager").GetComponent<GameManager>().player1;
        Player player2 = GameObject.Find("GameManager").GetComponent<GameManager>().player2;

        if (item.card.typeCard == Card.kind_card.climate)
        {
            item.card.affectedRow = Random.Range(0, 3);
            item.card.effect(player1, player2, item.card.affectedRow, item.card.power);
        }
        else if (item.card.typeCard == Card.kind_card.increase || item.card.typeCard == Card.kind_card.bait)
        {
            item.card.effect(GameManager.currentPlayer);
        }
        else if (item.card.typeCard == Card.kind_card.clear)
        {
            item.card.effect(GameManager.currentPlayer, item.card.affectedRow);
        }
        else if (item.card.name == "Sansa" || item.card.name == "Theon" || item.card.name == "Arya" || item.card.name == "Mag Mar" || item.card.name == "Beric" || item.card.name == "Eddard")
        {
            item.card.effect(GameManager.currentPlayer);
        }
        else if (item.card.name == "Kristofer")
        {
            if(player1.myTurn)
                item.card.effect(player2);
            else item.card.effect(player1);
        }
        else if (item.card.name == "La Guardia" || item.card.name == "Garra")
        {
            item.card.effect(GameManager.currentPlayer, item);
        }
    }
    private bool CardPosition(Drop item, GameObject item2)                          // Verifica que la posición de la carta coincida con la del panel
    {
        foreach (Card.card_position i in item.GetComponent<Panels>().position)
        {
            if (i == item2.GetComponent<CardDisplay>().cardPosition)
                return true;
        }
        return false;
    }
    public void OnPointerEnter(PointerEventData eventData)                          // Se ejecuta cuando el puntero entra en el área del objeto
    {

    }
    public void OnPointerExit(PointerEventData eventData)                           // Se ejecuta cuando el puntero sale del área del objeto.
    {

    }
    public void OnDrop(PointerEventData eventData)                                  // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        Drag item = eventData.pointerDrag.GetComponent<Drag>();                     // Almacena el Componente Darg de la carta

        // Si el objeto tiene un componente Drag, coinciden las posiciones y cabe en la fila establece el padre del objeto arrastrado al objeto actual
        if (item != null && this.GetComponent<Panels>().itemsCounter < this.GetComponent<Panels>().maxItems && CardPosition(this, eventData.pointerDrag))
        {   
            item.parent = this.transform;                                           // Cambia el padre de la carta en la jerarquía
            GameManager.currentPlayer.hand.GetComponent<Panels>().cards.Remove(eventData.pointerDrag);  // Elimina la carta de la mano del jugador
            this.GetComponent<Panels>().cards.Add(eventData.pointerDrag);           // Adiciona la carta al panel donde es colocada (List)
            GameManager.currentPlayer.oneMove = true;                               // Indica que el jugador ha realizado un movimiento
            eventData.pointerDrag.GetComponent<CardDisplay>().card.ActiveClip();    // Activa el AudioClip de la carta 

            if (eventData.pointerDrag.GetComponent<CardDisplay>().card.effect != null)
                ActiveEffect(eventData.pointerDrag.GetComponent<CardDisplay>());    // Activa el efecto de la carta
        }                                               
    }
}
