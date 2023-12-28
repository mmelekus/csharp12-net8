using Packt.Shared; // To use Person.

ConfigureConsole(); // Sets current culture to US English.
// Alternatives:
// ConfigureConsole(useComputerCulture: true); // Use your culture.
// ConfigureConsole(culture: "fr-FR"); // Use French culture.

Person bob = new();
bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 28, second: 0,
    offset: TimeSpan.FromHours(-5));  // US Eastern Standard Time.
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList =
    WondersOfTheAncientWorld.HangingGardensOfBabylon |
    WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
// bob.BucketList = (WondersOfTheAncientWorld)18;

Person alfred = new Person(); // Works with all versions of C#.
alfred.Name = "Alfred";
bob.Children.Add(alfred);
bob.Children.Add(new Person { Name = "Bella" }); // Works with C# 3 or later.
bob.Children.Add(new() { Name = "Zoe" }); // Works with C# 9 or later.

WriteLine(
    format: "{0} was born on {1:D}.", // Long date.
    arg0: bob.Name,
    arg1: bob.Born);
WriteLine(
    format: "{0}'s favorite wonder is {1}. It's integer is {2}.",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder);
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");
WriteLine($"{bob.Name} has {bob.Children.Count} children:");
for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++) { WriteLine($"> {bob.Children[childIndex].Name}"); }

// Object initializer syntax
Person alice = new()
{
    Name = "Alice Jone",
    Born = new(1968, 3, 7, 16, 28, 0,
        // This is an optional offset from UTC time zone.
        TimeSpan.Zero)
};
WriteLine(
    format: "{0} was born on {1:d}.", // Short date.
    arg0: alice.Name,
    arg1: alice.Born);