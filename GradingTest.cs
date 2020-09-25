using System;
using System.Linq;

namespace lab3
{
    class Course
    {
        public static Student[] Students;
        public static void AddStudents(Student[] students){
            Students = students;
        }

        public static void GenerateAssignments()
        {
            foreach(Student student in Students)
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
                studentsList = string.Concat(studentsList , "\n" , $"Student ID: {student.GetId(),2} | " , $"Name: {student.Name}");
            });
            return studentsList;
        }

        public static double? GetStudentAverage(int studentId)
        {
            double? studentAverage = null;
            Array.ForEach(Course.Students, (student) => {
                if (student.GetId() == studentId)
                {
                    studentAverage = student.CalculateAverage();
                    return;
                }
            });
            return studentAverage;
        }
    }


    class GradingTest
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Bob", 1);
            Student student2 = new Student("Sarah", 2);
            Student student3 = new Student("Tim", 3);

            Student[] students = { student1, student2, student3 };

            Course.AddStudents(students);

            Course.GenerateAssignments();

            while (true) {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1: Enter Grades");
                Console.WriteLine("2: View Grade Averages");
                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("Choose a student: ");
                    Console.WriteLine(Course.GetStudentsList());

                    Console.Write("\nEnter your student id: ");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nChoose an assignment number: ");
                    Array.ForEach(Course.Students, (student) => {
                        if (student.GetId() == studentId)
                        {
                            Array.ForEach(student.Assignments, (assignment) => {
                                Console.WriteLine($"{assignment.Name} | Grade: {assignment.Grade}");
                            });

                            Console.Write($"\nAssignment number: ");

                            int assignmentNumber = int.Parse(Console.ReadLine());
                            Array.ForEach(student.Assignments, (assignment) => {
                                if (assignment.Number == assignmentNumber)
                                {
                                    Console.Write($"Enter grade: ");
                                    int grade = int.Parse(Console.ReadLine());
                                    assignment.Grade = grade;
                                }
                            });
                        }
                    });
                }
                else if (option == 2)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1: Student Averages");
                    Console.WriteLine("2: Assignment Averages");
                    int subOption = int.Parse(Console.ReadLine());

                    if (subOption == 1)
                    {
                        Console.WriteLine("Choose a student: ");
                        Console.WriteLine(Course.GetStudentsList());

                        Console.Write("\nEnter your student id: ");
                        int studentId = int.Parse(Console.ReadLine());

                        
                        Console.WriteLine($"Student average: {Course.GetStudentAverage(studentId)}");
                    }
                    else if (subOption == 2)
                    {
                        Console.WriteLine("\nChoose an assignment: ");
                        Array.ForEach(Course.Students[0].Assignments, (assignment) => {
                            Console.WriteLine($"{assignment.Name} | Grade: {assignment.Grade}");
                        });

                        int[] assignmentGrades = new int[3];
                        int assignmentNumber = int.Parse(Console.ReadLine());
                        for (int counter = 0; counter < Course.Students.Length; ++counter)
                        {
                            assignmentGrades[counter] = Course.Students[counter].Assignments[assignmentNumber].Grade;
                        }
                        int total = assignmentGrades.Aggregate((total,grade) => total += grade );
                        double average = total / assignmentGrades.Length;

                        Console.WriteLine($"Average Grade of Assignment {assignmentNumber}: {average:F}");
                    }
                }
            }
        }
    }
}
