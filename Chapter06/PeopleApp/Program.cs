﻿using Packt.Shared;

Person harry = new()
{
    Name = "Harry",
    Born = new(year: 2001, month: 3, day: 25, hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero)
};
harry.WriteToConsole();

// Implementing functionality using methods
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };
// Call the instance method to marry Lamech and Adah.
lamech.Marry(adah);
// Call the static method to marry Lamech and Zillah.
// Person.Marry(lamech, zillah);
if (lamech + zillah) { WriteLine($"{lamech.Name} and {zillah.Name} successfully got married."); }
lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();
// Call the instance method to make a baby.
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");
// Call the static method to make a baby.
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";
// Use the * operator to "multiply"
Person baby3 = lamech * adah;
baby3.Name = "Jubal";
Person baby4 = zillah * lamech;
baby4.Name = "Naamah";
adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();
for (int i = 0; i < lamech.Children.Count; i++) { WriteLine(format: "  {0}'s child #{1} is named \"{2}\".", arg0: lamech.Name, arg1: i + 1, arg2: lamech.Children[i].Name); }

// Define a generic lookup collection.
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");
var key = 3;
WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupIntString[key]);

// Event handlers
// Assign the method to the Shout delegate.
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;
// Call the Poke method that eventually raises the shout event.
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

// Interfaces
Person?[] people = {
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" }
};
OutputPeopleNames(people, "Initial list of people:");
Array.Sort(people); // Using IComparable
OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");
Array.Sort(people, new PersonComparer());
OutputPeopleNames(people, "After sorting using PersonComparer's IComparer implementation:");