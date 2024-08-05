using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Statement's Class
#region
#nullable enable
public abstract class GeneralStatement
{
    public abstract Utils.ReturnType? GetType(IScope scope);
    public abstract bool CheckSemantic(IScope scope);
    public abstract object? Evaluate(IScope scope);
}
public class Target: GeneralStatement
{
    public override object? Evaluate(IScope scope)
    {
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Utils.ReturnType.List;
    }
    public override bool CheckSemantic(IScope scope) { return true; }
}
public class Context: GeneralStatement
{
    public override object? Evaluate(IScope scope)
    {
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Utils.ReturnType.Context;
    }
    public override bool CheckSemantic(IScope scope) { return true; }
}
public class Parameters: GeneralStatement
{
    //Property
    public Utils.ReturnType? Type { get; set; }

    // Builder
    public Parameters(Utils.ReturnType? type)
    {
        this.Type = type;
    }

    // Methods
    public override object? Evaluate(IScope scope)
    {
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Type;
    }
    public override bool CheckSemantic(IScope scope) { return true; }
}
public class CardKey: GeneralStatement
{
    public override object? Evaluate(IScope scope)
    {
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Utils.ReturnType.Card;
    }
    public override bool CheckSemantic(IScope scope) { return true; }
}
public class Statement: GeneralStatement
{
    // Property 
    public Token? LogOperator { get; set; }
    public SubStatement? NodeLeft { get; set; }
    public Statement? NodeRight { get; set; }

    // Methods
    public override object? Evaluate(IScope scope)
    {
        if (!(NodeLeft is null) && !(NodeRight is null) && !(LogOperator is null))
        {
            bool boolean1 = Convert.ToBoolean(NodeLeft.Evaluate(scope));
            bool boolean2 = Convert.ToBoolean(NodeRight.Evaluate(scope));

            if (LogOperator.Type == Token.TokenType.AND)
                return boolean1 && boolean2;
            else
                return boolean1 || boolean2;
        }
        else
            return NodeLeft?.Evaluate(scope);
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        if (LogOperator != null)
            return Utils.ReturnType.Bool;

        else if (NodeLeft != null)
            return NodeLeft.GetType(scope);

        return null;
    }
    public override bool CheckSemantic(IScope scope)
    {
        if (NodeLeft != null && NodeRight != null)
        {
            if (!NodeLeft.CheckSemantic(scope) || !NodeRight.CheckSemantic(scope))
                return false;
        }
        else if (NodeLeft != null)
        {
            if (!NodeLeft.CheckSemantic(scope))
                return false;
        }
        return true;
    }
    public Token? Location()
    {
        return NodeLeft?.Location();
    }
}
public class SubStatement
{
    // Property
    public Token? LogOperator { get; set; }
    public Molecule? NodeLeft { get; set; }
    public Statement? NodeRight { get; set; }

    // Methods
    public object? Evaluate(IScope scope)
    {
        if (!(NodeLeft is null) && !(NodeRight is null) && !(LogOperator is null))
        {
            bool boolean1 = Convert.ToBoolean(NodeLeft.Evaluate(scope));
            bool boolean2 = Convert.ToBoolean(NodeRight.Evaluate(scope));

            if (LogOperator.Type == Token.TokenType.AND)
                return boolean1 && boolean2;
            else
                return boolean1 || boolean2;
        }
        else
            return NodeLeft?.Evaluate(scope);
    }
    public Utils.ReturnType? GetType(IScope scope)
    {
        if (LogOperator != null)
        {
            return Utils.ReturnType.Bool;
        }
        else if (NodeLeft != null)
        {
            return NodeLeft.GetType(scope);
        }
        return null;
    }
    public bool CheckSemantic(IScope scope)
    {
        if (NodeLeft != null && NodeRight != null)
        {
            if (!NodeLeft.CheckSemantic(scope) || !NodeRight.CheckSemantic(scope))
                return false;
        }
        else if (NodeLeft != null)
        {
            if (!NodeLeft.CheckSemantic(scope))
                return false;
        }
        return true;
    }
    public Token? Location()
    {
        return NodeLeft?.Location();
    }
}
public class Molecule: Instructions
{
    // Property
    public Token? ArtOpeartor { get; set; }
    public Atom? NodeLeft { get; set; }
    public Atom? NodeRight { get; set; }

