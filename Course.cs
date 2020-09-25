using System;
using System.Linq;


namespace lab3
{
    class Course
    {
        public static Student[] Students;
        public static void AddStudents(Student[] students)
        {
            Students = students;
        }

        public static void GenerateAssignments()
        {
            foreach (Student student in Students)
            {
                Assignment assignment1 = new Assignment(1, "Assignment 1", 1);
                Assignment assignment2 = new Assignment(2, "Assignment 2", 1);
                Assignment assignment3 = new Assignment(3, "Assignment 3", 1);

                Assignment[] assignments = { assignment1, assignment2, assignment3 };

                student.AddAssignments(assignments);
            }
        }

        public static string GetStudentsList()
        {
            string studentsList = "";
            Array.ForEach(Course.Students, (student) => {
                studentsList = string.Concat(studentsList, "\n", $"Student ID: {student.GetId(),2} | ", $"Name: {student.Name}");
            });
            return studentsList;
        }

        public static double? GetStudentAverage(int studentId)
        {
            double? studentAverage = null;
            Array.ForEach(Course.Students, (student) =>
            {
                if (student.GetId() == studentId)
                {
                    studentAverage = student.CalculateAverage();
                    return;
                }
            });
            return studentAverage;
        }

        public static Student? GetStudent(int studentId)
        {
            Student? foundStudent = null;
            Array.ForEach(Course.Students, (student) => {
                if (student.GetId() == studentId)
                {
                    foundStudent = student;
                }
            });
            return foundStudent;
        }

        public static string GetAllAssignmentsList()
        {
            string assignmentsList = "";
            Array.ForEach(Students[0].Assignments, (assignment) => {
                assignmentsList = string.Concat(assignmentsList, $"{assignment.Name}", "\n");
            });
            return assignmentsList;
        }

        public static double CalculateAssignmentsAverage(int assignmentNumber)
        {
            int[] assignmentGrades = new int[Students[0].Assignments.Length];
            for (int counter = 0; counter < Students.Length; counter++)
            {
                assignmentGrades[counter] = Students[counter].Assignments[assignmentNumber - 1].Grade;
            }
            int total = assignmentGrades.Aggregate((total, grade) => total += grade);
            double average = total / assignmentGrades.Length;
            return average;
        }
    }
}
