using Packt.Shared; // To use Viper.
using System.Xml; // To use XmlWriter and so on.

// Text Streams
SectionTitle("Writing to text streams");
//Define a file to write to.
string textFile = Path.Combine(Environment.CurrentDirectory, "streams.txt");
// Create a text file and return a helper writer.
StreamWriter text = File.CreateText(textFile);
// Enumerate the strings, writing each one to the stream on a separate line.
foreach (string item in Viper.Callsigns) { text.WriteLine(item); }
text.Close(); // Release unmanaged file resources.
OutputFileInfo(textFile);

// XML Streams
SectionTitle("Writing to XML streams");
// Define a file path to write to.
string xmlFile = Path.Combine(Environment.CurrentDirectory, "streams.xml");
// Declare variables for the filestream and XML writer.
FileStream? xmlFileStream = null;
XmlWriter? xml = null;
try
{
    xmlFileStream = File.Create(xmlFile);
    // Wrap the file stream in an XML writer helper and tell it to automatically indent nested elements.
    xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
    // Write the XML declaration.
    xml.WriteStartDocument();
    // Write a root element.
    xml.WriteStartElement("callsigns");
    // Enumerate the strings, writing each one to the stream.
    foreach (string item in Viper.Callsigns) { xml.WriteElementString("callsign", item); }
    // Write the close root element.
    xml.WriteEndElement();
}
catch (Exception ex)
{
    // If the path doesn't exist the exception will be caught.
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
finally
{
    if (xml is not null)
    {
        xml.Close();
        Console.WriteLine("The XML writer's unmanaged resources have been disposed.");
    }
    if (xmlFileStream is not null)
    {
        xmlFileStream.Close();
        Console.WriteLine("The file stream's unmanaged resources have been disposed.");
    }
}
OutputFileInfo(xmlFile);

// Simplifying disposal by using the using statement -- don't need parenthesis or block braces anymore
using FileStream file2 = File.OpenWrite(Path.Combine(Environment.CurrentDirectory, "file2.txt"));
using StreamWriter writer2 = new(file2);
try { writer2.WriteLine("Welcome, .NET!"); }
catch (Exception ex) { Console.WriteLine($"{ex.GetType()} says {ex.Message}"); }

// Old school way:
// using (FileStream file2 = File.OpenWrite(Path.Combine(Environment.CurrentDirectory, "file2.txt")))
// {
//   using (StreamWriter writer2 = new StreamWriter(file2))
//   {
//     try
//     {
//       writer2.WriteLine("Welcome, .NET!");
//     }
//     catch(Exception ex)
//     {
//       Console.WriteLine($"{ex.GetType()} says {ex.Message}");
//     }
//   } // Automatically calls Dispose if the object is not null.
// } // Automatically calls Dispose if the object is not null.

// Compressing Streams
SectionTitle("Compressing streams");
Compress(algorithm: "gzip");
Compress(algorithm: "brotli");