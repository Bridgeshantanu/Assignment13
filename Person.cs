using CsvHelper.Configuration;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment13
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class AllFile
    {
        public void AddData()
        {
            var people = new List<Person>
            {
               new Person { ID = 1, Name = "Gaurav", Age = 15 },
               new Person { ID = 2, Name = "Rahul", Age = 25 },
               new Person { ID = 3, Name = "Lawrence", Age = 35 },
            };         
            
            //Text
            using (StreamWriter writer = new StreamWriter(@"G:\\Remap\\Repositories\\Assignment13\\Person.txt"))
            {
                foreach (var person in people)
                {
                    writer.WriteLine($"{person.ID},{person.Name},{person.Age}");
                }
            }

            Console.WriteLine("Data has been written to Person.txt.");
        
            
            
            //Json
            string json = JsonConvert.SerializeObject(people);            
            File.WriteAllText(@"G:\\Remap\\Repositories\\Assignment13\\Person.json", json);

            Console.WriteLine("Data has been written to Person.json.");


            //Csv
            using (StreamWriter writer = new StreamWriter(@"G:\\Remap\\Repositories\\Assignment13\\Person.csv"))
            {                
                writer.WriteLine("ID,Name,Age");
                
                foreach (var person in people)
                {
                    writer.WriteLine($"{person.ID},{person.Name},{person.Age}");
                }
            }

            Console.WriteLine("Data has been written to Person.csv.");
        }

        public List<Person> ReadDataFromTextFile()
        {            
            List<Person> people = new List<Person>();

            using (StreamReader reader = new StreamReader(@"G:\\Remap\\Repositories\\Assignment13\\Person.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        int age = int.Parse(parts[2]);

                        people.Add(new Person { ID = id, Name = name, Age = age });
                    }
                }
            }

            return people;           
        }
        
        public List<Person> ReadDataFromJsonFile()
        {
            string json = File.ReadAllText(@"G:\\Remap\\Repositories\\Assignment13\\Person.json");
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);
            return people;
        }
        
        public List<Person> ReadDataFromCsvFile()
        {
            using (var reader = new StreamReader(@"G:\\Remap\\Repositories\\Assignment13\\Person.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                List<Person> people = csv.GetRecords<Person>().ToList();
                return people;
            }
        }
    }
}
