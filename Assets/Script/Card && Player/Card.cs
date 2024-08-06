using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    // Propiedades (Campo) 
    public new string name;                                                             // Nombre de la carta
    public string faction;                                                              // Faccion de la carta
    public int power;                                                                   // Poder(unidad), daño(clima) o incremento(aumento)
    public string description;
    public Sprite artWork;                                                              // Imagen principal
    public Sprite portrait;                                                             // Imagen del marco
    public enum card_position { M, R, S, MR, MS, RS, MRS, I, C, L};                     // Posiciones en que se puede ubicar
    public enum kind_card { golden, silver, climate, clear, bait, increase, leader };   // Tipos de carta
    public kind_card typeCard;                                                          // Tipo de carta
    public card_position cardPosition;                                                  // Tipo de posición
    public bool isUnity;                                                                // Es carta unidad?
    public bool isHeroe;                                                                // Es carta héroe?
    public delegate void EffectDelegate(params object[] item);
    public EffectDelegate effect;                                                       // Delegado que almacena el efecto(Método)
    private AudioClip clip;                                                             // Audio de las cartas al colocarse
    public int affectedRow;                                                             // Fila que afectan las cartas climas

    // Constructores (Sobrecargado) 
    public Card(string name, string faction, int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition, string description, EffectDelegate effect, AudioClip clip = null)
    {
        this.name = name;
        this.faction = faction;
        this.power = power;
        this.isUnity = IsUnity;
        this.isHeroe = IsHeroe;
        this.artWork = artWork;
        this.portrait = portrait;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.description = description;
        this.effect = effect;
        this.clip = clip;
    }
    public Card(string name, string faction, int power, int affectedRow, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition, string description, EffectDelegate effect, AudioClip clip = null)
    {
        this.name = name;
        this.faction = faction;
        this.power = power;
        this.affectedRow = affectedRow;
        this.isUnity = IsUnity;
        this.isHeroe = IsHeroe;
        this.artWork = artWork;
        this.portrait = portrait;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.description = description;
        this.effect = effect;
        this.clip = clip;
    }
    public Card(string name, string faction, int power, kind_card typeCard, card_position cardPosition)
    {
        this.name = name;
        this.faction = faction;
        this.power = power;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
    }

    // Métodos
    public void ActiveClip()                                                            // Activa el AudioClip de la carta (En caso de que contenga)
    {
        if(clip != null)
        {
            AudioSource audioEffect = GameObject.Find("MusicCards").GetComponent<AudioSource>();
            audioEffect.clip = this.clip;
            audioEffect.Play();
        }
    }
}
public class CardCompiler : Card
{
    public OnActivation effects { get; private set; }
    private IScope scope { get; set; }

    public CardCompiler(string name, string faction, int power, kind_card typeCard, card_position cardPosition, OnActivation effects, IScope scope)
        : base(name, faction, power, typeCard, cardPosition)
    {
        this.effects = effects;
        this.scope = scope;
        this.isHeroe = IsHeroe(typeCard);
        this.isUnity = IsUnity(typeCard);
        artWork = Resources.Load<Sprite>("cc");
        portrait = Portrait(typeCard);
        this.description = Description_Maker(scope);
    }
    private string Description_Maker(IScope scope)
    {
        string description = $"{this.name} it's a card made in a compiler. ";
        List<string> effect_names = GetEffectNames(effects, scope);

        if (effect_names.Count == 0)
            description += "It doesn't contain effects.";
        else
        {
            description += $@"Contains {effect_names.Count} effect(s) called";
            for(int i = 0; i < effect_names.Count; i++)
            {
                if(i != 0)
                {
                    if (i == effect_names.Count - 1)
                        description += $@" y";
                    else
                        description += $@",";
                }

                description += @$" ""{effect_names[i]}""";
            }
            description += ".";
        }

        return description;
    }
    private List<string> GetEffectNames(OnActivation effects, IScope scope)
    {
        List<string> effect_list = new List<string>(); 

        if(effects is not null)
        {
            foreach (OnActivationBody body in effects.Body) 
            {
                if(body is not null)
                {
                    effect_list.Add(Convert.ToString(body.EffectActivation.Name.Evaluate(scope)));

                    if(body.PosAction is not null)
                        foreach (PosAction pos_action in body.PosAction)
                            effect_list.Add(Convert.ToString(pos_action.Name.Evaluate(scope)));
                }
            }
        }

        return effect_list;
    }
    private static Sprite Portrait(kind_card typeCard)
    {
        if (typeCard == Card.kind_card.golden)
            return Resources.Load<Sprite>("golden");

        else if (typeCard == Card.kind_card.silver)
            return Resources.Load<Sprite>("silver");

        return Resources.Load<Sprite>("emerald");
    }
    private static bool IsHeroe(kind_card typeCard)
    {
        if (typeCard == Card.kind_card.golden)
            return true;

        return false;
    }
    private static bool IsUnity(kind_card typeCard)
    {
        if (typeCard == Card.kind_card.golden || typeCard == Card.kind_card.silver)
            return true;

        return false;
    }
}
