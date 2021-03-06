using System;

namespace lab3
{
    class Student
    {
        public string Name { get; set; }
        private int Id;
        public Assignment[] Assignments { get; set; }
        

        public void SetId()
        {
            System.Random random = new System.Random();
            this.Id = random.Next(50);
        }

        public int GetId()
        {
            return this.Id;
        }

        public Student(string studentName, int studentId)
        {
            this.Name = studentName;
            this.SetId();
        }

        public void AddAssignments(Assignment[] assignments)
        {
            this.Assignments = assignments;
        }

        public double CalculateAverage()
        {
            double sum = 0;
            int allWeights = 0;
            for (int counter = 0; counter < this.Assignments.Length; counter++)
            {
                sum += (this.Assignments[counter].Grade * this.Assignments[counter].Weight);
                allWeights += this.Assignments[counter].Weight;
            }
            return sum / allWeights;
        }

        public string GetAssignmentsList()
        {
            string assignmentsList = "";
            Array.ForEach(this.Assignments, (assignment) => {
                assignmentsList = string.Concat(assignmentsList , $"{assignment.Name} | Grade: {assignment.Grade}" , "\n");
            });
            return assignmentsList;
        }

        public void SetAssignmentGrade(int assignmentNumber , int grade)
        {
            Array.ForEach(this.Assignments, (assignment) => {
                if (assignment.Number == assignmentNumber)
                {
                    assignment.Grade = grade;
                }
            });
        }
    }
}
