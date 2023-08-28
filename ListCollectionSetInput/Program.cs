namespace ListCollectionSetInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a List to store integers
            List<int> numbers = new List<int>();


            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(15);
            numbers.Add(20);


            Console.WriteLine("List elements:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            int firstNumber = numbers[0];
            int secondNumber = numbers[1];
            Console.WriteLine("\nFirst number: " + firstNumber);
            Console.WriteLine("Second number: " + secondNumber);


            int indexOf15 = numbers.IndexOf(15);
            Console.WriteLine("\nIndex of 15: " + indexOf15);


            numbers.Remove(10);
            Console.WriteLine("\nList after removing 10:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            
            numbers.RemoveAt(1); // Removes the element at index 1 
            Console.WriteLine("\nList after removing element at index 1:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // Insert an element at a specific index
            numbers.Insert(1, 25); // Inserts 25 at index 1
            Console.WriteLine("\nList after inserting 25 at index 1:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }


            bool contains20 = numbers.Contains(20);
            Console.WriteLine("\nList contains 20: " + contains20);


            numbers.Clear();
            Console.WriteLine("\nList after clearing:");
            Console.WriteLine("Count: " + numbers.Count);


            List<int> newNumbers = new List<int> { 30, 40, 50 };
            numbers.AddRange(newNumbers);
            Console.WriteLine("\nList after adding a range of elements:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }


            List<int> insertedNumbers = new List<int> { 60, 70 };
            numbers.InsertRange(1, insertedNumbers); // Inserts 60 and 70 at index 1
            Console.WriteLine("\nList after inserting a range of elements at index 2:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine(); 
        }
    }
    
}