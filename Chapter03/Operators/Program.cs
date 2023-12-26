using Operators;

# region Exploring unary operators
int a = 3;
int b = a++;
WriteLine($"a is {a}, b is {b}");
#endregion

WriteLine();

#region Exploring binary arithmetic operators
int e = 11;
int f =  3;
WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e * f = {e * f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}");

WriteLine();

double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}");
#endregion

WriteLine();

#region Branching with the switch statement
// Inclusive lower bound but exclusive upper bound.
int number = Random.Shared.Next(minValue: 1, maxValue: 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // Jumps to end of switch statement.
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3: // Multiple case section
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
} // End of switch statement.
WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");
#endregion

WriteLine();

#region Pattern matching with the switch statement
var animals = new Animal?[]
{
    new Cat { Name = "Karen", Born = new(year: 2022, month: 8, day: 23), Legs = 4, IsDomestic = false },
    null,
    new Cat { Name = "Mufasa", Born = new(year: 1994, month: 6, day:12) },
    new Spider { Name = "Sid Vicious", Born = DateTime.Today, IsPoisonous = true },
    new Spider { Name = "Captain Furry", Born = DateTime.Today }
};

foreach (Animal? animal in animals)
{
    string message;
    switch (animal)
    {
        case Cat { Legs: 4 } fourLeggedCat: // Cat fourLeggedCat when fourLeggedCat.Legs == 4:
            message = $"The cat named {fourLeggedCat.Name} has four legs.";
            break;
        case Cat { IsDomestic: false } wildCat: //Cat wildCat when wildCat.IsDomestic == false:
            message = $"The non-domestic cat is named {wildCat.Name}.";
            break;
        case Cat cat:
            message = $"The cat is name {cat.Name}.";
            break;
        default: // default is always evaluated last.
            message = $"{animal.Name} is a {animal.GetType().Name}.";
            break;
        case Spider { IsPoisonous: true } spider: //Spider spider when spider.IsPoisonous:
            message = $"The {spider.Name} spider is poisonous. Run!";
            break;
        case null:
            message = "The animal is null.";
            break;
    }
    WriteLine($"switch statement: {message}");

    message = animal switch
    {
        Cat { Legs: 4 } fourLeggedCat =>  $"The cat named {fourLeggedCat.Name} has four legs.",
        Cat { IsDomestic: false } wildCat => $"The non-domestic cat is name {wildCat.Name}.",
        Cat cat => $"The cat is named {cat.Name}.",
        Spider { IsPoisonous: true } spider => $"The {spider.Name} spider is poisonous. Run!",
        null => "The animal is null",
        _ => $"{animal.Name} is a {animal.GetType().Name}."
    };
    WriteLine($"switch expression: {message}");
}
#endregion