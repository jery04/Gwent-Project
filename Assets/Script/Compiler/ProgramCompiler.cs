using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Program (Beginning)
public class ProgramCompiler : ISemantic
{
    // Property
    public List<EffectBlock>? Effect { get; set; }
    public List<CardBlock>? Card { get; set; }

    // Builder
    public ProgramCompiler()
    {
        this.Effect = new List<EffectBlock>();
        this.Card = new List<CardBlock>();
    }

    // Methods
    public void Evaluate(IScope scope)
    {
        if (Card != null)
            foreach (CardBlock card in Card)
                card.Evaluate(scope);
    }
    public bool CheckSemantic(IScope scope)
    {
        if (Effect != null)
            foreach (EffectBlock effect in Effect)
                if (!effect.CheckSemantic(scope))
                    return false;

        if (Card != null)
            foreach (CardBlock card in Card)
                if (!card.CheckSemantic(scope))
                    return false;

        return true;
    }
}
