using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace DataLoader
{
    public class DataGenerator
    {
        private readonly string[] _programmingLangugages;

        public DataGenerator(string[] programmingLanguages)
            => _programmingLangugages = programmingLanguages;

        public List<Trainer> GenerateTrainers(int amount)
        {
            Randomizer.Seed = new Random(8675309);

            var fakeTrainer = new Faker<Trainer>()
                .StrictMode(true)
                .RuleFor(t => t.Id, f => f.Random.String(5))
                .RuleFor(t => t.Name, f => f.Person.FullName)
                .RuleFor(t => t.Bio, f => BioWithRandomLanguages(f, _programmingLangugages))
                .RuleFor(t => t.Subjects, f => RandomLanguages(f, _programmingLangugages, 1, 10))
                .RuleFor(t => t.Interests, f => Interests(f, _programmingLangugages))
                .RuleFor(t => t.JoinDate, f => JoinDate(f));
            return fakeTrainer.GenerateForever().Take(amount).ToList();
        }

        private static string[] Interests(Faker f, string[] lanugages)
            => f
            .Make(f.Random.Number(1, 15), m => f.Hacker.IngVerb())
            .Concat(RandomLanguages(f, lanugages, 0, 2))
            .OrderBy(x => f.Random.Number())
            .ToArray();

        private static DateTime JoinDate(Faker f)
            => f.Date.Between(
                        new DateTime(2015, 1, 1),
                        new DateTime(2020, 11, 1));

        private static string[] RandomLanguages(Faker f, string[] lanugages, int start, int end)
            => f
            .PickRandom(lanugages, f.Random.Number(start, end))
            .ToArray();

        private static string BioWithRandomLanguages(Faker f, string[] lanugages)
        {
            var text = f.Lorem.Paragraphs();

            foreach (var l in RandomLanguages(f, lanugages, 0, 5))
                text = text.Insert(f.Random.Number(0, text.Length - 1), l);

            return text;
        }
    }
}
