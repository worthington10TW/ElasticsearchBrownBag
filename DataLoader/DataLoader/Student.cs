using System;

namespace DataLoader
{
    public class Student
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public string[] WantToLearn { get; set; }

        public string[] PracticedSome { get; set; }

        public string[] CanDoIt { get; set; }

        public string[] Interests { get; set; }

        public DateTime JoinDate { get; set; }
    }
}

