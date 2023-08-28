using SerializeDeserializeFromFiles.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializeDeserializeFromFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main()
            {
                // Create a Person object
                Person person = new Person
                {
                    Name = "Alice",
                    Age = 25
                };

                // JSON Serialization and File Creation
                string json = JsonSerializer.Serialize(person);
                File.WriteAllText("person.json", json);
                Console.WriteLine("JSON data saved to person.json");

                // JSON Deserialization from File
                string jsonFromFile = File.ReadAllText("person.json");
                Person deserializedJsonPerson = JsonSerializer.Deserialize<Person>(jsonFromFile);
                Console.WriteLine("\nDeserialized JSON Object from File:");
                Console.WriteLine($"Name: {deserializedJsonPerson.Name}");
                Console.WriteLine($"Age: {deserializedJsonPerson.Age}");

                // Binary Serialization and File Creation
                byte[] binaryData;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(memoryStream, person);
                    binaryData = memoryStream.ToArray();
                }
                File.WriteAllBytes("person.bin", binaryData);
                Console.WriteLine("\nBinary data saved to person.bin");

                // Binary Deserialization from File
                byte[] binaryDataFromFile = File.ReadAllBytes("person.bin");
                using (MemoryStream memoryStream = new MemoryStream(binaryDataFromFile))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Person deserializedBinaryPerson = (Person)formatter.Deserialize(memoryStream);
                    Console.WriteLine("\nDeserialized Binary Object from File:");
                    Console.WriteLine($"Name: {deserializedBinaryPerson.Name}");
                    Console.WriteLine($"Age: {deserializedBinaryPerson.Age}");
                }

                // XML Serialization and File Creation
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                using (FileStream xmlFile = File.Create("person.xml"))
                {
                    xmlSerializer.Serialize(xmlFile, person);
                }
                Console.WriteLine("\nXML data saved to person.xml");

                // XML Deserialization from File
                using (FileStream xmlFile = File.OpenRead("person.xml"))
                {
                    Person deserializedXmlPerson = (Person)xmlSerializer.Deserialize(xmlFile);
                    Console.WriteLine("\nDeserialized XML Object from File:");
                    Console.WriteLine($"Name: {deserializedXmlPerson.Name}");
                    Console.WriteLine($"Age: {deserializedXmlPerson.Age}");
                }
                Console.WriteLine("Current Directory: " + Environment.CurrentDirectory);

            }
        }
    }
}