    // Methods
    public object? Evaluate(IScope scope)
    {
        if (!(NodeLeft is null) && !(NodeRight is null) && !(ArtOpeartor is null))
        {
            if (ArtOpeartor.Type != Token.TokenType.Assignment && ArtOpeartor.Type != Token.TokenType.Increase)
                return Utils.LogOperator(NodeLeft.Evaluate(scope), NodeRight.Evaluate(scope), ArtOpeartor, NodeLeft.GetType(scope));

            else
            {
                //Type Code Here...
                throw new NotImplementedException();
            }
        }
        else
            return NodeLeft?.Evaluate(scope);
    }
    public Utils.ReturnType? GetType(IScope scope)
    {
        if (ArtOpeartor != null)
        {
            if (ArtOpeartor.Type != Token.TokenType.Increase && ArtOpeartor.Type != Token.TokenType.Decrease && ArtOpeartor.Type != Token.TokenType.Assignment)
                return Utils.ReturnType.Bool;
            else
                return Utils.ReturnType.Void;
        }
        else if (NodeLeft != null)
            return NodeLeft.GetType(scope);

        return null;
    }
    public override bool CheckSemantic(IScope scope)
    {
        bool check = true;
        if (NodeLeft != null && NodeRight != null)
        {
            if (!NodeLeft.CheckSemantic(scope) || !NodeRight.CheckSemantic(scope))
                check = false;

            if (NodeLeft?.GetType(scope) == NodeRight?.GetType(scope))
            {
                Utils.ReturnType? type = NodeLeft?.GetType(scope);

                if (ArtOpeartor?.Type != Token.TokenType.Equal && ArtOpeartor?.Type != Token.TokenType.Assignment
                    && (type == Utils.ReturnType.String || type == Utils.ReturnType.Bool))
                {
                    Utils.errors.Add(@$"No se puede establecer una relaci�n entre los tipos ""{type}"" mediante el operador ""{ArtOpeartor?.Value}"" Line: {ArtOpeartor?.Line} Column: {ArtOpeartor?.Column}");
                    check = false;
                }
            }
            else
            {
                Utils.errors.Add(@$"No se puede establecer una relaci�n entre los tipos ""{NodeLeft?.GetType(scope)}"" y ""{NodeRight?.GetType(scope)}"" Line: {ArtOpeartor?.Line} Column: {ArtOpeartor?.Column}");
                check = false;
            }
        }
        else if (NodeLeft != null)
            if (!NodeLeft.CheckSemantic(scope))
                check = false;

        return check;
    }
    public Token? Location()
    {
        return NodeLeft?.Location();
    }
}
public abstract class Atom
{
    // Abstract class
    public abstract Utils.ReturnType? GetType(IScope scope);
    public abstract bool CheckSemantic(IScope scope);
    public abstract object? Evaluate(IScope scope);
    public abstract Token? Location();
}
public class Atom0: Atom
{
    // Property
    public Token? Boolean { get; set; }

    //Methods
    public override object? Evaluate(IScope scope)
    {
        if (Boolean is not null)
        {
            if (Boolean.Type == Token.TokenType.True)
                return true;
            else if (Boolean.Type == Token.TokenType.False)
                return false;
        }
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Utils.ReturnType.Bool;
    }
    public override bool CheckSemantic(IScope scope)
    {
        return true;
    }
    public override Token? Location()
    {
        return Boolean;
    }
}
public class Atom1: Atom
{
    // Property
    public Expressions? Expression { get; set; }
    public Token? OpIncrease { get; set; }

    //Methods
    public override object? Evaluate(IScope scope)
    {
        if (OpIncrease is null)
            return Expression?.Evaluate(scope);
        else
        {
            // Type Code Here..
        }
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Expression?.GetType(scope);
    }
    public override bool CheckSemantic(IScope scope)
    {
        if (OpIncrease is not null)
        {
            if (Expression is not null)
            {
                if (!Expression.CheckSemantic(scope))
                    return false;

                if (Expression.GetType(scope) != Utils.ReturnType.Number)
                {
                    Utils.errors.Add(@$"No se puede asignar el operador ""{OpIncrease.Value}"" a un tipo ""{Expression.GetType(scope)}"" ");
                    return false;
                }
            }
        }
        else if (Expression is not null && !Expression.CheckSemantic(scope))
            return false;

        return true;
    }
    public override Token? Location()
    {
        return Expression?.Location();
    }
}
public class Atom2: Atom
{
    //Property
    public List<Token?>? Call { get; set; }
    public Atom2? Nested { get; set; }

