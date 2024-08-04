using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEngine.GraphicsBuffer;

// Effect Block
#region  
public class EffectBlock : ISemantic
{
    // Property
    public Variable? Name { get; set; }
    public Params? Params { get; set; }
    public Action? Action { get; set; }

    // Methods
    public void Evaluate()
    {
        throw new NotImplementedException();
    }
    public bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (Name is not null && !Name.CheckSemantic(scope))
            check = false;

        if (Params is not null)
            Params.AddParams(Convert.ToString(Name?.Evaluate(scope)), scope);
        else
            Utils.AddEffect(Convert.ToString(Name?.Evaluate(scope)));

        if (Action is not null && !Action.CheckSemantic(scope))
            check = false;

        return check;
    }
}
public class Params
{
    // Property
    public Dictionary<Token, Utils.ReturnType?> Parameters { get; set; }

    // Builder
    public Params()
    {
        this.Parameters = new Dictionary<Token, Utils.ReturnType?>();
    }

    // Methods
    public void AddParams(string? effect, IScope scope)
    {
        Utils.AddEffect(effect);

        if (effect is not null)
        {
            foreach (Token item in Parameters.Keys)
            {
                Utils.effects[effect].Add(item.Value, Parameters[item]);
                scope.Define(new Variable(item, new Parameters(Parameters[item])));
            }
        }
    }
}
public class Action
{
    // Property
    public List<Token?>? Parameters { get; set; }
    public List<Instructions?>? Instruction { get; set; }

    // Builder
    public Action()
    {
        this.Parameters = new List<Token?>();
        this.Instruction = new List<Instructions?>();
    }

    // Methods
    public bool CheckSemantic(IScope scope)
    {
        bool check = true;

        IScope child = scope.CreateChild();
        child.Define(new Variable(Parameters?[0], new Target()));
        child.Define(new Variable(Parameters?[1], new Context()));

        if (Instruction is not null)
            foreach (Instructions? item in Instruction)
                if (item is not null && !item.CheckSemantic(child))
                    check = false;

        return check;
    }
}
public abstract class Instructions
{
    // Abstract Class
    public abstract bool CheckSemantic(IScope scope);
}
public class BucleWhile : Instructions
{
    // Property
    public Statement? Condition { get; set; }
    public List<Instructions?>? Instruction { get; set; }

    //Methods
    public override bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (Condition is not null)
        {
            if (Condition.CheckSemantic(scope))
            {
                if (!(Instruction is null) && Condition.GetType(scope) == Utils.ReturnType.Bool)
                {
                    IScope child = scope.CreateChild();

                    foreach (Instructions? item in Instruction)
                        if (item is not null && !item.CheckSemantic(child))
                            check = false;
                }
                else if (Instruction is not null)
                {
                    Token? warn = Condition.Location();
                    Utils.errors.Add($@"El condicional del while no retorna un booleano Line: {warn?.Line} Column: {warn?.Column}");
                    return false;
                }
            }
            else
                return false;
        }
        return check;
    }
}
public class BucleFor : Instructions
{
    // Property
    public Token? Iterator { get; set; }
    public Token? List { get; set; }
    public List<Instructions?>? Instruction { get; set; }

    // Methods
    public override bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (!(List is null) && scope.IsDefined(List.Value))
        {
            if (scope.GetType(List.Value, scope) != Utils.ReturnType.List)
            {
                Utils.errors.Add(@$"El for deber�a iterar sobre una lista Line: {List?.Line} Column: {List?.Column}");
                check = false;
            }
        }
        else
        {
            Utils.errors.Add(@$"La variable {List?.Value} no existe en el contexto actual Line: {List?.Line} Column: {List?.Column}");
            check = false;
        }

        if (Instruction is not null)
        {
            IScope child = scope.CreateChild();
            child.Define(new Variable(Iterator, new CardKey()));

            foreach (Instructions? item in Instruction)
                if (item is not null && !item.CheckSemantic(child))
                    check = false;
        }
        return check;
    }
}
public class Variable : Instructions, ISemantic
{
    // Properties
    public Token? Name { get; set; }
    public GeneralStatement? Value { get; set; }

    // Builder
    public Variable() { }
    public Variable(Token? token, GeneralStatement? statement)
    {
        Name = token;
        Value = statement;
    }

