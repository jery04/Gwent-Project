using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour
{
    public GameObject thisCard;                                         // Carta
    DateTime time = DateTime.Now;                                       // Variable DateTime 
    private float lastClickTime = 0;                                    // Tiempo cuando se realizó el primer EventTrigger

    public void OnSingleClick()                                         // Reconoce un Click-DoubleClick
    {
        if(lastClickTime == 0)
        {
            lastClickTime = time.Millisecond;

            // En caso de ser líder
            if (thisCard.GetComponent<CardDisplay>().cardPosition == Card.card_position.L)
                Drop.ActiveEffect(thisCard.GetComponent<CardDisplay>());

            else
            {
                Destroy(thisCard);                                          // Destruye la carta
                GameManager.currentPlayer.hand.GetComponent<Panels>().itemsCounter -= 1;
                GameManager.currentPlayer.TakeCard(1);                      // Agrega una carta a la mano
                GameManager.currentPlayer.Active(false);                    // Desactiva el componente EventTrigger
            }
        }
            
        else if (time.Millisecond - lastClickTime < 0.3)                // Algoritmo para reconocer DoubleClick
        {
            // Continuará...
        }

    }
}
