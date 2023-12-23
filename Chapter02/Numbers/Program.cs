﻿// See https://aka.ms/new-console-template for more information
// An unsigned integer is a positive whole number or 0.
uint naturalNumber = 23;
Console.WriteLine($"A natural number (uint): {naturalNumber}");

// An integer is a negative or positive whole number or 0.
int integerNumber = -23;
Console.WriteLine($"An integer number (int): {integerNumber}");

// A float is a single-precision floating-point number.
// The F or f suffix makes the value a float literal.
// The suffix is required to compile.
float realNumber = 2.3f;
Console.WriteLine($"A float number (float): {realNumber}");

// A double is a double-precision floating-point number.
// double i the default for a number value with a decimal point.
double anotherRealNumber = 2.3; // A double literal value.
Console.WriteLine($"A double number (double): {anotherRealNumber}");

int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;

// Check the three variables have the same value.
Console.WriteLine($"{decimalNotation == binaryNotation}");
Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

// Output the variable values in decimal
Console.WriteLine($"{decimalNotation:N0}");
Console.WriteLine($"{binaryNotation:N0}");
Console.WriteLine($"{hexadecimalNotation:N0}");

// Output the variables in hexadecimal
Console.WriteLine($"{decimalNotation:X}");
Console.WriteLine($"{binaryNotation:X}");
Console.WriteLine($"{hexadecimalNotation:X}");

Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");
Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");
Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");

// Double equality comparison -- just don't do it!
// You can compare greater than (>) and less than (<)
Console.WriteLine("Using doubles:");
double a = 0.1;
double b = 0.2;
if (a + b == 0.3) { Console.WriteLine($"{a} + {b} equals {0.3}"); }
else { Console.WriteLine($"{a} + {b} does NOT equal {0.3}"); }

// Decimal equality comparison
Console.WriteLine("Using decimals:");
decimal c = 0.1M; // M suffix means a decimal literal value -- think M for Money
decimal d = 0.2M;
if (c + d == 0.3M) { Console.WriteLine($"{c} + {d} equals {0.3M}"); }
else { Console.WriteLine($"{c} + {d} does NOT equal {0.3M}"); }

unsafe
{
    Console.WriteLine($"Half uses {sizeof(Half)} bytes and can store numbers in the range {Half.MinValue:N0} to {Half.MaxValue:N0}.");
    Console.WriteLine($"Int128 uses {sizeof(Int128)} bytes and can store numvers in the range {Int128.MinValue:N0} to {Int128.MaxValue:N0}.");
}