using SerializeDeserialize.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SerializeDeserialize
{
    internal class Program
    {
        static void Main()
        {
            
            Person person = new Person
            {
                Name = "Alice",
                Age = 25
            };

            // JSON Serialization
            string json = JsonSerializer.Serialize(person);
            Console.WriteLine("Serialized JSON:\n"+json);
           

            // JSON Deserialization
            Person deserializedJsonPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine("\nDeserialized JSON Object:");
            Console.WriteLine($"Name: {deserializedJsonPerson.Name}");
            Console.WriteLine($"Age: {deserializedJsonPerson.Age}");

            // Binary Serialization
            byte[] binaryData;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, person);
                binaryData = memoryStream.ToArray();
            }
            Console.WriteLine("\nSerialized Binary Data:");

            foreach (byte b in binaryData)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine();

            // Binary Deserialization
            Person deserializedBinaryPerson;
            using (MemoryStream memoryStream = new MemoryStream(binaryData))
            {
                IFormatter formatter = new BinaryFormatter();
                deserializedBinaryPerson = (Person)formatter.Deserialize(memoryStream);
            }
            Console.WriteLine("\nDeserialized Binary Object:");
            Console.WriteLine($"Name: {deserializedBinaryPerson.Name}");
            Console.WriteLine($"Age: {deserializedBinaryPerson.Age}");

            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            StringBuilder xmlStringBuilder = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(xmlStringBuilder))
            {
                xmlSerializer.Serialize(xmlWriter, person);
            }
            string xml = xmlStringBuilder.ToString();
            Console.WriteLine("\nSerialized XML:");
            Console.WriteLine(xml);

            // XML Deserialization
            Person deserializedXmlPerson;
            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    deserializedXmlPerson = (Person)xmlSerializer.Deserialize(xmlReader);
                }
            }
            Console.WriteLine("\nDeserialized XML Object:");
            Console.WriteLine($"Name: {deserializedXmlPerson.Name}");
            Console.WriteLine($"Age: {deserializedXmlPerson.Age}");
        }
    }
}