using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Card Block
#region
#nullable enable
public class CardBlock : ISemantic
{
    //Property 
    public Variable? Type { get; set; }
    public Variable? Name { get; set; }
    public Variable? Faction { get; set; }
    public Variable? Power { get; set; }
    public Variable? Range { get; set; }
    public OnActivation? OnActivation { get; set; }

    // Methods
    public void Evaluate(IScope scope)
    {
        throw new NotImplementedException();
    }
    public bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (!(Type is null) && !Type.CheckSemantic(scope))
            check = false;

        if (!(Name is null) && !Name.CheckSemantic(scope))
            check = false;

        if (!(Faction is null) && !Faction.CheckSemantic(scope))
            check = false;

        if (!(Power is null) && !Power.CheckSemantic(scope))
            check = false;

        if (!(Range is null) && !Range.CheckSemantic(scope))
            check = false;

        if (!(OnActivation is null) && !OnActivation.CheckSemantic(scope))
            check = false;

        return check;
    }
}
public class OnActivation
{
    // Property
    public List<OnActivationBody?>? Body { get; set; }

    // Builder 
    public OnActivation()
    {
        this.Body = new List<OnActivationBody?>();
    }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        if (Body != null && Body.Count > 0)
            foreach (OnActivationBody? item in Body)
                if (!(item is null) && !item.CheckSemantic(scope))
                    return false;

        return true;
    }
}
public class OnActivationBody
{
    // Property
    public EffectActivation? EffectActivation { get; set; }
    public Selector? Selector { get; set; }
    public List<PosAction?>? PosAction { get; set; }

    // Builder
    public OnActivationBody()
    {
        this.PosAction = new List<PosAction?>();
    }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (!(EffectActivation is null) && !EffectActivation.CheckSemantic(scope))
            check = false;

        if (!(Selector is null) && !Selector.CheckSemantic(scope))
            check = false;

        if (PosAction is not null)
            foreach (PosAction? item in PosAction)
                if (!(item is null) && !item.CheckSemantic(scope))
                    check = false;

        return check;
    }
}
public class EffectActivation
{
    // Property
    public Variable? Name { get; set; }
    public List<Variable?>? Parameters { get; set; }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        string? nameEffect = Convert.ToString(Name?.Evaluate(scope));
        if (Name is not null)
        {
            if (Name.CheckSemantic(scope))
            {
                if (Utils.ContainsEffect(nameEffect))
                {
                    if (Utils.CheckAmountParams(nameEffect, Parameters?.Count))
                    {
                        for (int i = 0; i < Parameters?.Count; i++)
                        {
                            string? param = Convert.ToString(Parameters[i]?.ReturnName())?.ToLower();
                            if (Utils.ContainsParameter(nameEffect, param))
                            {
                                if (Utils.ReturnTypeParams(nameEffect, param) != Parameters[i]?.GetType(scope))
                                {
                                    Utils.errors.Add(@$"El tipo de retorno de ""{param}"" no coincide con la definición del efecto ""{nameEffect}"" ");
                                    return false;
                                }
                            }
                            else
                            {
                                Utils.errors.Add($@"El parámetro ""{param}"" no está declarado en ""{nameEffect}"" ");
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Utils.errors.Add(@$"La cantidad de parámetros no coincide con la definición del efecto ""{nameEffect}"" ");
                        return false;
                    }
                }
                else
                {
                    Utils.errors.Add(@$"El efecto ""{nameEffect}"" no ha sido declarado ");
                    return false;
                }
            }
            else return false;
        }
        return true;
    }
}
public class Selector
{
    // Property
    public Variable? Source { get; set; }
    public Variable? Single { get; set; }
    public Predicate? Predicate { get; set; }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (Source is not null && !Source.CheckSemantic(scope))
            check = false;

        if (Single is not null && !Single.CheckSemantic(scope))
            check = false;

        if (Predicate is not null && !Predicate.CheckSemantic(scope))
            check = false;

        return check;
    }
}
public class PosAction
{
    // Property
    public Variable? Name { get; set; }
    public Selector? Selector { get; set; }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (Name is not null)
        {
            if (Name.CheckSemantic(scope))
            {
                string? nameEffect = Convert.ToString(Name?.Evaluate(scope));
                if (!Utils.ContainsEffect(nameEffect))
                {
                    Utils.errors.Add(@$"El efecto ""{nameEffect}"" no está declarado Line: {Name?.Name?.Line} Column: {Name?.Name?.Column}");
                    check = false;
                }
            }
            else
                check = false;
        }

        if (Selector is not null)
            if (!Selector.CheckSemantic(scope))
                check = false;

        return check;
    }
}
public class Predicate
{
    // Property
    public Token? Card { get; set; }
    public Statement? Condition { get; set; }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        IScope child = scope.CreateChild();

        child.Define(new Variable(Card, new CardKey()));

        if (Condition is not null && !Condition.CheckSemantic(child))
            return false;

        return true;
    }
}
#endregion
