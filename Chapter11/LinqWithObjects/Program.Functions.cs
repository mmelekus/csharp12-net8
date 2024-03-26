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
}