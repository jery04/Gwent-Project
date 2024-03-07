using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
        public GameObject cardPrefab; // Asigna el prefab de la tarjeta aquí en el Inspector
        public Transform deckPanel; // Asigna el panel 'Deck' aquí en el Inspector
        public Card[] deckCards; // Una colección de ScriptableObjects de tipo Card

        void Start()
        {
            foreach (Card card in deckCards)
            {
                // Instancia la tarjeta como hijo del panel 'Deck'
                GameObject cardInstance = Instantiate(cardPrefab, deckPanel);

                // Configura los componentes de la tarjeta instanciada con los datos de la Card
                // Esto dependerá de cómo hayas configurado tu prefab de tarjeta
                // Por ejemplo, si tienes un componente de texto para el nombre de la tarjeta:
                // cardInstance.GetComponent<Text>().text = card.cardName;
            }
        }
}
