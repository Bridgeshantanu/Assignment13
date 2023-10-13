namespace Assignment13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AllFile file = new AllFile();
            file.AddData();
            
            
            List<Person> peopleFromTextFile = file.ReadDataFromTextFile();
            //List<Person> peopleFromJsonFile = file.ReadDataFromJsonFile();
            //List<Person> peopleFromCsvFile = file.ReadDataFromCsvFile();

            foreach (Person person in peopleFromTextFile)
            {
                Console.WriteLine($"ID: {person.ID}, Name: {person.Name}, Age: {person.Age}");
            }

            
        }
    }
}