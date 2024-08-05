using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable
public interface IParsing
{
    ProgramCompiler Parse();
}
public interface ISemantic
{
    public bool CheckSemantic(IScope scope);
}
public interface IScope
{
    public Scope? Parent { get; set; }
    public Dictionary<string, GeneralStatement?> Defined { get; set; }
    public bool IsDefined(string? search);
    public void Define(Variable variable);
    public Scope CreateChild();
    public Utils.ReturnType? GetType(string? search, IScope scope);
}
