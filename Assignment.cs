using System;

namespace lab3
{
    class Assignment
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Grade { get; set; }

        public Assignment(int number, string name, int weight = 1, int grade = -1)
        {
            Number = number;
            Name = name;
            Weight = weight;
            Grade = grade;
        }   
    }
}
