namespace Operators;

public class Animal // This is the base type for all animals.
{
    public string? Name;
    public DateTime Born;
    public byte Legs;
}

public class Cat : Animal // This is a subtype of animal.
{
    public bool IsDomestic;
}

public class Spider : Animal // This is another subtype of animal.
{
    public bool IsPoisonous;
}