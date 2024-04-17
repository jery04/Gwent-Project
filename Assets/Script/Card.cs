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
    public Card(string name, string faction , int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, string description, EffectDelegate effect, AudioClip clip = null)
    {
        this.name = name;
        this.faction = faction;
        this.power = power;
        this.isUnity = IsUnity;
        this.isHeroe = IsHeroe;
        this.artWork = artWork;
        this.portrait = portrait;
        this.typeCard = typeCard;
        this.description = description;
        this.effect = effect;
        this.clip = clip;
    }
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
