using System;
using System.Collections.Generic;
using System.Linq;
using Nest;

namespace DataLoader
{
    public class ElasticIndexer
    {
        private readonly ElasticClient _client;
        private const int BATCH_SIZE = 3000;

        public ElasticIndexer(Uri endpoint)
            => _client = new ElasticClient(endpoint);

        public void Index(IEnumerable<Trainer> trainers)
        {
            trainers.BatchForEach(t =>
            {
                LogResponse(_client
                    .Bulk(b => b
                        .Index("trainer")
                        .IndexMany(t)));

            }, BATCH_SIZE);
        }

        public void Index(IEnumerable<Student> students)
        {
            students.BatchForEach(s =>
            {
                LogResponse(_client
                .Bulk(b => b
                    .Index("student")
                    .IndexMany(s)));
            }, BATCH_SIZE);
        }

        public void IndexStudentWithNewField(IEnumerable<string> students)
        {
            students.BatchForEach(s =>
            {
                var partials = s.Select(x => new
                {
                    id = x,
                    newField = Guid.NewGuid().ToString()
                });

                LogResponse(
                    _client
                .Bulk(b => b
                    .Index("student")                    
                    .UpdateMany(partials, (bu, d) => {
                        bu.RetriesOnConflict(4);
                        return bu.Doc(d); })));

                
            }, BATCH_SIZE);
        }

        public bool IsAlive()
            => _client.Ping().ApiCall.Success;

        private static void LogResponse(BulkResponse bulkIndexResponse)
        {
            Console.WriteLine($"{DateTime.Now:u}: Indexing complete! " +
                           $"{bulkIndexResponse.Items.Count} successful" +
                           $"indexed, {bulkIndexResponse.ItemsWithErrors.Count()} failed");

            if (bulkIndexResponse.Errors)
            {
                foreach (var error in bulkIndexResponse.ItemsWithErrors)
                {
                    if (!string.IsNullOrEmpty(error.Error?.Reason))
                        Console.Error.WriteLine($"{error.Error?.Reason}");
                }

            }
        }
    }
}
