// See https://aka.ms/new-console-template for more information
using System.Xml; // To use XmlDocument.
using Variables;

object height = 1.88; // Storing a double in an object (boxing).
object name = "Amir"; // Storing a string in an object (boxing).

Console.WriteLine($"{name} is {height} metres tall.");
// int length1 = name.Length; // This give a compile error!
int length2 = ((string)name).Length; // Cast name to a string (unboxing);
Console.WriteLine($"{name} has {length2} characters.");

// dynamic variables
dynamic something;
// Storing an array of int values in a dynamic object.
// An array of any type has a Length property.
something = new[] { 3, 5, 7 };
// Storing an int in a dynamic object.
// int does not have a Length property.
something = 12;
// Storing a string in a dynamic object.
// string has a Length property.
something = "Ahmed";
// This compiles but might throw an exception at run-time.
Console.WriteLine($"The length of something is {something.Length}.");
// Output the type of the something variable
Console.WriteLine($"something is a {something.GetType()}");

// Specifying the type of a local variable
var population = 67_000_000; // 67 million in UK.
var weight = 1.88; // in killograms.
var price = 4.99M; // in pounds sterling.
var fruit = "Apples"; // string values use double-quotes.
var letter = 'Z'; // char values use single-quotes.
var happy = true; // Booleans can only be true or false.

Console.WriteLine($"{population:N0} population in UK.");
Console.WriteLine($"{weight} killograms.");
Console.WriteLine($"{price} pounds sterling.");
Console.WriteLine($"{fruit}");
Console.WriteLine($"{letter}");
Console.WriteLine($"Are you happy?  {happy}!");

// Good use of var because it avoids the repeated type
// as shown in the more verbose second statement.
var xml1 = new XmlDocument(); // Works with C# 3 and later.
XmlDocument xml2 = new XmlDocument(); // Works with all C# versions.
// Bad use of var because we cannot tell the type, so we
// should use a specific type declaration as shown in
// the second statement.
var file1 = File.CreateText("something1.txt");
StreamWriter file2 = File.CreateText("something2.txt");

// Target-typed new to instantiate objects
XmlDocument xml3 = new();  // Targe-typed new in C# 9 or later.

Person kim = new();
kim.BirthDate = new(1967, 12, 26); // i.e. new DateTime(1967, 12, 26)

List<Person> people = new() // Instead of: new List<Person>()
{
    new() { FirstName = "Alice" }, // Instead of: New Person() { ... }
    new() { FirstName = "Bob" },
    new() { FirstName = "Charlie" }
};

// Getting and setting default values for types.
Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}"); // Not simplified to show the specific type -- simplified for reference types is just "default".

int number = 13;
Console.WriteLine($"number set to: {number}");
number = default;
Console.WriteLine($"number reset to its default: {number}");