    // Builder
    public Atom2()
    {
        this.Call = new List<Token?>();
    }

    //Methods
    public override object? Evaluate(IScope scope)
    {
        throw new NotImplementedException();
    }
    private void NullFill()
    {
        if (Call is not null && Call.Count < 7)
            for (int i = 0; i < 6; i++)
                Call.Add(null);
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        NullFill();
        if (Call is not null)
        {
            if (scope.GetType(Call[0]?.Value, scope) == Utils.ReturnType.Card)
            {
                if (Call[1] is not null)
                {
                    if (Call[1]?.Value == "Power")
                        return Utils.ReturnType.Number;
                    else
                        return Utils.ReturnType.String;
                }
                else return Utils.ReturnType.Card;
            }
            else if (scope.GetType(Call[0]?.Value, scope) == Utils.ReturnType.Context)
            {
                if (Call[1] is not null)
                {
                    if (Call[2] is not null)
                    {
                        if (Call[2]?.Value == "Find")
                            return Utils.ReturnType.List;

                        else if (Call[2]?.Value == "Pop")
                            return Utils.ReturnType.Card;

                        else
                            return Utils.ReturnType.Void;
                    }
                    else
                    {
                        if (Call[1]?.Value == "TriggerPlayer")
                            return Utils.ReturnType.String;
                        else
                            return Utils.ReturnType.List;
                    }
                }
                else return Utils.ReturnType.Context;
            }
            else if (scope.GetType(Call[0]?.Value, scope) == Utils.ReturnType.List)
            {
                if (Call[1] is not null)
                {
                    if (Call[1]?.Value == "Find")
                        return Utils.ReturnType.List;

                    else if (Call[1]?.Value == "Pop")
                        return Utils.ReturnType.Card;

                    else
                        return Utils.ReturnType.Void;
                }
                else return Utils.ReturnType.List;
            }
            else
                return scope.GetType(Call[0]?.Value, scope);
        }
        return Utils.ReturnType.Void;
    }
    public override bool CheckSemantic(IScope scope)
    {
        NullFill();
        if (Call is not null)
        {
            if (scope.IsDefined(Call[0]?.Value))
            {
                if (scope.GetType(Call[0]?.Value, scope) == Utils.ReturnType.List)
                {

                    if (!(Call[1] is null) && !Utils.listMethods.Contains(Call[1]?.Value))
                    {
                        Utils.errors.Add(@$"""{Call[0]?.Value}"" no tiene una definici�n para ""{Call[1]?.Value}"" Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                        return false;
                    }
                    else if (Call[1] is not null)
                    {
                        if (Call[1]?.Value == "Remove" || Call[1]?.Value == "Push" || Call[1]?.Value == "SendBottom" || Call[1]?.Value == "Add")
                        {
                            if (Nested is not null)
                            {
                                if (Nested.CheckSemantic(scope))
                                {
                                    if (Nested.GetType(scope) != Utils.ReturnType.Card)
                                    {
                                        Utils.errors.Add(@$"El m�todo ""{Call[1]?.Value}"" recibe una carta como par�metro Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                                        return false;
                                    }
                                }
                                else return false;
                            }
                            else
                            {
                                Utils.errors.Add(@$"El m�todo ""{Call[1]?.Value}"" recibe una carta como par�metro Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                                return false;
                            }
                        }
                        else if (Nested is not null)
                        {
                            Utils.errors.Add(@$"El m�todo ""{Call[1]?.Value}"" no recibe par�metros en su definici�n Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                            return false;
                        }
                    }
                }
                else if (scope.GetType(Call[0]?.Value, scope) == Utils.ReturnType.Context)
                {
                    if (Call[1] is not null)
                    {
                        if (!Utils.context.Contains(Call[1]?.Value))
                        {
                            Utils.errors.Add(@$"""{Call[0]?.Value}"" no tiene una definici�n para "" {Call[1]?.Value}"" Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                            return false;
                        }
                        else
                        {
                            if (Call[1]?.Value == "Hand" || Call[1]?.Value == "Deck" || Call[1]?.Value == "Field" || Call[1]?.Value == "Graveyard" || Call[1]?.Value == "Board")
                            {
                                if (Call[2] is not null)
                                {
                                    if (!Utils.listMethods.Contains(Call[2]?.Value))
                                    {
                                        Utils.errors.Add(@$"""{Call[1]?.Value}"" no tiene una definici�n para ""{Call[2]?.Value}"" Line: {Call[2]?.Line} Column: {Call[2]?.Column} ");
                                        return false;
                                    }
                                    else
                                    {
                                        if (Call[2]?.Value == "Remove" || Call[2]?.Value == "Push" || Call[2]?.Value == "SendBottom" || Call[2]?.Value == "Add")
                                        {
                                            if (Nested is not null)
                                            {
                                                if (Nested.CheckSemantic(scope))
                                                {
                                                    if (Nested.GetType(scope) != Utils.ReturnType.Card)
                                                    {
                                                        Utils.errors.Add(@$"El m�todo ""{Call[2]?.Value}"" recibe una carta como par�metro Line: {Call[2]?.Line} Column: {Call[2]?.Column} ");
                                                        return false;
                                                    }
                                                }
                                                else return false;
                                            }
                                            else
                                            {
                                                Utils.errors.Add(@$"El m�todo ""{Call[2]?.Value}"" recibe una carta como par�metro Line: {Call[2]?.Line} Column: {Call[2]?.Column} ");
                                                return false;
                                            }
                                        }
                                        else if (Nested is not null)
                                        {
                                            Utils.errors.Add(@$"El m�todo ""{Call[2]?.Value}"" no recibe par�metros en su definici�n Line: {Call[2]?.Line} Column: {Call[2]?.Column} ");
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    Utils.errors.Add(@$"El m�todo ""{Call[1]?.Value}"" recibe una carta como par�metro Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                                    return false;
                                }
                            }
                            else if (Call[1]?.Value != "TriggerPlayer")
                            {
                                if (Nested is not null)
                                {
                                    if (Nested.CheckSemantic(scope))
                                    {
                                        if (Nested.GetType(scope) != Utils.ReturnType.String)
                                        {
                                            Utils.errors.Add(@$"El m�todo ""{Call[1]?.Value}"" recibe un ""String"" como par�metro Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                                            return false;
                                        }
                                    }
                                    else return false;
                                }
                                else
                                {
                                    Utils.errors.Add(@$"El m�todo ""{Call[1]?.Value}"" recibe un ""String"" como par�metro Line: {Call[1]?.Line} Column: {Call[1]?.Column} ");
                                    return false;
                                }
                            }
                        }
                    }
                }
                else if (scope.GetType(Call[0]?.Value, scope) == Utils.ReturnType.Card)
                {
                    if (Call[1] is not null)
                    {
                        if (!Utils.card.Contains(Call[1]?.Value))
                        {
                            Utils.errors.Add(@$"""{Call[1]?.Value}"" no tiene una definici�n para ""{Call[2]?.Value}"" Line: {Call[2]?.Line} Column: {Call[2]?.Column} ");
                            return false;
                        }
                    }
                }
            }
            else
            {
                Utils.errors.Add(@$"La variable ""{Call[0]?.Value}"" no existe en el contexto actual Line: {Call[0]?.Line} Column: {Call[0]?.Column} ");
                return false;
            }
        }

        return true;
    }
    public override Token? Location()
    {
        return Call?[0];
    }
}
public class Atom3: Atom
{
    //Property
    public List<Token?>? String { get; set; }

    //Builder
    public Atom3()
    {
        this.String = new List<Token?>();
    }

    // Methods
    public override object? Evaluate(IScope scope)
    {
        string result = "";
        if (String is not null)
        {
            foreach (Token? item in String)
            {
                if (item?.Type == Token.TokenType.ATAT)
                    result += " ";
                else if (item?.Type == Token.TokenType.AT)
                    continue;
                else
                    result += item?.Value;
            }
            return result;
        }
        return null;
    }
    public override Utils.ReturnType? GetType(IScope scope)
    {
        return Utils.ReturnType.String;
    }
    public override bool CheckSemantic(IScope scope)
    {
        return true;
    }
    public override Token? Location()
    {
        return String?[0];
    }
}
#endregion
