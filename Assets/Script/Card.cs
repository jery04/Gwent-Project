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
    public int power;                                                                   // Poder
    public Sprite artWork;                                                              // Imagen principal
    public Sprite portrait;                                                             // Imagen del marco
    public enum card_position { M, R, S, MR, MS, RS, MRS, I, C};                        // Posiciones en que se puede ubicar
    public enum kind_card { golden, silver, climate, clear, bait, increase, leader };   // Tipos de carta
    public kind_card typeCard;                                                          // Tipo de carta
    public card_position cardPosition;                                                  // Tipo de posición
    public bool IsUnity;                                                                // Es carta Unidad?
    public bool IsHeroe;                                                                // Es carta héroe
    public delegate void EffectDelegate(params object[] item);
    public EffectDelegate effect;                                                       // Delegado que almacena el efecto
    private AudioClip clip;

    // Constructores (Sobrecargado)
    public Card(string name, int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, AudioClip clip = null)
    {
        this.name = name;
        this.typeCard = typeCard;
        this.IsUnity = IsUnity;
        this.IsHeroe = IsHeroe;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
        this.clip = clip;
    }
    public Card(string name, int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, EffectDelegate effect, AudioClip clip = null)
    {
        this.name = name;
        this.effect = effect;
        this.typeCard = typeCard;
        this.IsUnity = IsUnity;
        this.IsHeroe = IsHeroe;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
        this.clip = clip;
    }
    public Card(string name, int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition, AudioClip clip = null)
    {
        this.name = name;
        this.IsUnity = IsUnity;
        this.IsHeroe = IsHeroe;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
        this.clip = clip;
    }
    public Card(string name, int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition, EffectDelegate effect)
    {
        this.name = name;
        this.effect = effect;
        this.IsUnity = IsUnity;
        this.IsHeroe = IsHeroe;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
    }
    public Card(string name, int power, bool IsUnity, bool IsHeroe, Sprite artWork, Sprite portrait, kind_card typeCard, card_position cardPosition, EffectDelegate effect, AudioClip clip = null)
    {
        this.name = name;
        this.effect = effect;
        this.IsUnity = IsUnity;
        this.IsHeroe = IsHeroe;
        this.typeCard = typeCard;
        this.cardPosition = cardPosition;
        this.power = power;
        this.artWork = artWork;
        this.portrait = portrait;
        this.clip = clip;
    }

    // Métodos
    public void ActiveClip()
    {
        if(clip != null)
        {
            AudioSource audioEffect = GameObject.Find("MusicCards").GetComponent<AudioSource>();
            audioEffect.clip = this.clip;
            audioEffect.Play();
        }
    }
}