    // Methods
    public virtual object? Evaluate(IScope scope)
    {
        return Value?.Evaluate(scope);
    }
    public Utils.ReturnType? GetType(IScope scope)
    {
        return Value?.GetType(scope);
    }
    public override bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (CardFieldIdentify())
        {
            if (Name?.Type == Token.TokenType.Power)
            {
                if (Value is not null && Value.CheckSemantic(scope))
                {
                    if (Utils.ReturnType.Number != Value?.GetType(scope))
                    {
                        Utils.errors.Add($@"El campo ""Power"" no acepta valores de tipo ""{Value?.GetType(scope)}"" Line: {Name.Line} Column: {Name.Column}");
                        return false;
                    }
                }
            }
            else if (Value is not null && Value.CheckSemantic(scope))
            {
                if (Utils.ReturnType.String != Value?.GetType(scope))
                {
                    Utils.errors.Add($@"El campo ""{Name?.Type}"" no acepta valores de tipo ""{Value?.GetType(scope)}"" Line: {Name?.Line} Column: {Name?.Column}");
                    return false;
                }
            }
            else return false;
        }
        else
        {
            if (Name?.Type == Token.TokenType.Source)
            {
                if (Value is not null && Value.CheckSemantic(scope))
                {
                    if (Utils.ReturnType.String != Value?.GetType(scope))
                    {
                        Utils.errors.Add($@"El campo ""Source"" no acepta valores de tipo ""{Value?.GetType(scope)}"" Line: {Name.Line} Column: {Name.Column}");
                        return false;
                    }
                }
            }
            else if (Name?.Type == Token.TokenType.Single)
            {
                if (Value is not null && Value.CheckSemantic(scope))
                {
                    if (Utils.ReturnType.Bool != Value?.GetType(scope))
                    {
                        Utils.errors.Add($@"El campo ""Single"" no acepta valores de tipo ""{Value?.GetType(scope)}"" Line: {Name.Line} Column: {Name.Column}");
                        return false;
                    }
                }
            }
            else
            {
                if (!(Value is null) && !Value.CheckSemantic(scope))
                    check = false;

                if (Value is not null)
                    scope.Define(this);
            }
        }
        return check;
    }
    private bool CardFieldIdentify()
    {
        if (Name != null)
            return (Utils.fieldCard.Contains(Name.Type));
        else
            return false;
    }
    public string? ReturnName()
    {
        return Name?.Value;
    }
}
public class Array : Variable
{
    // Property
    public new List<Atom?>? Value { get; set; }

    //Builder
    public Array()
    {
        Value = new List<Atom?>();
    }

    // Methods
    public override object? Evaluate(IScope scope)
    {
        bool[] position = new bool[3];
        if (Value is not null)
        {
            foreach (Atom? atom in Value)
            {
                string? pos = Convert.ToString(atom?.Evaluate(scope));
                if (pos == "Melee")
                    position[0] = true;

                else if (pos == "Range")
                    position[1] = true;

                else if (pos == "Distance")
                    position[2] = true;

                else Utils.errors.Add(@$"La posici�n ""{pos}"" no existe.");
            }
        }

        if (position[0] && position[1] && position[2])
            return Card.card_position.MRS;

        else if (position[0] && position[1])
            return Card.card_position.MR;

        else if (position[0] && position[2])
            return Card.card_position.MS;

        else if (position[1] && position[2])
            return Card.card_position.RS;

        else if (position[0])
            return Card.card_position.M;

        else if (position[1])
            return Card.card_position.R;

        else if (position[2])
            return Card.card_position.S;

        return null;
    }
    public new Utils.ReturnType? GetType()
    {
        return Utils.ReturnType.String;
    }
    public override bool CheckSemantic(IScope scope)
    {
        bool check = true;

        if (Value is not null)
        {
            int i = 1;
            foreach (Atom? item in Value)
            {
                if ((item != null) && (item.CheckSemantic(scope)))
                {
                    if (item.GetType(scope) != Utils.ReturnType.String)
                    {
                        Utils.errors.Add($@"El elemento {i} del array {Name?.Type} no es de tipo ""String"" ");
                        check = false;
                    }
                }
                else check = false;
                i++;
            }
        }
        return check;
    }
}
#endregion
