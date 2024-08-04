
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    static public void ActiveEffect(CardDisplay item)                                       // Activa el efecto seg�n la carta
    {
        Player player1 = GameObject.Find("GameManager").GetComponent<GameManager>().player1;
        Player player2 = GameObject.Find("GameManager").GetComponent<GameManager>().player2;
        List<string> names1 = new List<string>() 
        { "Mag Mar", "Rhaegal", "Viserion", "Sansa", "Beric", "Eddard", "Guerrero1", "Guerrero4", "Jefe3",
          "Theon", "Wun Wun", "Mormont", "Caminante2", "Arya", "Drogon", "Rey Loco", "Caminante6", "Jon Snow", "Rey Noche" };
        List<string> names2 = new List<string>()
        { "Garra", "Kristofer", "Sr. Bronn", "Acero Valyrio", "Caminante1", "Jefe1", "Jefe2", "", "", "", "", "", "", "", "" };
        List<string> names3 = new List<string>() { "La Guardia", "Guerrero3", "Caminante5" };

        if (item.type_Card == Card.kind_card.climate)
            item.card.effect(player1, player2, item.card.affectedRow, item.card.power);

        else if (item.type_Card == Card.kind_card.clear || item.name == "Daenerys")
            item.card.effect(player1, player2);

        else if (item.type_Card == Card.kind_card.increase || item.type_Card == Card.kind_card.bait || names1.Contains(item.name))
            item.card.effect(GameManager.currentPlayer);

        else if (names3.Contains(item.name))
            item.card.effect(GameManager.currentPlayer, item);

        else if (names2.Contains(item.name))
        {
            if (player1.myTurn)
                item.card.effect(player2);
            else item.card.effect(player1);
        }
    }
    static public bool CardPosition(Drop item, GameObject item2)                            // Verifica que la posici�n de la carta coincida con la del panel
    {
        foreach (Card.card_position i in item.GetComponent<Panels>().position)
            if (i == item2.GetComponent<CardDisplay>().cardPosition)
                return true;

        return false;
    }
    public void OnPointerEnter(PointerEventData eventData)                                  // Se ejecuta cuando el puntero entra en el �rea del objeto
    {

    }
    public void OnPointerExit(PointerEventData eventData)                                   // Se ejecuta cuando el puntero sale del �rea del objeto.
    {

    }
    public void OnDrop(PointerEventData eventData)                                          // Se ejecuta cuando un objeto es soltado sobre el objeto asociado a este script.
    {
        Drag item = eventData.pointerDrag.GetComponent<Drag>();                             // Almacena el Componente Darg de la carta
        CardDisplay cardDrag = eventData.pointerDrag.GetComponent<CardDisplay>();
        // Si el objeto tiene un componente Drag, coinciden las posiciones y cabe en la fila establece el padre del objeto arrastrado al objeto actual
        if (item != null && this.GetComponent<Panels>().itemsCounter < this.GetComponent<Panels>().maxItems && CardPosition(this, eventData.pointerDrag))
        {   
            item.parent = this.transform;                                                   // Cambia el padre de la carta en la jerarqu�a
            GameManager.currentPlayer.hand.GetComponent<Panels>().cards.Remove(eventData.pointerDrag);  // Elimina la carta de la mano del jugador
            this.GetComponent<Panels>().cards.Add(eventData.pointerDrag);                   // Adiciona la carta al panel donde es colocada (List)
            GameManager.currentPlayer.oneMove = true;                                       // Indica que el jugador ha realizado un movimiento
            cardDrag.card.ActiveClip();                                                     // Activa el AudioClip de la carta 

            if (eventData.pointerDrag.GetComponent<CardDisplay>().card.effect != null)
                ActiveEffect(cardDrag);                                                     // Activa el efecto de la carta
        }                                               
    }
}
