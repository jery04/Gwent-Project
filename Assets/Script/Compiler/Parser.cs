using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Numerics;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class Parser : MonoBehaviour
{
    // Properties
    public Token[] Tokens { get; }
    public List<string> Errors { get; private set; }
    public Token? CurrentToken { get; private set; }
    public int Index { get; private set; }


    // Builder
    public Parser(Token[] tokens)
    {
        this.Errors = new List<string>();
        this.Tokens = tokens;
        this.CurrentToken = null;
        this.Index = -1;
    }


    // Methods
    private bool ThereIsNext()
    {
        if (Index + 1 < Tokens.Length)
            return true;

        return false;
    }   // Retorna true si hay próximo
    private Token? LookAhead()
    {
        if (ThereIsNext())
            return Tokens[Index + 1];

        return null;
    }   // Retorna el próximo elemento (Sin avanzar)
    private bool LookAhead(bool chose, params Token.TokenType[] nextTokens)
    {
        foreach (Token.TokenType item in nextTokens)
        {
            if (item == LookAhead()?.Type)
            {
                if (chose)
                {
                    this.CurrentToken = Tokens[++Index];
                    return true;
                }
                else return true;
            }
        }
        return false;
    }   // Si chose es <true> y alguno de estos elementos coincide con el próximo, avanza y retorna true. Else retorna <true>
    private void Match()
    {
        if (ThereIsNext())
            CurrentToken = Tokens[++Index];
    }   // Avanza
    private void Match(params Token.TokenType[] nextTokens)
    {
        foreach (Token.TokenType item in nextTokens)
        {
            if (item == LookAhead()?.Type)
                this.CurrentToken = Tokens[++Index];
            else
                Errors.Add($"Error: No se esperaba un \"{LookAhead()?.Value}\" Line: {LookAhead()?.Line}, Column: {LookAhead()?.Column}");
        }
    }   // Avanza en el orden de parametros de entrada
    private Token? MatchReturn(params Token.TokenType[] nextTokens)
    {
        if (nextTokens.Length != 0)
        {
            foreach (Token.TokenType item in nextTokens)
            {
                if (item == LookAhead()?.Type)
                {
                    this.CurrentToken = Tokens[++Index];
                    return CurrentToken;
                }
            }
            Errors.Add($"Error: No se esperaba un \"{LookAhead()?.Value}\" Line: {LookAhead()?.Line}, Column: {LookAhead()?.Column}");
        }
        else
        {
            this.CurrentToken = Tokens[++Index];
            return CurrentToken;
        }

        return null;
    }   // Retorna uno de los coincidentes


    // Program (Beginning)
    public ProgramCompiler Parse()
    {
        ProgramCompiler ast = new ProgramCompiler();

        while (LookAhead(false, Token.TokenType.Effect))
            ast.Effect?.Add(EffectBuilder());

        while (LookAhead(false, Token.TokenType.Card))
            ast.Card?.Add(CardBuilder());

        if (Errors.Count != 0)
            for (int i = 0; i < Errors.Count; i++)
                Console.WriteLine($"{i + 1} {Errors[i]}");

        return ast;
    }


    // Effect Block
    public Effect EffectBuilder()
    {
        Effect effect = new Effect();

        Match(Token.TokenType.Effect, Token.TokenType.OpenKey);

        effect.NameField = FieldBuilder(Token.TokenType.Name);
        if (LookAhead()?.Type == Token.TokenType.Params)
            effect.Params = ParamsBuilder();
        effect.Action = ActionBuilder();

        Match(Token.TokenType.ClosedKey);

        return effect;
    }
    private Params ParamsBuilder()
    {
        Params param = new Params();

        Match(Token.TokenType.Params, Token.TokenType.Colon, Token.TokenType.OpenKey, Token.TokenType.Amount, Token.TokenType.Colon);
        param.Token = MatchReturn(Token.TokenType.UnKnown);
        Match(Token.TokenType.ClosedKey, Token.TokenType.SemiColon);

        return param;
    }
    private Action ActionBuilder() // Check It Out
    {
        Action action = new Action();

        Match(Token.TokenType.Action, Token.TokenType.Colon, Token.TokenType.OpenParan);
        action.Parameters?.Add(MatchReturn(Token.TokenType.UnKnown));
        Match(Token.TokenType.Comma);
        action.Parameters?.Add(MatchReturn(Token.TokenType.UnKnown));

        Match(Token.TokenType.ClosedParan, Token.TokenType.Arrow, Token.TokenType.OpenKey);
        action.Body = BodyBuilder();
        Match(Token.TokenType.ClosedKey);

        return action;
    }
    private BucleWhile WhileBuilder() // Not Yet
    {
        BucleWhile bucleWhile = new BucleWhile();

        Match(Token.TokenType.While, Token.TokenType.OpenParan);
        bucleWhile.Condition = BooleanBuilder();
        Match(Token.TokenType.ClosedParan);

        if (LookAhead(false, Token.TokenType.OpenKey))
        {
            Match(Token.TokenType.OpenKey);
            // TypeCode Here...
            Match(Token.TokenType.ClosedKey, Token.TokenType.SemiColon);
        }
        else
        {
            // Type Code Here...
        }

        return bucleWhile;
    }
    private BucleFor ForBuilder() //Not Yet
    {
        BucleFor bucleFor = new BucleFor();

        Match(Token.TokenType.For);
        // Type Code Here...

        if (LookAhead(false, Token.TokenType.OpenKey))
        {
            Match(Token.TokenType.OpenKey);
            // TypeCode Here...
            Match(Token.TokenType.ClosedKey, Token.TokenType.SemiColon);
        }
        else
        {
            // Type Code Here...
        }

        return bucleFor;
    }
    private Body BodyBuilder()
    {
        throw new NotImplementedException();
    }


    // Card Block
    public CardCompiler CardBuilder() // Not Yet
    {
        Console.WriteLine("Card");
        CardCompiler card = new CardCompiler();

        Match(Token.TokenType.Card, Token.TokenType.OpenKey);

        card.Type = FieldBuilder(Token.TokenType.Type);
        card.Name = FieldBuilder(Token.TokenType.Name);
        card.Faction = FieldBuilder(Token.TokenType.Faction);
        card.Power = NumberFieldBuilder();
        card.Range = RangeBuilder();
        card.ActivationBody = OnActivationBuilder();

        Match(Token.TokenType.ClosedKey);

        return card;
    }
    private StringField RangeBuilder()
    {
        StringField range = new StringField();

        Match(Token.TokenType.Range, Token.TokenType.Colon, Token.TokenType.OpenBracket);

        do
        {
            Match(Token.TokenType.Quote);
            range.Token?.Add(MatchReturn(Token.TokenType.UnKnown));
            Match(Token.TokenType.Quote);
        } while (LookAhead(true, Token.TokenType.Comma));

        Match(Token.TokenType.ClosedBracket, Token.TokenType.Comma);

        return range;
    }
    private StringField FieldBuilder(Token.TokenType tokenField)
    {
        StringField field = new StringField();

        Match(tokenField, Token.TokenType.Colon);

        do
        {
            Match(Token.TokenType.Quote);
            field.Token?.Add(MatchReturn(Token.TokenType.UnKnown));
            Match(Token.TokenType.Quote);
        } while (LookAhead(true, Token.TokenType.ATAT, Token.TokenType.AT));

        Match(Token.TokenType.Comma);

        return field;
    }
    private NumberField NumberFieldBuilder()
    {
        NumberField numberField = new NumberField();

        Match(Token.TokenType.Power, Token.TokenType.Colon);
        numberField.Expression = ExpressionBuilder();
        Match(Token.TokenType.Comma);

        return numberField;
    }
    private OnActivation OnActivationBuilder() // Not Yet
    {
        OnActivation activationBody = new OnActivation();

        Match(Token.TokenType.OnActivation, Token.TokenType.Colon, Token.TokenType.OpenBracket);
        activationBody.EffectActivation = EffectActivationBuilder();
        activationBody.Selector = SelectorBuilder();
        activationBody.PosAction = PosActionBuilder();
        Match(Token.TokenType.ClosedBracket);

        return activationBody;
    }
    private PosAction PosActionBuilder()
    {
        PosAction posAction = new PosAction();

        Match(Token.TokenType.PostAction, Token.TokenType.Colon, Token.TokenType.OpenKey);
        posAction.Type = FieldBuilder(Token.TokenType.Type);
        posAction.Selector = SelectorBuilder();
        Match(Token.TokenType.ClosedKey);

        return posAction;
    }

    private EffectActivation EffectActivationBuilder()
    {
        EffectActivation effect = new EffectActivation();

        Match(Token.TokenType.EffectActivation, Token.TokenType.Colon, Token.TokenType.OpenKey);
        effect.Name = FieldBuilder(Token.TokenType.Name);
        effect.Amount = NumberFieldBuilder();
        Match(Token.TokenType.ClosedKey, Token.TokenType.SemiColon);

        return effect;
    }
    private Selector SelectorBuilder()
    {
        Selector selector = new Selector();

        Match(Token.TokenType.Selector, Token.TokenType.Colon, Token.TokenType.OpenKey);
        selector.Name = FieldBuilder(Token.TokenType.Source);
        selector.Boolean = BooleanBuilder();
        selector.Predicate = PredicateBuilder();
        Match(Token.TokenType.ClosedKey, Token.TokenType.Comma);

        return selector;
    }
    private Boolean BooleanFieldBuilder()
    {
        Boolean boolean = new Boolean();

        Match(Token.TokenType.Single, Token.TokenType.Colon);
        boolean = BooleanBuilder();
        Match(Token.TokenType.Comma);

        return boolean;
    }
    private Predicate PredicateBuilder() // Not Yet
    {
        Predicate predicate = new Predicate();
        Match(Token.TokenType.Predicate, Token.TokenType.Colon);
        //Type Code Here...

        return predicate;
    }


    // Binary's Expressions
    private Expressions? ExpressionBuilder()
    {
        if (Index < Tokens.Length)
        {
            Expressions expression = new Expressions();
            expression.Term = TermsBuilder();

            if (LookAhead(true, Token.TokenType.Plus, Token.TokenType.Minus))
            {
                expression.Opeartor = MatchReturn(Token.TokenType.Plus, Token.TokenType.Minus);
                expression.Expression = ExpressionBuilder();
            }
            return expression;
        }
        return null;
    }
    private Terms? TermsBuilder()
    {
        if (Index < Tokens.Length)
        {
            Terms term = new Terms();
            term.Factor = FactorBuilder();
            if (LookAhead(true, Token.TokenType.Times, Token.TokenType.Divide))
            {
                term.Opeartor = MatchReturn(Token.TokenType.Times, Token.TokenType.Divide);
                term.Term = TermsBuilder();
            }
            return term;
        }
        return null;
    }
    private Factor? FactorBuilder()
    {
        if (Index < Tokens.Length)
        {
            Factor factor = new Factor();

            if (LookAhead(true, Token.TokenType.OpenParan))
            {
                Match();
                factor.Expression = ExpressionBuilder();
                Match(Token.TokenType.ClosedParan);
            }
            else
                factor.Leaf = MatchReturn(Token.TokenType.Number, Token.TokenType.UnKnown);

            return factor;
        }
        return null;
    }


    // Boolean's Expressions
    private Boolean BooleanBuilder() // Not Yet
    {
        Boolean boolean = new Boolean();
        if (LookAhead()?.Type == Token.TokenType.OpenParan)
        {
            Match(Token.TokenType.OpenParan);
            boolean.NodeLeft = SubBooleanBuilder();
            Match(Token.TokenType.ClosedParan);
        }
        else
            boolean.NodeLeft = SubBooleanBuilder();

        if (LookAhead(false, Token.TokenType.AND, Token.TokenType.OR))
        {
            boolean.LogOperator = MatchReturn();
            boolean.NodeRight = BooleanBuilder();
        }

        return boolean;
    }
    private SubBoolean SubBooleanBuilder()
    {
        SubBoolean subBoolean = new SubBoolean();

        if (LookAhead(false, Token.TokenType.OpenParan))
        {
            Match(Token.TokenType.OpenParan);
            subBoolean.NodeLeft = CapsuleBuilder();
            Match(Token.TokenType.ClosedParan);
        }
        else
            subBoolean.NodeLeft = CapsuleBuilder();

        if (LookAhead(false, Token.TokenType.AND, Token.TokenType.OR))
        {
            subBoolean.LogOperator = MatchReturn();
            subBoolean.NodeRight = BooleanBuilder();
        }

        return subBoolean;
    }
    public Capsule CapsuleBuilder()
    {
        Capsule capsule = new Capsule();

        if (LookAhead(false, Token.TokenType.Type, Token.TokenType.True))
            capsule.ArtOpeartor = MatchReturn();
        else
        {
            capsule.NodeLeft = AtomBuilder();
            capsule.ArtOpeartor = MatchReturn(Token.TokenType.Equal, Token.TokenType.LessThan,
                                  Token.TokenType.LessThanEqual, Token.TokenType.GreaterThan,
                                  Token.TokenType.GreaterThanEqual);
            capsule.NodeRight = AtomBuilder();
        }

        return capsule;
    }
    private Atom AtomBuilder()
    {
        Atom atom = new Atom();
        atom.Expression = ExpressionBuilder();
        if (LookAhead(false, Token.TokenType.PlusPlus))
            atom.OpIncrease = MatchReturn();

        return atom;
    }
}



