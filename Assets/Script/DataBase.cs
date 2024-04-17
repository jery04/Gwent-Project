using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<Card> deckStark = new List<Card>();         // Mazo1 (Stark)
    public List<Card> deckTargaryen = new List<Card>();     // Mazo2 (Targaryen)
    public List<Card> deckDead = new List<Card>();          // Mazo3 (Caminantes Blancos)(Dead)
    public DataBase() => CreateCard();
                                
    private void CreateCard()                                // Crea las instancias de las cartas
    {
        string[] txt =
        {
            "Put an increase in a row of its own",                                                          // (0)         
            "Affect one or more rows simultaneously for both players",                                      // (1)  
            "Remove the card with the most power from the field",                                           // (2)  
            "Remove the opponent's card with the least power",                                              // (3)  
            "Draw a card",                                                                                  // (4)  
            "Multiplies her attack by n, with n being the number of cards equal to her on the field",       // (5)  
            "Remove the row of the field with the fewest card units",                                       // (6)  
            "Calculate the average power across all the cards and set the power of all the cards equal to that average", // (7)  
            "Put a card with power 0 in the place of a card from the field to return it at hand",           // (8)  
            "Remove a Weather card",                                                                        // (9)  
            "Increases the power of unit cards in all own rows by 2",                                       // (10)  
            "Put an increase card",                                                                         // (11)  
            "Return a random card from the field to the hand"                                               // (12)  
        };


        // Mazo1 (Casa Stark/Norte)
        // Lider
        deckStark.Add(new Card("Jon Snow", "Stark", 0, false, false, Resources.Load<Sprite>("l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader, Card.card_position.L, txt[10], Effects.JonSnow));

        // Se�uelo
        deckStark.Add(new Card("Manada", "Stark", 0, false, false, Resources.Load<Sprite>("s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, Resources.Load<AudioClip>("Audios/Lobo1")));                            
        deckStark.Add(new Card("Ghost", "Stark", 0, false, false, Resources.Load<Sprite>("s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, Resources.Load<AudioClip>("Audios/Lobo2")));
        deckStark.Add(new Card("Cuervo", "Stark", 0, false, false, Resources.Load<Sprite>("s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, Resources.Load<AudioClip>("Audios/Cuervo")));

        // Plata
        deckStark.Add(new Card("Sansa", "Stark", 5, true, false, Resources.Load<Sprite>("p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[4], Effects.TakeCard));          
        deckStark.Add(new Card("La Guardia", "Stark", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, txt[5], Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/WinterIsComing")));
        deckStark.Add(new Card("La Guardia", "Stark", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, txt[5], Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/WinterIsComing")));
        deckStark.Add(new Card("Theon", "Stark", 2, true, false, Resources.Load<Sprite>("p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, txt[6], Effects.ClearRow));
        deckStark.Add(new Card("Garra", "Stark", 4, true, false, Resources.Load<Sprite>("p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[5], Effects.MultiplyPower));
        deckStark.Add(new Card("Beric", "Stark", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, txt[4], Effects.TakeCard));
        deckStark.Add(new Card("Beric", "Stark", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, txt[4], Effects.TakeCard));

        // Oro
        deckStark.Add(new Card("Kristofer", "Stark", 8, true, true, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, txt[3], Effects.RemoveMin));                           
        deckStark.Add(new Card("Arya", "Stark", 6, true, true, Resources.Load<Sprite>("o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, txt[7], Effects.Average));
        deckStark.Add(new Card("Eddard", "Stark", 5, true, true, Resources.Load<Sprite>("o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, txt[4], Effects.TakeCard));
        deckStark.Add(new Card("Mag Mar", "Stark", 9, true, true, Resources.Load<Sprite>("o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.M, txt[2], Effects.RemoveMax, Resources.Load<AudioClip>("Audios/Gigante")));
        deckStark.Add(new Card("Wun Wun", "Stark", 7, true, true, Resources.Load<Sprite>("o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MR, txt[6], Effects.ClearRow, Resources.Load<AudioClip>("Audios/Gigante")));

        // Despeje
        deckStark.Add(new Card("Ingrid", "Stark", 0, false, false, Resources.Load<Sprite>("d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, txt[9], Effects.ClimateOut, Resources.Load<AudioClip>("Audios/Ingrid")));                             
        deckStark.Add(new Card("Muro Hielo", "Stark", 0, false, false, Resources.Load<Sprite>("d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, txt[9], Effects.ClimateOut));

        // Clima
        deckStark.Add(new Card("Arciano", "Stark", -1, false, false, Resources.Load<Sprite>("c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate));  
        deckStark.Add(new Card("Ni�o Bosque", "Stark", -1, false, false, Resources.Load<Sprite>("c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate));
        deckStark.Add(new Card("Ni�a Bosque", "Stark", -1, false, false, Resources.Load<Sprite>("c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate));

        // Aumento
        deckStark.Add(new Card("Brandon", "Stark", 2, false, false, Resources.Load<Sprite>("a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase));      
        deckStark.Add(new Card("Samwell", "Stark", 2, false, false, Resources.Load<Sprite>("a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase));
        deckStark.Add(new Card("Hodor", "Stark", 2, false, false, Resources.Load<Sprite>("a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase, Resources.Load<AudioClip>("Audios/Hodor")));






        // Mazo2 (Casa Targaryen)
        // Lider
        deckTargaryen.Add(new Card("Daenerys", "Targareyn", 0, false, false, Resources.Load<Sprite>("2l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader, Card.card_position.L, txt[11], Effects.Daenerys, null));                                             

        // Se�uelo
        deckTargaryen.Add(new Card("La Mano", "Targareyn", 0, false, false, Resources.Load<Sprite>("2s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, null));                                               
        deckTargaryen.Add(new Card("Missandei", "Targareyn", 0, false, false,  Resources.Load<Sprite>("2s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, null));
        deckTargaryen.Add(new Card("Varys", "Targareyn",0, false, false, Resources.Load<Sprite>("2s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, null));

        // Plata
        deckTargaryen.Add(new Card("Guerrero1", "Targareyn", 3, true, false, Resources.Load<Sprite>("2p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[4], Effects.TakeCard, Resources.Load<AudioClip>("Audios/Espadas")));    //Espadas                   
        deckTargaryen.Add(new Card("Guerrero2", "Targareyn", 5, true, false, Resources.Load<Sprite>("2p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, "", null, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("8Guerrero3", "Targareyn", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[5], Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("9Guerrero4", "Targareyn", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, txt[4], Effects.TakeCard, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("8Guerrero3", "Targareyn", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[5], Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("Guerrero4", "Targareyn", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, txt[4], Effects.TakeCard, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("Guerrero5", "Targareyn", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, "", null, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("Guerrero5", "Targareyn", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, "", null, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("Sr. Bronn", "Targareyn", 2, true, false, Resources.Load<Sprite>("2p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, "", null, null));
        deckTargaryen.Add(new Card("Mormont", "Targareyn", 2, true, false, Resources.Load<Sprite>("2p7"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, txt[6], Effects.ClearRow, null));

        // Oro
        deckTargaryen.Add(new Card("Acero Valyrio", "Targareyn", 8, true, true, Resources.Load<Sprite>("2o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, txt[3], Effects.RemoveMin, null));                     
        deckTargaryen.Add(new Card("Ballesta", "Targareyn", 5, true, true, Resources.Load<Sprite>("2o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS, "", null, Resources.Load<AudioClip>("Audios/Caballos")));
        deckTargaryen.Add(new Card("Rhaegal", "Targareyn", 9, true, true, Resources.Load<Sprite>("2o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS, txt[2], Effects.RemoveMax, Resources.Load<AudioClip>("Audios/Dragon1")));
        deckTargaryen.Add(new Card("Viserion", "Targareyn", 7, true, true, Resources.Load<Sprite>("2o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, txt[5], Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/Dragon2")));
        deckTargaryen.Add(new Card("Drogon", "Targareyn", 5, true, true, Resources.Load<Sprite>("2o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, txt[7], Effects.Average, Resources.Load<AudioClip>("Audios/Dragon2")));
        deckTargaryen.Add(new Card("Rey Loco", "Targareyn", 5, true, true, Resources.Load<Sprite>("2o6"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, txt[7], Effects.Average, null));

        // Despeje
        deckTargaryen.Add(new Card("Gusano Gris", "Targareyn", 0, false, false, Resources.Load<Sprite>("2d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, txt[9], Effects.ClimateOut, null));

        // Clima
        deckTargaryen.Add(new Card("Catapulta", "Targareyn", 0, false, false, Resources.Load<Sprite>("2c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate, Resources.Load<AudioClip>("Audios/Catapultas")));                   
        deckTargaryen.Add(new Card("Flota", "Targareyn", 0, false, false, Resources.Load<Sprite>("2c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate, Resources.Load<AudioClip>("Audios/Flota")));

        // Aumento
        deckTargaryen.Add(new Card("Inmaculados", "Targareyn", 0, false, false,  Resources.Load<Sprite>("2a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase, Resources.Load<AudioClip>("Audios/Marchando")));                 
        deckTargaryen.Add(new Card("Dothraki", "Targareyn", 0, false, false,  Resources.Load<Sprite>("2a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase, Resources.Load<AudioClip>("Audios/Caballos")));
        deckTargaryen.Add(new Card("Tyron", "Targareyn", 0, false, false, Resources.Load<Sprite>("2a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0],Effects.Increase, null));






        // Mazo3 (Caminantes Blancos)
        // Lider
        deckDead.Add(new Card("Rey Noche", "Dead",  0, false, false, Resources.Load<Sprite>("3l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader, Card.card_position.L, txt[12], Effects.NightKing, null));

        // Se�uelo
        deckDead.Add(new Card("Cam.Blanco1", "Dead", 0, false, false, Resources.Load<Sprite>("3s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, null));                                               
        deckDead.Add(new Card("Cam.Blanco2", "Dead", 0, false, false, Resources.Load<Sprite>("3s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, null));
        deckDead.Add(new Card("Cam.Blanco3", "Dead", 0, false, false, Resources.Load<Sprite>("3s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, txt[8], Effects.ReturnToHand, null));

        // Plata
        deckDead.Add(new Card("Caminantes1", "Dead", 3, true, false, Resources.Load<Sprite>("3p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[3], Effects.RemoveMin, Resources.Load<AudioClip>("Audios/CaminanteBlanco1")));                       
        deckDead.Add(new Card("Caminantes2", "Dead", 5, true, false, Resources.Load<Sprite>("3p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, txt[6], Effects.ClearRow, Resources.Load<AudioClip>("Audios/CaminanteBlanco2")));
        deckDead.Add(new Card("Caminantes3", "Dead", 4, true, false, Resources.Load<Sprite>("3p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[4], Effects.TakeCard, Resources.Load<AudioClip>("Audios/CaminanteBlanco3")));
        deckDead.Add(new Card("Caminantes4", "Dead", 3, true, false, Resources.Load<Sprite>("3p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, "", null, Resources.Load<AudioClip>("Audios/CaminanteBlanco4")));
        deckDead.Add(new Card("Caminantes3", "Dead", 4, true, false, Resources.Load<Sprite>("3p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, txt[4], Effects.TakeCard, Resources.Load<AudioClip>("Audios/CaminanteBlanco3")));
        deckDead.Add(new Card("Caminantes4", "Dead", 3, true, false, Resources.Load<Sprite>("3p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR,"", null, Resources.Load<AudioClip>("Audios/CaminanteBlanco4")));
        deckDead.Add(new Card("Caminantes5", "Dead", 4, true, false, Resources.Load<Sprite>("3p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, "", null, Resources.Load<AudioClip>("Audios/CaminanteBlanco5")));
        deckDead.Add(new Card("Caminantes5", "Dead", 4, true, false, Resources.Load<Sprite>("3p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, "", null, Resources.Load<AudioClip>("Audios/CaminanteBlanco5")));
        deckDead.Add(new Card("Caminantes6", "Dead", 2, true, false, Resources.Load<Sprite>("3p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, txt[7], Effects.Average, Resources.Load<AudioClip>("Audios/CaminanteBlanco1")));;

        // Oro
        deckDead.Add(new Card("Wun Wun", "Dead", 8, true, true, Resources.Load<Sprite>("3o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, txt[6], Effects.ClearRow, Resources.Load<AudioClip>("Audios/Gigante")));                     
        deckDead.Add(new Card("Jefe1", "Dead", 5, true, true, Resources.Load<Sprite>("3o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS, "", null, null));
        deckDead.Add(new Card("Jefe2", "Dead", 9, true, true, Resources.Load<Sprite>("3o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS, "", null, null));
        deckDead.Add(new Card("Jefe3", "Dead", 7, true, true, Resources.Load<Sprite>("3o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, txt[7], Effects.Average, null));
        deckDead.Add(new Card("Viserion", "Dead", 5, true, true, Resources.Load<Sprite>("3o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, txt[5], Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/Dragon2")));

        // Despeje
        deckDead.Add(new Card("Muerto", "Dead", 0, false, false, Resources.Load<Sprite>("3d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, txt[9], Effects.ClimateOut, null));                                            
        deckDead.Add(new Card("Muerto", "Dead", 0, false, false, Resources.Load<Sprite>("3d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, txt[9], Effects.ClimateOut, null));

        // Clima
        deckDead.Add(new Card("Avalancha1", "Dead", 0, false, false, Resources.Load<Sprite>("3c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate, Resources.Load<AudioClip>("Audios/Avalancha")));                   
        deckDead.Add(new Card("Congelar", "Dead", 0, false, false, Resources.Load<Sprite>("3c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate, null));
        deckDead.Add(new Card("Avalancha2", "Dead", 0, false, false, Resources.Load<Sprite>("3c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, txt[1], Effects.Climate, Resources.Load<AudioClip>("Audios/Avalancha")));

        // Aumento
        deckDead.Add(new Card("Muro", "Dead", 0, false, false, Resources.Load<Sprite>("3a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase, null));                
        deckDead.Add(new Card("Ataque", "Dead", 0, false, false, Resources.Load<Sprite>("3a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase, null));
        deckDead.Add(new Card("Gigante", "Dead", 0, false, false, Resources.Load<Sprite>("3a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, txt[0], Effects.Increase, Resources.Load<AudioClip>("Audios/Gigante")));
    }
}
