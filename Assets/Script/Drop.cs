
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private void ActiveEffect(CardDisplay item)
    {
        Player player1 = GameObject.Find("GameManager").GetComponent<GameManager>().player1;
        Player player2 = GameObject.Find("GameManager").GetComponent<GameManager>().player2;
        if (item.card.typeCard == Card.kind_card.climate)
        {
            item.card.effect(player1, player2, 0, item.card.power);
        }
        else if (item.card.typeCard == Card.kind_card.increase)
        {
            item.card.effect(GameManager.currentPlayer);
        }
        else if (item.card.typeCard == Card.kind_card.clear)
        {
            item.card.effect(GameManager.currentPlayer);
        }
        else if (item.card.name == "7" || item.card.name == "12")
        {
            item.card.effect(GameManager.currentPlayer);
        }

        else if (item.card.name == "8" || item.card.name == "10")
        {
            item.card.effect(GameManager.currentPlayer, item);
        }
        else if (item.card.name == "11")
        {
            item.card.effect(GameManager.currentPlayer, 0);
        }
        else if (item.card.name == "16")
        {
            item.card.effect(GameManager.currentPlayer);
        }
        else if (item.card.name == "13")
        {
            if(player1.myTurn)
                item.card.effect(player2);
            else item.card.effect(player1);
        }
        else if (item.card.name == "14")
        {
            item.card.effect(GameManager.currentPlayer);
        }
        else if (item.card.name == "17")
        {
            item.card.effect(GameManager.currentPlayer);
        }
    }
    private bool CardPosition(Drop item, GameObject item2)          // Verifica que la posición de la carta coincida con la del panel
    {
        foreach (Card.card_position i in item.GetComponent<Panels>().position)
        {
            if (i == item2.GetComponent<CardDisplay>().cardPosition)
                return true;
        }
        return false;
    }
    public void OnPointerEnter(PointerEventData eventData)          // Se ejecuta cuando el puntero entra en el área del objeto
    {

    }
    public void OnPointerExit(PointerEventData eventData)           //  Se ejecuta cuando el puntero sale del área del objeto.
    {

    }
    public void OnDrop(PointerEventData eventData)                  // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        Drag item = eventData.pointerDrag.GetComponent<Drag>();

        if (item != null && this.GetComponent<Panels>().itemsCounter < this.GetComponent<Panels>().maxItems && CardPosition(this, eventData.pointerDrag))             
        {
            // Si el objeto tiene un componente Drag, coinciden las posiciones y cabe en la fila establece el padre del objeto arrastrado al objeto actual
            item.parent = this.transform; 
            this.GetComponent<Panels>().cards.Add(eventData.pointerDrag);   // Adiciona la carta al panel donde es colocada (List)
            GameManager.currentPlayer.hand.GetComponent<Panels>().cards.Remove(eventData.pointerDrag);  // Elimina la carta de la mano del jugador
            GameManager.currentPlayer.oneMove = true;                       // Indica que el jugador ha realizado un movimiento

            if (eventData.pointerDrag.GetComponent<CardDisplay>().card.effect != null)
            {
                ActiveEffect(eventData.pointerDrag.GetComponent<CardDisplay>());
            }
        }                                               
    }
}