// Program Class (Beginning) 
public class ProgramCompiler
{
    // Property
    public List<Effect>? Effect { get; set; }
    public List<CardCompiler>? Card { get; set; }
}


// Program's Class
#region


// Binary's Class
#region
public class Expressions
{
    // Property
    public Terms? Term { get; set; }
    public Expressions? Expression { get; set; }
    public Token? Opeartor { get; set; }
}
public class Terms
{
    // Property
    public Factor? Factor { get; set; }
    public Terms? Term { get; set; }
    public Token? Opeartor { get; set; }
}
public class Factor
{
    // Property
    public Token? Leaf { get; set; }
    public Expressions? Expression { get; set; }
}
#endregion


// Boolean's Class
#region
public class Boolean
{
    // Property 
    public Token? LogOperator { get; set; }
    public SubBoolean? NodeLeft { get; set; }
    public Boolean? NodeRight { get; set; }
}
public class SubBoolean
{
    // Property
    public Token? LogOperator { get; set; }
    public Capsule? NodeLeft { get; set; }
    public Boolean? NodeRight { get; set; }
}
public class Capsule
{
    // Property
    public Token? ArtOpeartor { get; set; }
    public Atom? NodeLeft { get; set; }
    public Atom? NodeRight { get; set; }
}
public class Atom
{
    // Property
    public Expressions? Expression { get; set; }
    public Token? OpIncrease { get; set; }
}
#endregion


