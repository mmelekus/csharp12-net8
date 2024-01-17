using System.Numerics; // To use BigInteger
using System.Globalization;
using System.Text.Encodings.Web; // to use CultureInfo.

// Very large numbers (BigInteger)
const int width = 40;
WriteLine("ulong.MaxValue vs a 30-digit BitInteger");
WriteLine(new string('-', width));
ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");
BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");

// Complex numbers
Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;
// Output using the default ToString implementation.
WriteLine($"{c1} added to {c2} is {c3}");
// Output using a custom format.
WriteLine("{0} + {1}i added to {2} + {3}i is {4} + {5}i",
    c1.Real, c1.Imaginary,
    c2.Real, c2.Imaginary,
    c3.Real, c3.Imaginary);

// Random numbers
Random r = Random.Shared;
// minValue is an inclusive lower bound i.e. 1 is a possible value.
// maxValue is an exclusive upper bound i.e. 7 is not a possible value.
int dieRoll = r.Next(minValue: 1, maxValue: 7); // Returns 1 to 6.
WriteLine($"Random die roll: {dieRoll}");
double randomReal = r.NextDouble(); // Returns 0.0 to less than 1.0.
WriteLine($"Random double: {randomReal}");
byte[] arrayOfBytes = new byte[256];
r.NextBytes(arrayOfBytes); // Fills array with 256 random bytes.
Write("Random bytes: ");
for (int i = 0; i < arrayOfBytes.Length; i++) { Write($"{arrayOfBytes[i]:X2} "); }
WriteLine();

// Random and shuffled arrays
string[] beatles = r.GetItems(choices: new[] { "John", "Paul", "George", "Ringo" }, length: 10);
Write("Random ten beatles:");
foreach (string beatle in beatles) { Write($" {beatle}"); }
WriteLine();
r.Shuffle(beatles);
Write("Shuffled beatles:");
foreach (string beatle in beatles) { Write($" {beatle}"); }
WriteLine();

// Generating GUIDs
WriteLine($"Empty GUID: {Guid.Empty}.");
Guid g = Guid.NewGuid();
WriteLine($"Random GUID: {g}.");
byte[] guidAsBytes = g.ToByteArray();
Write("GUID as byte array: ");
for (int i = 0; i < guidAsBytes.Length; i++) { Write($"{guidAsBytes[i]:X2} "); }
WriteLine();

// Working with text.
string city = "London";
WriteLine($"{city} is {city.Length} characters long.");
WriteLine($"First char is {city[0]} and fourth is {city[3]}.");

// Splitting a string.
string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellin";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array:");
foreach (var item in citiesArray) { WriteLine($"  {item}"); }
WriteLine();

OutputEncoding = System.Text.Encoding.UTF8;  // Enable Euro symbol.
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
string text1 = "Mark";
string text2 = "MARK";
WriteLine($"text1: {text1}, text2: {text2}");
WriteLine("Compare: {0}.", string.Compare(text1, text2));
WriteLine("Compare (ignoreCase): {0}.", string.Compare(text1, text2, ignoreCase: true));
WriteLine("Compare (InvariantCultureIgnoreCase): {0}.", string.Compare(text1, text2, StringComparison.InvariantCultureIgnoreCase));