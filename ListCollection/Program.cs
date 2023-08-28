using ListCollection.Model;

namespace ListCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                Console.WriteLine(" Choose an operation:");
                Console.Write("  1. Create (Add)\t");
                Console.WriteLine("2. Read (Find)");
                Console.Write("  3. Update (Modify)\t");
                Console.WriteLine("4. Delete (Remove)");
                Console.Write("  5. Insert at Index\t");
                Console.WriteLine("6. Display All");
                Console.Write("  7. Clear\t\t");
                Console.WriteLine("8. Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Create(people);
                            break;
                        case 2:
                            Read(people);
                            break;
                        case 3:
                            Update(people);
                            break;
                        case 4:
                            Delete(people);
                            break;
                        
                        case 5:
                            InsertObject(people);
                            break;
                        case 6:
                            DisplayAll(people);
                            break;
                        case 7:
                            Clear(people);
                            break;
                        case 8:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }

        static void Create(List<Person> people)
        {
            Console.WriteLine("Enter Id:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                return;
            }

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Age:");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid Age. Please enter a valid integer.");
                return;
            }

            Person person = new Person { Id = id, Name = name, Age = age };
            people.Add(person);
            Console.WriteLine("Person added successfully.");
        }

        static void Read(List<Person> people)
        {
            Console.WriteLine("Enter Name to Find:");
            string nameToFind = Console.ReadLine();

            bool found = false;
            foreach (Person person in people)
            {
                if (person.Name == nameToFind)
                {
                    Console.WriteLine($"Found: Id = {person.Id}, Name = {person.Name}, Age = {person.Age}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Person not found.");
            }
        }

        static void Update(List<Person> people)
        {
            Console.WriteLine("Enter Name to Update:");
            string nameToUpdate = Console.ReadLine();

            foreach (Person person in people)
            {
                if (person.Name == nameToUpdate)
                {
                    Console.WriteLine($"Enter new Age for {person.Name}:");
                    if (int.TryParse(Console.ReadLine(), out int newAge))
                    {
                        person.Age = newAge;
                        Console.WriteLine("Age updated successfully.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Age. Age not updated.");
                        return;
                    }
                }
            }

            Console.WriteLine("Person not found. Age not updated.");
        }

        static void Delete(List<Person> people)
        {
            Console.WriteLine("Enter Name to Delete:");
            string nameToDelete = Console.ReadLine();

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Name == nameToDelete)
                {
                    people.RemoveAt(i);
                    Console.WriteLine("Person deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Person not found. Deletion failed.");
        }

        

        static void InsertObject(List<Person> people)
        {
            Console.WriteLine("Enter the index to insert:");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index > people.Count)
            {
                Console.WriteLine("Invalid index. Please enter a valid integer within the range of the list size.");
                return;
            }

            Console.WriteLine("Enter Id:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                return;
            }

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Age:");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid Age. Please enter a valid integer.");
                return;
            }

            Person person = new Person { Id = id, Name = name, Age = age };
            people.Insert(index, person);
            Console.WriteLine("Person inserted successfully.");
        }

        static void DisplayAll(List<Person> people)
        {
            Console.WriteLine("All People:");
            foreach (Person person in people)
            {
                Console.WriteLine($"Id = {person.Id}, Name = {person.Name}, Age = {person.Age}");
            }
        }

        static void Clear(List<Person> people)
        {
            people.Clear();
            Console.WriteLine("All people cleared from the list.");
        }
    }
    
}