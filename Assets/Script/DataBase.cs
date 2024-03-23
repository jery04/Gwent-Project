using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<Card> deckDemon = new List<Card>();
    public List<Card> deckHeavenly = new List<Card>();
    public void CreateCard()    // Crea las instancias de las cartas
    {
        // Mazo 1(Demonios)
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("l1"), Resources.Load<Sprite>("silver")));  // Lider

        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));  // Señuelo
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckDemon.Add(new Card(0, false,Resources.Load<Sprite>("s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckDemon.Add(new Card(0, false,Resources.Load<Sprite>("s4"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckDemon.Add(new Card(0, false,Resources.Load<Sprite>("s5"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        deckDemon.Add(new Card(5, true, Resources.Load<Sprite>("p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));  // Plata
        deckDemon.Add(new Card(4, true, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckDemon.Add(new Card(1, true, Resources.Load<Sprite>("p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));
        deckDemon.Add(new Card(3, true, Resources.Load<Sprite>("p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckDemon.Add(new Card(2, true, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS));
        deckDemon.Add(new Card(3, true, Resources.Load<Sprite>("p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));

        deckDemon.Add(new Card(8, true, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R));  // Oro
        deckDemon.Add(new Card(6, true, Resources.Load<Sprite>("o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS));
        deckDemon.Add(new Card(5, true, Resources.Load<Sprite>("o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S));
        deckDemon.Add(new Card(9, true, Resources.Load<Sprite>("o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.M));
        deckDemon.Add(new Card(7, true, Resources.Load<Sprite>("o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MR));

        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));  // Despeje
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));

        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C)); // Clima
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));

        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I)); // Aumento
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
        deckDemon.Add(new Card(0, false, Resources.Load<Sprite>("a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));





        // Mazo 2(Celestiales)
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2l1"), Resources.Load<Sprite>("silver")));  // Lider

        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));  // Señuelo
        deckHeavenly.Add(new Card(0, false,  Resources.Load<Sprite>("2s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckHeavenly.Add(new Card(0, false,  Resources.Load<Sprite>("2s4"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2s5"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        deckHeavenly.Add(new Card(3, true, Resources.Load<Sprite>("2p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));  // Plata
        deckHeavenly.Add(new Card(5, true, Resources.Load<Sprite>("2p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckHeavenly.Add(new Card(4, true, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckHeavenly.Add(new Card(3, true, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckHeavenly.Add(new Card(2, true, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckHeavenly.Add(new Card(2, true, Resources.Load<Sprite>("2p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));

        deckHeavenly.Add(new Card(8, true, Resources.Load<Sprite>("2o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS));  // Oro
        deckHeavenly.Add(new Card(5, true, Resources.Load<Sprite>("2o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS));
        deckHeavenly.Add(new Card(9, true, Resources.Load<Sprite>("2o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS));
        deckHeavenly.Add(new Card(7, true, Resources.Load<Sprite>("2o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R));
        deckHeavenly.Add(new Card(5, true, Resources.Load<Sprite>("2o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S));

        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));  // Despeje
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));

        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate)); // Clima
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate));
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate));

        deckHeavenly.Add(new Card(0, false,  Resources.Load<Sprite>("2a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase)); // Aumento
        deckHeavenly.Add(new Card(0, false,  Resources.Load<Sprite>("2a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase));
        deckHeavenly.Add(new Card(0, false, Resources.Load<Sprite>("2a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase));
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