// Effect Block
#region 
public class Effect
{
    // Property
    public StringField? NameField { get; set; }
    public Params? Params { get; set; }
    public Action? Action { get; set; }
}
public class StringField
{
    // Property
    public List<Token?>? Token { get; set; }
}
public class NumberField
{
    // Property
    public Expressions? Expression { get; set; }
}
public class Params
{
    // Property
    public Token? Token { get; set; }
}
public class Action
{
    // Property
    public List<Token?>? Parameters { get; set; }
    public List<Token?>? DataType { get; set; }
    public Body? Body { get; set; }
}
public class BucleWhile // Not Yet
{
    // Property
    public Boolean? Condition { get; set; }
    public Body? Body { get; set; }
}
public class BucleFor // Not Yet
{
    // Property
    public Body? Body { get; set; }
}
public class Body
{

}
#endregion


// Card Block
#region    
public class CardCompiler
{
    //Property
    public StringField? Type { get; set; }
    public StringField? Name { get; set; }
    public StringField? Faction { get; set; }
    public NumberField? Power { get; set; }
    public StringField? Range { get; set; }
    public OnActivation? ActivationBody { get; set; }
    public CardCompiler() { }
}
public class OnActivation
{
    // Property
    public EffectActivation? EffectActivation { get; set; }
    public Selector? Selector { get; set; }
    public PosAction? PosAction { get; set; }
}
public class EffectActivation
{
    // Property
    public StringField? Name { get; set; }
    public NumberField? Amount { get; set; }
}
public class Selector
{
    // Property
    public StringField? Name { get; set; }
    public Boolean? Boolean { get; set; }
    public Predicate? Predicate { get; set; }
}
public class PosAction
{
    // Property
    public StringField? Type { get; set; }
    public Selector? Selector { get; set; }
}
public class Predicate
{
    // Property

}



#endregion
#endregion
