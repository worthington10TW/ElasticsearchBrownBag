using System;
using System.IO;
using System.Threading;

namespace DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Folks!");

            var url = args.Length < 1 ? "http://localhost:9200" : args[0];
            Console.WriteLine($"Lets pump some data into Elasticsearch: {url}");

            var indexer = new ElasticIndexer(new Uri(url));
            WaitForElasticsearchToBeUp(indexer);

            Console.WriteLine("Reading programming languages");
            var langugages = File.ReadAllLines("ProgrammingLanguages.txt");
            var generator = new PeopleGenerator(langugages);

            const int trainerCount = 500;
            Console.WriteLine($"Generated {trainerCount} trainers");
            var trainers = generator.GenerateTrainers(trainerCount);
            Console.WriteLine($"Pumping trainers into Elasticsearch");
            indexer.Index(trainers);
            Console.WriteLine($"Trainers indexed");

            const int studentCount = 10000;
            Console.WriteLine($"Generated {studentCount} students");
            var students = generator.GenerateStudents(studentCount);
            Console.WriteLine($"Pumping students into Elasticsearch");
            indexer.Index(students);
            Console.WriteLine($"Students indexed");

            Console.WriteLine($"Index complete, now start searching!");
        }

        private static void WaitForElasticsearchToBeUp(ElasticIndexer indexer)
        {
            Console.WriteLine("Connecting to Elasticsearch");
            while (!indexer.IsAlive())
            {
                Console.WriteLine("Could not connect to elastic, retrying in 10 seconds");
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }
        }
    }
}
