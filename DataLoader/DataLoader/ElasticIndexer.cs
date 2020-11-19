using System;
using System.Collections.Generic;
using System.Linq;
using Nest;

namespace DataLoader
{
    public class ElasticIndexer
    {
        private readonly ElasticClient _client;

        public ElasticIndexer(Uri endpoint)
            => _client = new ElasticClient(endpoint);

        public void Index(List<Trainer> trainers)
        {
            var bulkIndexResponse = _client
                .Bulk(b => b
                    .Index("trainer")
                    .IndexMany(trainers));

            Console.WriteLine($"Indexing complete! " +
                $"{bulkIndexResponse.Items.Count} successful" +
                $"indexed, {bulkIndexResponse.ItemsWithErrors.Count()} failed");
        }

        public bool IsAlive()
            => _client.Ping().ApiCall.Success;
    }
}
