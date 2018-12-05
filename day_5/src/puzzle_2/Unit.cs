using System;

public class Unit
{
    public char Type { get; private set; }
    public bool Polarity => char.IsLower(Type);

    public Unit(char type)
    {
        Type = type;
    }

    public override bool Equals(object obj)
    {
        return obj is Unit otherUnit && otherUnit.Type == Type;
    }

    public override int GetHashCode()
    {
        return (int)Type;
    }

    internal bool ReactsWith(Unit otherUnit)
    {
        return otherUnit != null
        && char.ToLower(otherUnit.Type) == char.ToLower(Type) // instead of making all types lower by default, which I should do
        && otherUnit.Polarity != Polarity;
    }
}