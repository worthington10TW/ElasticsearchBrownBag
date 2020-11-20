using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace DataLoader
{
    public class PeopleGenerator
    {
        private readonly string[] _programmingLangugages;
        private readonly DateTime[] _studentStartDates =
            new []
            {
                new DateTime(2020, 1, 1),
                new DateTime(2020, 4, 1),
                new DateTime(2020, 7, 1),
                new DateTime(2020, 10, 1) 
            };

        public PeopleGenerator(string[] programmingLanguages)
        {
            Randomizer.Seed = new Random(8675309);
            _programmingLangugages = programmingLanguages;
        }

        public List<Trainer> GenerateTrainers(int amount) =>
            new Faker<Trainer>()
                .StrictMode(true)
                .RuleFor(t => t.Id, f => f.Commerce.Ean8())
                .RuleFor(t => t.Name, f => f.Person.FullName)
                .RuleFor(t => t.Bio, f => BioWithRandomLanguages(f, _programmingLangugages))
                .RuleFor(t => t.Subjects, f => RandomLanguages(f, _programmingLangugages, 1, 10))
                .RuleFor(t => t.Interests, f => Interests(f, _programmingLangugages))
                .RuleFor(t => t.JoinDate, f => JoinDate(f))
                .GenerateForever().Take(amount).ToList();

        public List<Student> GenerateStudents(int amount) =>
            new Faker<Student>()
                .StrictMode(true)
                .RuleFor(t => t.Id, f => f.Commerce.Ean8())
                .RuleFor(t => t.Name, f => f.Person.FullName)
                .RuleFor(t => t.Bio, f => BioWithRandomLanguages(f, _programmingLangugages))
                .RuleFor(t => t.CanDoIt, f => RandomLanguages(f, _programmingLangugages, 1, 4))
                .RuleFor(t => t.WantToLearn, f => RandomLanguages(f, _programmingLangugages, 1, 4))
                .RuleFor(t => t.PracticedSome, f => RandomLanguages(f, _programmingLangugages, 1, 4))
                .RuleFor(t => t.Interests, f => Interests(f, _programmingLangugages))
                .RuleFor(t => t.JoinDate, f => f.PickRandom(_studentStartDates))
                .GenerateForever().Take(amount).ToList();

        private static string[] Interests(Faker f, string[] lanugages)
            => f
            .Make(f.Random.Number(1, 15), m => f.Hacker.IngVerb())
            .Concat(RandomLanguages(f, lanugages, 0, 2))
            .OrderBy(x => f.Random.Number())
            .ToArray();

        private static DateTime JoinDate(Faker f)
            => f.Date.Between(
                        new DateTime(2019, 1, 1),
                        new DateTime(2020, 11, 1)).Date;

        private static string[] RandomLanguages(Faker f, string[] lanugages, int start, int end)
            => f
            .PickRandom(lanugages, f.Random.Number(start, end))
            .ToArray();

        private static string BioWithRandomLanguages(Faker f, string[] lanugages)
        {
            var text = f.Lorem.Paragraphs();

            foreach (var l in RandomLanguages(f, lanugages, 0, 5))
                text = text.Insert(f.Random.Number(0, text.Length - 1), $" {l} ");

            return text;
        }
    }
}
