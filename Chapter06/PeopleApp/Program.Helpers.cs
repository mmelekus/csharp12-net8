using Packt.Shared;

partial class Program
{
    private static void OutputPeopleNames(IEnumerable<Person?> people, string title)
    {
        WriteLine(title);
        foreach (Person? p in people)
        {
            WriteLine("  {0}", p is null ? "<null> Person" : p.Name ?? "<null> Name");
            // If p is null the output: <null> Person
            // else output: p.Name
            // unless p.Name is null, then output: <null> Name
        }
    }
}