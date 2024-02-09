using Newtonsoft.Json; // To use JsonSerializer.
using FastJson = System.Text.Json.JsonSerializer;
using System.Xml.Serialization; // To use XmlSerializer.
using Packt.Shared; // To use Person.

List<Person> people = new()
{
    new(initialSalary: 30_000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(year: 1974, month: 3, day: 14)
    },
    new(initialSalary: 40_000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth =new(year: 1969, month: 11, day: 23)
    },
    new(initialSalary: 20_000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(year: 1984, month: 5, day: 4),
        Children = new()
        {
            new(initialSalary: 0M)
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(year: 2012, month: 7, day: 12)
            }
        }
    }
};

SectionTitle("Serializing as XML");
// Create a serializer to format a "List of Person" as XML.
XmlSerializer xs = new(type: people.GetType());
// Create a file to write to.
string path = Path.Combine(Environment.CurrentDirectory, "people.xml");
using (FileStream stream = File.Create(path))
{
    // Serialize the object graph to the stream
    xs.Serialize(stream, people);
} // Closes the stream
OutputFileInfo(path);

SectionTitle("Deserializing XML files");
using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    // Deserialize and cast the object graph into a "List of Person".
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            var childCount = p.Children?.Count ?? 0;
            WriteLine($"{p.LastName} has {childCount} {(childCount == 1 ? "child" : "children")}.");
        }
    }
}

SectionTitle("Serialization with JSON");
// Create a file to write to.
string jsonPath = Path.Combine(Environment.CurrentDirectory, "people.json");
using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    JsonSerializer jss = new();
    // Serialize the object graph into a string.
    jss.Serialize(jsonStream, people);
} // Closes the file stream and releases the resource.
OutputFileInfo(jsonPath);

SectionTitle("Deserializng JSON files");
await using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    // Deserialize object graph into a "List of Person".
    List<Person>? loadedPeople = await FastJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;
    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            var childCount = p.Children?.Count ?? 0;
            WriteLine($"{p.LastName} has {childCount} {(childCount == 1 ? "child" : "children")}.");
        }
    }
}