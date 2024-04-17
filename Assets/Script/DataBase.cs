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
        // Mazo1 (Casa Stark/Norte)
        // Lider
        deckStark.Add(new Card("Jon Snow", 0, false, false, Resources.Load<Sprite>("l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader, Card.card_position.L, Effects.JonSnow));

        // Señuelo
        deckStark.Add(new Card("Manada", 0, false, false, Resources.Load<Sprite>("s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand, Resources.Load<AudioClip>("Audios/Lobo1")));                            
        deckStark.Add(new Card("Ghost", 0, false, false, Resources.Load<Sprite>("s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand, Resources.Load<AudioClip>("Audios/Lobo2")));
        deckStark.Add(new Card("Cuervo", 0, false, false, Resources.Load<Sprite>("s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait, Effects.ReturnToHand, Resources.Load<AudioClip>("Audios/Cuervo")));

        // Plata
        deckStark.Add(new Card("Sansa", 5, true, false, Resources.Load<Sprite>("p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.TakeCard));          
        deckStark.Add(new Card("La Guardia", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/WinterIsComing")));
        deckStark.Add(new Card("La Guardia", 4, true, false, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Effects.MultiplyPower, Resources.Load<AudioClip>("Audios/WinterIsComing")));
        deckStark.Add(new Card("Theon", 2, true, false, Resources.Load<Sprite>("p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, Effects.ClearRow));
        deckStark.Add(new Card("Garra", 4, true, false, Resources.Load<Sprite>("p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Effects.MultiplyPower));
        deckStark.Add(new Card("Beric", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, Effects.TakeCard));
        deckStark.Add(new Card("Beric", 2, true, false, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MS, Effects.TakeCard));

        // Oro
        deckStark.Add(new Card("Kristofer", 8, true, true, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, Effects.RemoveMin));                           
        deckStark.Add(new Card("Arya", 6, true, true, Resources.Load<Sprite>("o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, Effects.Average));
        deckStark.Add(new Card("Eddard", 5, true, true, Resources.Load<Sprite>("o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, Effects.TakeCard));
        deckStark.Add(new Card("Mag Mar", 9, true, true, Resources.Load<Sprite>("o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.M, Effects.RemoveMax, Resources.Load<AudioClip>("Audios/Gigante")));
        deckStark.Add(new Card("Wun Wun", 7, true, true, Resources.Load<Sprite>("o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MR, Effects.ClearRow, Resources.Load<AudioClip>("Audios/Gigante")));

        // Despeje
        deckStark.Add(new Card("Ingrid", 0, false, false, Resources.Load<Sprite>("d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, Effects.ClimateOut));                             
        deckStark.Add(new Card("Muro Hielo", 0, false, false, Resources.Load<Sprite>("d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear, Effects.ClimateOut));

        // Clima
        deckStark.Add(new Card("Arciano", -1, false, false, Resources.Load<Sprite>("c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));  
        deckStark.Add(new Card("Niño Bosque", -1, false, false, Resources.Load<Sprite>("c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));
        deckStark.Add(new Card("Niña Bosque", -1, false, false, Resources.Load<Sprite>("c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Effects.Climate));

        // Aumento
        deckStark.Add(new Card("Brandon", 2, false, false, Resources.Load<Sprite>("a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));      
        deckStark.Add(new Card("Samwell", 2, false, false, Resources.Load<Sprite>("a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase));
        deckStark.Add(new Card("Hodor", 2, false, false, Resources.Load<Sprite>("a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Effects.Increase, Resources.Load<AudioClip>("Audios/Hodor")));






        // Mazo2 (Casa Targaryen)
        // Lider
        deckTargaryen.Add(new Card("Daenerys", 0, false, false, Resources.Load<Sprite>("2l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));                                             

        // Señuelo
        deckTargaryen.Add(new Card("La Mano", 0, false, false, Resources.Load<Sprite>("2s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));                                               
        deckTargaryen.Add(new Card("Missandei", 0, false, false,  Resources.Load<Sprite>("2s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckTargaryen.Add(new Card("Varys", 0, false, false, Resources.Load<Sprite>("2s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        // Plata
        deckTargaryen.Add(new Card("Guerrero1", 3, true, false, Resources.Load<Sprite>("2p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Resources.Load<AudioClip>("Audios/Espadas")));    //Espadas                   
        deckTargaryen.Add(new Card("Guerrero2", 5, true, false, Resources.Load<Sprite>("2p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("8Guerrero3", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("9Guerrero4", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("8Guerrero3", 4, true, false, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("Guerrero4", 3, true, false, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, Resources.Load<AudioClip>("Audios/Espadas")));
        deckTargaryen.Add(new Card("Guerrero5", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckTargaryen.Add(new Card("Guerrero5", 4, true, false, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S));
        deckTargaryen.Add(new Card("Sr. Bronn", 2, true, false, Resources.Load<Sprite>("2p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));
        deckTargaryen.Add(new Card("Mormont", 2, true, false, Resources.Load<Sprite>("2p7"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M));

        // Oro
        deckTargaryen.Add(new Card("Acero Valyrio", 8, true, true, Resources.Load<Sprite>("2o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS));                     
        deckTargaryen.Add(new Card("Ballesta", 5, true, true, Resources.Load<Sprite>("2o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS, Resources.Load<AudioClip>("Audios/Caballos")));
        deckTargaryen.Add(new Card("Rhaegal", 9, true, true, Resources.Load<Sprite>("2o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS, Resources.Load<AudioClip>("Audios/Dragon1")));
        deckTargaryen.Add(new Card("Viserion", 7, true, true, Resources.Load<Sprite>("2o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R, Resources.Load<AudioClip>("Audios/Dragon2")));
        deckTargaryen.Add(new Card("Drogon", 5, true, true, Resources.Load<Sprite>("2o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, Resources.Load<AudioClip>("Audios/Dragon2")));
        deckTargaryen.Add(new Card("Rey Loco", 5, true, true, Resources.Load<Sprite>("2o6"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S));

        // Despeje
        deckTargaryen.Add(new Card("Gusano Gris", 0, false, false, Resources.Load<Sprite>("2d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));

        // Clima
        deckTargaryen.Add(new Card("Catapulta", 0, false, false, Resources.Load<Sprite>("2c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Resources.Load<AudioClip>("Audios/Catapultas")));                   
        deckTargaryen.Add(new Card("Flota", 0, false, false, Resources.Load<Sprite>("2c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Resources.Load<AudioClip>("Audios/Flota")));

        // Aumento
        deckTargaryen.Add(new Card("Inmaculados", 0, false, false,  Resources.Load<Sprite>("2a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Resources.Load<AudioClip>("Audios/Marchando")));                 
        deckTargaryen.Add(new Card("Dothraki", 0, false, false,  Resources.Load<Sprite>("2a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Resources.Load<AudioClip>("Audios/Caballos")));
        deckTargaryen.Add(new Card("Tyron", 0, false, false, Resources.Load<Sprite>("2a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));






        // Mazo3 (Caminantes Blancos)
        // Lider
        deckDead.Add(new Card("Rey Noche", 0, false, false, Resources.Load<Sprite>("3l1"), Resources.Load<Sprite>("golden"), Card.kind_card.leader));

        // Señuelo
        deckDead.Add(new Card("Cam.Blanco1", 0, false, false, Resources.Load<Sprite>("3s1"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));                                               
        deckDead.Add(new Card("Cam.Blanco2", 0, false, false, Resources.Load<Sprite>("3s2"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));
        deckDead.Add(new Card("Cam.Blanco3", 0, false, false, Resources.Load<Sprite>("3s3"), Resources.Load<Sprite>("silver"), Card.kind_card.bait));

        // Plata
        deckDead.Add(new Card("Caminantes1", 3, true, false, Resources.Load<Sprite>("3p1"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Resources.Load<AudioClip>("Audios/CaminanteBlanco1")));                       
        deckDead.Add(new Card("Caminantes2", 5, true, false, Resources.Load<Sprite>("3p2"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Resources.Load<AudioClip>("Audios/CaminanteBlanco2")));
        deckDead.Add(new Card("Caminantes3", 4, true, false, Resources.Load<Sprite>("3p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Resources.Load<AudioClip>("Audios/CaminanteBlanco3")));
        deckDead.Add(new Card("Caminantes4", 3, true, false, Resources.Load<Sprite>("3p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, Resources.Load<AudioClip>("Audios/CaminanteBlanco4")));
        deckDead.Add(new Card("Caminantes3", 4, true, false, Resources.Load<Sprite>("3p3"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.R, Resources.Load<AudioClip>("Audios/CaminanteBlanco3")));
        deckDead.Add(new Card("Caminantes4", 3, true, false, Resources.Load<Sprite>("3p4"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.MR, Resources.Load<AudioClip>("Audios/CaminanteBlanco4")));
        deckDead.Add(new Card("Caminantes5", 4, true, false, Resources.Load<Sprite>("3p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Resources.Load<AudioClip>("Audios/CaminanteBlanco5")));
        deckDead.Add(new Card("Caminantes5", 4, true, false, Resources.Load<Sprite>("3p5"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.S, Resources.Load<AudioClip>("Audios/CaminanteBlanco5")));
        deckDead.Add(new Card("Caminantes6", 2, true, false, Resources.Load<Sprite>("3p6"), Resources.Load<Sprite>("silver"), Card.kind_card.silver, Card.card_position.M, Resources.Load<AudioClip>("Audios/CaminanteBlanco1")));;

        // Oro
        deckDead.Add(new Card("Wun Wun", 8, true, true, Resources.Load<Sprite>("3o1"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MRS, Resources.Load<AudioClip>("Audios/Gigante")));                     
        deckDead.Add(new Card("Jefe1", 5, true, true, Resources.Load<Sprite>("3o2"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.MS));
        deckDead.Add(new Card("Jefe2", 9, true, true, Resources.Load<Sprite>("3o3"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.RS));
        deckDead.Add(new Card("Jefe3", 7, true, true, Resources.Load<Sprite>("3o4"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.R));
        deckDead.Add(new Card("Viserion", 5, true, true, Resources.Load<Sprite>("3o5"), Resources.Load<Sprite>("golden"), Card.kind_card.golden, Card.card_position.S, Resources.Load<AudioClip>("Audios/Dragon2")));

        // Despeje
        deckDead.Add(new Card("Muerto", 0, false, false, Resources.Load<Sprite>("3d1"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));                                            
        deckDead.Add(new Card("Muerto", 0, false, false, Resources.Load<Sprite>("3d2"), Resources.Load<Sprite>("silver"), Card.kind_card.clear));

        // Clima
        deckDead.Add(new Card("Avalancha1", 0, false, false, Resources.Load<Sprite>("3c1"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Resources.Load<AudioClip>("Audios/Avalancha")));                   
        deckDead.Add(new Card("Congelar", 0, false, false, Resources.Load<Sprite>("3c2"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C));
        deckDead.Add(new Card("Avalancha2", 0, false, false, Resources.Load<Sprite>("3c3"), Resources.Load<Sprite>("emerald"), Card.kind_card.climate, Card.card_position.C, Resources.Load<AudioClip>("Audios/Avalancha")));

        // Aumento
        deckDead.Add(new Card("Muro", 0, false, false, Resources.Load<Sprite>("3a1"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));                
        deckDead.Add(new Card("Ataque", 0, false, false, Resources.Load<Sprite>("3a2"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I));
        deckDead.Add(new Card("Gigante", 0, false, false, Resources.Load<Sprite>("3a3"), Resources.Load<Sprite>("emerald"), Card.kind_card.increase, Card.card_position.I, Resources.Load<AudioClip>("Audios/Gigante")));
    }
}
