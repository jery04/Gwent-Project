using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<Card> deckDemon = new List<Card>();         // Mazo1 (Demonios)
    public List<Card> deckHeavenly = new List<Card>();      // Mazo2 (Celestiales)
    public void CreateCard()                                // Crea las instancias de las cartas
    {
        // Mazo1 (Demonios)
        deckDemon.Add(new Card("1", 0, false, false, Resources.Load<Sprite>("l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));                                                 // Lider

        deckDemon.Add(new Card("2", 0, false, false, Resources.Load<Sprite>("s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));                             // Señuelo
        deckDemon.Add(new Card("3", 0, false, false, Resources.Load<Sprite>("s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));
        deckDemon.Add(new Card("4", 0, false, false, Resources.Load<Sprite>("s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));
        deckDemon.Add(new Card("5", 0, false, false, Resources.Load<Sprite>("s4"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));
        deckDemon.Add(new Card("6", 0, false, false, Resources.Load<Sprite>("s5"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));

        deckDemon.Add(new Card("7", 5, true, false, Resources.Load<Sprite>("p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.TakeCard));          // Plata
        deckDemon.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Effects.MultiplyPower));
        deckDemon.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Effects.MultiplyPower));
        deckDemon.Add(new Card("9", 2, true, false, Resources.Load<Sprite>("p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, Effects.ClearRow));
        deckDemon.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.MultiplyPower));
        deckDemon.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, Effects.ClimateOut));
        deckDemon.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, Effects.ClimateOut));
        deckDemon.Add(new Card("12", 3, true, false, Resources.Load<Sprite>("p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.TakeCard));
        deckDemon.Add(new Card("12", 3, true, false, Resources.Load<Sprite>("p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.TakeCard));

        deckDemon.Add(new Card("13", 8, true, true, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, Effects.RemoveMin));                            // Oro
        deckDemon.Add(new Card("14", 6, true, true, Resources.Load<Sprite>("o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, Effects.Average));
        deckDemon.Add(new Card("15", 5, true, true, Resources.Load<Sprite>("o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, Effects.TakeCard));
        deckDemon.Add(new Card("16", 9, true, true, Resources.Load<Sprite>("o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.M, Effects.RemoveMax));
        deckDemon.Add(new Card("17", 7, true, true, Resources.Load<Sprite>("o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MR, Effects.ClearRow));

        deckDemon.Add(new Card("18", 0, false, false, Resources.Load<Sprite>("d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, Effects.ClimateOut));                              // Despeje
        deckDemon.Add(new Card("19", 0, false, false, Resources.Load<Sprite>("d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, Effects.ClimateOut));

        deckDemon.Add(new Card("20", -1, false, false, Resources.Load<Sprite>("c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));  // Clima
        deckDemon.Add(new Card("21", -1, false, false, Resources.Load<Sprite>("c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));
        deckDemon.Add(new Card("22", -1, false, false, Resources.Load<Sprite>("c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));

        deckDemon.Add(new Card("23", 2, false, false, Resources.Load<Sprite>("a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));      // Aumento
        deckDemon.Add(new Card("24", 2, false, false, Resources.Load<Sprite>("a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));
        deckDemon.Add(new Card("25", 2, false, false, Resources.Load<Sprite>("a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));




        // Mazo2 (Celestiales)
        deckHeavenly.Add(new Card("1", 0, false, false, Resources.Load<Sprite>("2l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));                                             // Lider

        deckHeavenly.Add(new Card("2", 0, false, false, Resources.Load<Sprite>("2s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));                                               // Señuelo
        deckHeavenly.Add(new Card("", 0, false, false,  Resources.Load<Sprite>("2s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckHeavenly.Add(new Card("3", 0, false, false, Resources.Load<Sprite>("2s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckHeavenly.Add(new Card("4", 0, false, false,  Resources.Load<Sprite>("2s4"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckHeavenly.Add(new Card("5", 0, false, false, Resources.Load<Sprite>("2s5"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        deckHeavenly.Add(new Card("6", 3, true, false, Resources.Load<Sprite>("2p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));                       // Plata
        deckHeavenly.Add(new Card("7", 5, true, false, Resources.Load<Sprite>("2p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckHeavenly.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckHeavenly.Add(new Card("9", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckHeavenly.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckHeavenly.Add(new Card("9", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckHeavenly.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckHeavenly.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckHeavenly.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("2p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));

        deckHeavenly.Add(new Card("12", 8, true, true, Resources.Load<Sprite>("2o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS));                     // Oro
        deckHeavenly.Add(new Card("13", 5, true, true, Resources.Load<Sprite>("2o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS));
        deckHeavenly.Add(new Card("14", 9, true, true, Resources.Load<Sprite>("2o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS));
        deckHeavenly.Add(new Card("15", 7, true, true, Resources.Load<Sprite>("2o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R));
        deckHeavenly.Add(new Card("16", 5, true, true, Resources.Load<Sprite>("2o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S));

        deckHeavenly.Add(new Card("17", 0, false, false, Resources.Load<Sprite>("2d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));                                            // Despeje
        deckHeavenly.Add(new Card("18", 0, false, false, Resources.Load<Sprite>("2d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));

        deckHeavenly.Add(new Card("19", 0, false, false, Resources.Load<Sprite>("2c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));                   // Clima
        deckHeavenly.Add(new Card("20", 0, false, false, Resources.Load<Sprite>("2c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));
        deckHeavenly.Add(new Card("21", 0, false, false, Resources.Load<Sprite>("2c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));

        deckHeavenly.Add(new Card("22", 0, false, false,  Resources.Load<Sprite>("2a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));                 // Aumento
        deckHeavenly.Add(new Card("23", 0, false, false,  Resources.Load<Sprite>("2a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
        deckHeavenly.Add(new Card("24", 0, false, false, Resources.Load<Sprite>("2a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
    }
}
