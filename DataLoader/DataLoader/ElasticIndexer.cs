using System;
using System.Collections.Generic;
using System.Linq;
using Nest;

namespace DataLoader
{
    public class ElasticIndexer
    {
        private readonly ElasticClient _client;
        private const int BATCH_SIZE = 1000;

        public ElasticIndexer(Uri endpoint)
            => _client = new ElasticClient(endpoint);

        public void Index(List<Trainer> trainers)
        {
            trainers.BatchForEach(t =>
            {
                var bulkIndexResponse = _client
                    .Bulk(b => b
                        .Index("trainer")
                        .IndexMany(t));

                Console.WriteLine($"Indexing complete! " +
                    $"{bulkIndexResponse.Items.Count} successful" +
                    $"indexed, {bulkIndexResponse.ItemsWithErrors.Count()} failed");

            }, BATCH_SIZE);
        }

        public void Index(List<Student> students)
        {
            students.BatchForEach(s =>
            {
                var bulkIndexResponse = _client
                .Bulk(b => b
                    .Index("student")
                    .IndexMany(s));

                Console.WriteLine($"Indexing complete! " +
                    $"{bulkIndexResponse.Items.Count} successful" +
                    $"indexed, {bulkIndexResponse.ItemsWithErrors.Count()} failed");
            }, BATCH_SIZE);
        }

        public bool IsAlive()
            => _client.Ping().ApiCall.Success;
    }
}
