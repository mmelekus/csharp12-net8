partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred Execution");
        // Question: Which names end with an M?
        // (using a LINQ extension method)
        var query1 = names.Where(name => name.EndsWith("m"));
        // Question: Which names end with an M?
        // (using LINQ query comprehension syntax)
        var query2 = from name in names
                     where name.EndsWith("m")
                     select name;

        // Answer returned as an array of strings containing all names that end in "m".
        string[] result1 = query1.ToArray();
        // Answer returned as a list of strings containing all names that end in "m".
        List<string> result2 = query2.ToList();
        // Answer returned as we enumerate over the results.
        foreach (string name in query1)
        {
            WriteLine(name); // First iteration output "Pam".
            names[2] = "Jimmy"; // Change "Jim" to "Jimmy".
            // On the second itteration "Jimmy does not end with an "m" so it doesn't get output.
        }
    }

    private static void FilteringUsingWhere(string[] names)
    {
        SectionTitle("Filtering Entities Using Where");

        // Function delegate call
        // var query = names.Where(NameLongerThanFour);

        // Using a lambda expression instead of a named method.
        var query = names
            // Default parameter in lambda expression -- C# 12
            .Where((string name = "Bob") => name.Length > 4)
            .OrderBy(name => name.Length)
            .ThenBy(name => name);
        foreach (string item in query)
        {
            WriteLine(item);
        }
    }

    static bool NameLongerThanFour(string name)
    {
        // Returns true for a name longer than four characters.
        return name.Length > 4;
    }

    static void FilteringByType()
    {
        SectionTitle("Filtering by Type");
        List<Exception> excpetions =
        [
            new ArgumentException(),
            new SystemException(),
            new IndexOutOfRangeException(),
            new InvalidOperationException(),
            new NullReferenceException(),
            new InvalidCastException(),
            new OverflowException(),
            new DivideByZeroException(),
            new ApplicationException()
        ];
        IEnumerable<ArithmeticException> arithmeticExceptionsQuery = excpetions.OfType<ArithmeticException>();
        foreach (ArithmeticException exception in arithmeticExceptionsQuery)
        {
            WriteLine(exception);
        }
    }
}