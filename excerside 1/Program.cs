using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerside_1
{
    using System;

    public class Student
    {
        private string name;
        private double score;

        private static int totalStudents = 0;

        // Constructor
        public Student(string name, double score)
        {
            this.name = name;
            this.score = score;
            totalStudents++;
        }

        // ===== Instance Methods =====

        public string GetName()
        {
            return this.name;
        }

        public double GetScore()
        {
            return this.score;
        }

        public bool IsPassed()
        {
            return this.score >= 5.0;
        }

        public string GetClassification()
        {
            if (this.score >= 8.0)
                return "Excellent";
            else if (this.score >= 6.5)
                return "Good";
            else if (this.score >= 5.0)
                return "Average";
            else
                return "Weak";
        }

        // ===== Static Methods =====

        public static int GetTotalStudents()
        {
            return totalStudents;
        }

        public static Student FindTopStudent(Student[] students)
        {
            Student topStudent = students[0];

            foreach (Student student in students)
            {
                if (student.score > topStudent.score)
                {
                    topStudent = student;
                }
            }

            return topStudent;
        }

        public static double CalculateAverageScore(Student[] students)
        {
            double total = 0;

            foreach (Student student in students)
            {
                total += student.score;
            }

            return total / students.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách sinh viên
            Student[] students =
            {
            new Student("Nguyen An", 8.5),
            new Student("Tran Binh", 6.8),
            new Student("Le Chi", 4.5),
            new Student("Pham Dung", 7.5),
            new Student("Hoang Minh", 9.0)
        };

            // 1. In tổng số sinh viên
            Console.WriteLine("Total students: " +
                              Student.GetTotalStudents());

            Console.WriteLine();

            // 2. In thông tin từng sinh viên
            Console.WriteLine("Student List:");

            foreach (Student student in students)
            {
                Console.WriteLine(
                    $"Name: {student.GetName()}, " +
                    $"Score: {student.GetScore():F1}, " +
                    $"Classification: {student.GetClassification()}, " +
                    $"Status: {(student.IsPassed() ? "Passed" : "Failed")}"
                );
            }

            Console.WriteLine();

            // 3. Tìm sinh viên có điểm cao nhất
            Student topStudent = Student.FindTopStudent(students);

            Console.WriteLine("Top student:");
            Console.WriteLine(
                $"Name: {topStudent.GetName()}, " +
                $"Score: {topStudent.GetScore():F1}"
            );

            Console.WriteLine();

            // 4. Tính điểm trung bình của lớp
            double average = Student.CalculateAverageScore(students);

            Console.WriteLine($"Class average score: {average:F2}");
        }
    }

}
}
