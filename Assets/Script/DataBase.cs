using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    List<Card> deckDemon = new List<Card>();
    List<Card> deckHeavenly = new List<Card>();
    public void CreateCard()
    {
        // Mazo 1(Demonios)
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("l1"), Resources.Load<Sprite>("silver")));  // Lider

        deckDemon.Add(new Card(0, Resources.Load<Sprite>("s1"), Resources.Load<Sprite>("silver")));  // Señuelo
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("s2"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("s3"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("s4"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("s5"), Resources.Load<Sprite>("silver")));

        deckDemon.Add(new Card(5, Resources.Load<Sprite>("p1"), Resources.Load<Sprite>("silver")));  // Plata
        deckDemon.Add(new Card(4, Resources.Load<Sprite>("p2"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(1, Resources.Load<Sprite>("p3"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(3, Resources.Load<Sprite>("p4"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(2, Resources.Load<Sprite>("p5"), Resources.Load<Sprite>("silver")));
        deckDemon.Add(new Card(3, Resources.Load<Sprite>("p6"), Resources.Load<Sprite>("silver")));

        deckDemon.Add(new Card(8, Resources.Load<Sprite>("o1"), Resources.Load<Sprite>("golden")));  // Oro
        deckDemon.Add(new Card(6, Resources.Load<Sprite>("o2"), Resources.Load<Sprite>("golden")));
        deckDemon.Add(new Card(5, Resources.Load<Sprite>("o3"), Resources.Load<Sprite>("golden")));
        deckDemon.Add(new Card(9, Resources.Load<Sprite>("o4"), Resources.Load<Sprite>("golden")));
        deckDemon.Add(new Card(7, Resources.Load<Sprite>("o5"), Resources.Load<Sprite>("golden")));

        deckDemon.Add(new Card(0, Resources.Load<Sprite>("d1"), Resources.Load<Sprite>("silver")));  // Despeje
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("d2"), Resources.Load<Sprite>("silver")));

        deckDemon.Add(new Card(0, Resources.Load<Sprite>("c1"), Resources.Load<Sprite>("emerald"))); // Clima
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("c2"), Resources.Load<Sprite>("emerald")));
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("c3"), Resources.Load<Sprite>("emerald")));

        deckDemon.Add(new Card(0, Resources.Load<Sprite>("a1"), Resources.Load<Sprite>("emerald"))); // Aumento
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("a2"), Resources.Load<Sprite>("emerald")));
        deckDemon.Add(new Card(0, Resources.Load<Sprite>("a3"), Resources.Load<Sprite>("emerald")));





        // Mazo 2(Celestiales)
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2l1"), Resources.Load<Sprite>("silver")));  // Lider

        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2s1"), Resources.Load<Sprite>("silver")));  // Señuelo
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2s2"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2s3"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2s4"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2s5"), Resources.Load<Sprite>("silver")));

        deckHeavenly.Add(new Card(3, Resources.Load<Sprite>("2p1"), Resources.Load<Sprite>("silver")));  // Plata
        deckHeavenly.Add(new Card(5, Resources.Load<Sprite>("2p2"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(4, Resources.Load<Sprite>("2p3"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(3, Resources.Load<Sprite>("2p4"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(2, Resources.Load<Sprite>("2p5"), Resources.Load<Sprite>("silver")));
        deckHeavenly.Add(new Card(2, Resources.Load<Sprite>("2p6"), Resources.Load<Sprite>("silver")));

        deckHeavenly.Add(new Card(8, Resources.Load<Sprite>("2o1"), Resources.Load<Sprite>("golden")));  // Oro
        deckHeavenly.Add(new Card(5, Resources.Load<Sprite>("2o2"), Resources.Load<Sprite>("golden")));
        deckHeavenly.Add(new Card(9, Resources.Load<Sprite>("2o3"), Resources.Load<Sprite>("golden")));
        deckHeavenly.Add(new Card(7, Resources.Load<Sprite>("2o4"), Resources.Load<Sprite>("golden")));
        deckHeavenly.Add(new Card(5, Resources.Load<Sprite>("2o5"), Resources.Load<Sprite>("golden")));

        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2d1"), Resources.Load<Sprite>("silver")));  // Despeje
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2d2"), Resources.Load<Sprite>("silver")));

        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2c1"), Resources.Load<Sprite>("emerald"))); // Clima
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2c2"), Resources.Load<Sprite>("emerald")));
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2c3"), Resources.Load<Sprite>("emerald")));

        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2a1"), Resources.Load<Sprite>("emerald"))); // Aumento
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2a2"), Resources.Load<Sprite>("emerald")));
        deckHeavenly.Add(new Card(0, Resources.Load<Sprite>("2a3"), Resources.Load<Sprite>("emerald")));
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
