using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour 
{
    public List<Card> deckStark = new List<Card>();         // Mazo1 (Stark)
    public List<Card> deckTargaryen = new List<Card>();     // Mazo2 (Targaryen)
    public List<Card> deckDead = new List<Card>();          // Mazo3 (Caminantes Blancos)      
    public void CreateCard()                                // Crea las instancias de las cartas
    {
        // Mazo1 (Casa Stark/Norte)
        deckStark.Add(new Card("1", 0, false, false, Resources.Load<Sprite>("l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));                                                 // Lider

        deckStark.Add(new Card("2", 0, false, false, Resources.Load<Sprite>("s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));                             // Señuelo
        deckStark.Add(new Card("3", 0, false, false, Resources.Load<Sprite>("s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));
        deckStark.Add(new Card("4", 0, false, false, Resources.Load<Sprite>("s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand));

        deckStark.Add(new Card("7", 5, true, false, Resources.Load<Sprite>("p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.TakeCard));          // Plata
        deckStark.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Effects.MultiplyPower));
        deckStark.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Effects.MultiplyPower));
        deckStark.Add(new Card("9", 2, true, false, Resources.Load<Sprite>("p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, Effects.ClearRow));
        deckStark.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.MultiplyPower));
        deckStark.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, Effects.ClimateOut));
        deckStark.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, Effects.ClimateOut));

        deckStark.Add(new Card("13", 8, true, true, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, Effects.RemoveMin));                            // Oro
        deckStark.Add(new Card("14", 6, true, true, Resources.Load<Sprite>("o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, Effects.Average));
        deckStark.Add(new Card("15", 5, true, true, Resources.Load<Sprite>("o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, Effects.TakeCard));
        deckStark.Add(new Card("16", 9, true, true, Resources.Load<Sprite>("o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.M, Effects.RemoveMax));
        deckStark.Add(new Card("17", 7, true, true, Resources.Load<Sprite>("o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MR, Effects.ClearRow));

        deckStark.Add(new Card("18", 0, false, false, Resources.Load<Sprite>("d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, Effects.ClimateOut));                              // Despeje
        deckStark.Add(new Card("19", 0, false, false, Resources.Load<Sprite>("d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, Effects.ClimateOut));

        deckStark.Add(new Card("20", -1, false, false, Resources.Load<Sprite>("c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));  // Clima
        deckStark.Add(new Card("21", -1, false, false, Resources.Load<Sprite>("c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));
        deckStark.Add(new Card("22", -1, false, false, Resources.Load<Sprite>("c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));

        deckStark.Add(new Card("23", 2, false, false, Resources.Load<Sprite>("a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));      // Aumento
        deckStark.Add(new Card("24", 2, false, false, Resources.Load<Sprite>("a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));
        deckStark.Add(new Card("25", 2, false, false, Resources.Load<Sprite>("a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));




        // Mazo2 (Casa Targaryen)
        deckTargaryen.Add(new Card("1", 0, false, false, Resources.Load<Sprite>("2l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));                                             // Lider

        deckTargaryen.Add(new Card("2", 0, false, false, Resources.Load<Sprite>("2s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));                                               // Señuelo
        deckTargaryen.Add(new Card("4", 0, false, false,  Resources.Load<Sprite>("2s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckTargaryen.Add(new Card("3", 0, false, false, Resources.Load<Sprite>("2s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        deckTargaryen.Add(new Card("6", 3, true, false, Resources.Load<Sprite>("2p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));                       // Plata
        deckTargaryen.Add(new Card("7", 5, true, false, Resources.Load<Sprite>("2p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckTargaryen.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckTargaryen.Add(new Card("9", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckTargaryen.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckTargaryen.Add(new Card("9", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckTargaryen.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckTargaryen.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckTargaryen.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("2p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));
        deckTargaryen.Add(new Card("100", 2, true, false, Resources.Load<Sprite>("2p7"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));

        deckTargaryen.Add(new Card("12", 8, true, true, Resources.Load<Sprite>("2o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS));                     // Oro
        deckTargaryen.Add(new Card("13", 5, true, true, Resources.Load<Sprite>("2o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS));
        deckTargaryen.Add(new Card("14", 9, true, true, Resources.Load<Sprite>("2o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS));
        deckTargaryen.Add(new Card("15", 7, true, true, Resources.Load<Sprite>("2o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R));
        deckTargaryen.Add(new Card("16", 5, true, true, Resources.Load<Sprite>("2o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S));

        deckTargaryen.Add(new Card("17", 0, false, false, Resources.Load<Sprite>("2d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));                                            // Despeje

        deckTargaryen.Add(new Card("19", 0, false, false, Resources.Load<Sprite>("2c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));                   // Clima
        deckTargaryen.Add(new Card("20", 0, false, false, Resources.Load<Sprite>("2c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));

        deckTargaryen.Add(new Card("22", 0, false, false,  Resources.Load<Sprite>("2a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));                 // Aumento
        deckTargaryen.Add(new Card("23", 0, false, false,  Resources.Load<Sprite>("2a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
        deckTargaryen.Add(new Card("24", 0, false, false, Resources.Load<Sprite>("2a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));



        // Mazo3 (Caminantes Blancos)
        deckDead.Add(new Card("1", 0, false, false, Resources.Load<Sprite>("3l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));                                             // Lider

        deckDead.Add(new Card("2", 0, false, false, Resources.Load<Sprite>("3s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));                                               // Señuelo
        deckDead.Add(new Card("4", 0, false, false, Resources.Load<Sprite>("3s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckDead.Add(new Card("3", 0, false, false, Resources.Load<Sprite>("3s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        deckDead.Add(new Card("6", 3, true, false, Resources.Load<Sprite>("3p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));                       // Plata
        deckDead.Add(new Card("7", 5, true, false, Resources.Load<Sprite>("3p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckDead.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("3p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckDead.Add(new Card("9", 3, true, false, Resources.Load<Sprite>("3p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckDead.Add(new Card("8", 4, true, false, Resources.Load<Sprite>("3p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R));
        deckDead.Add(new Card("9", 3, true, false, Resources.Load<Sprite>("3p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR));
        deckDead.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("3p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckDead.Add(new Card("10", 4, true, false, Resources.Load<Sprite>("3p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckDead.Add(new Card("11", 2, true, false, Resources.Load<Sprite>("3p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));;

        deckDead.Add(new Card("12", 8, true, true, Resources.Load<Sprite>("3o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS));                     // Oro
        deckDead.Add(new Card("13", 5, true, true, Resources.Load<Sprite>("3o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS));
        deckDead.Add(new Card("14", 9, true, true, Resources.Load<Sprite>("3o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS));
        deckDead.Add(new Card("15", 7, true, true, Resources.Load<Sprite>("3o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R));
        deckDead.Add(new Card("16", 5, true, true, Resources.Load<Sprite>("3o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S));

        deckDead.Add(new Card("17", 0, false, false, Resources.Load<Sprite>("3d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));                                            // Despeje
        deckDead.Add(new Card("17", 0, false, false, Resources.Load<Sprite>("3d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));

        deckDead.Add(new Card("19", 0, false, false, Resources.Load<Sprite>("3c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));                   // Clima
        deckDead.Add(new Card("20", 0, false, false, Resources.Load<Sprite>("3c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));
        deckDead.Add(new Card("21", 0, false, false, Resources.Load<Sprite>("3c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));

        deckDead.Add(new Card("22", 0, false, false, Resources.Load<Sprite>("3a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));                 // Aumento
        deckDead.Add(new Card("23", 0, false, false, Resources.Load<Sprite>("3a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
        deckDead.Add(new Card("24", 0, false, false, Resources.Load<Sprite>("3a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
    }
}
