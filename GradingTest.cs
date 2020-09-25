using System;

namespace lab3
{
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

                    var student = Course.GetStudent(studentId);

                    Console.WriteLine(student.GetAssignmentsList());

                    Console.Write($"\nAssignment number: ");

                    int assignmentNumber = int.Parse(Console.ReadLine());
                    
                    Console.Write($"Enter grade: ");
                    int grade = int.Parse(Console.ReadLine());
                    student.SetAssignmentGrade(assignmentNumber, grade);
                     
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
                        Console.WriteLine(Course.GetAllAssignmentsList());

                        int assignmentNumber = int.Parse(Console.ReadLine());
                        double average = Course.CalculateAssignmentsAverage(assignmentNumber);
                        Console.WriteLine($"Average Grade of Assignment {assignmentNumber}: {average:F}");
                    }
                }
            }
        }
    }
}
