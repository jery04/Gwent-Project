using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : IScope
{
    // Property
    public Scope? Parent { get; set; }
    public Dictionary<string, GeneralStatement?> Defined { get; set; }

    // Builder
    public Scope()
    {
        this.Defined = new Dictionary<string, GeneralStatement?>();
        this.Parent = null;
    }

    // Methods
    public Utils.ReturnType? GetType(string? search, IScope scope)
    {
        if ((search != null) && scope.IsDefined(search))
        {
            if (scope.Defined.ContainsKey(search))
                return scope.Defined[search]?.GetType(scope);

            else if (scope.Parent != null)
                return scope.Parent.GetType(search, scope.Parent);
        }

        return null;
    }
    public void Define(Variable variable)
    {
        if (!(variable.Name?.Value is null) && !Defined.ContainsKey(variable.Name.Value))
            Defined.Add(variable.Name.Value, variable.Value);
    }
    public bool IsDefined(string? search)
    {
        if (search is not null)
        {
            if (Defined.ContainsKey(search))
                return true;

            else if (Parent != null)
                return Parent.IsDefined(search);
        }

        return false;
    }
    public Scope CreateChild()
    {
        Scope child = new Scope();
        child.Parent = this;

        return child;
    }
}
