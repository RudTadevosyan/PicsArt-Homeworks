using System;
namespace SchoolManagmentSystem;

class Program
{
    public class Student
    {
        public string Name;
        public int Age;
        public float Grade;
        
        public Student(string name, int age, float grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        public void DisplayStudent()
        {
            Console.WriteLine($"Student: {Name}, Age: {Age}, Grade: {Grade:F1}");
        }
    }

    public class Teacher
    {
        public string Name;
        public string Subject;
        public float Experience;

        public Teacher(string name, string subject, float experience)
        {
            Name = name;
            Subject = subject;
            Experience = experience;
        }

        public void DisplayTeacher()
        {
            Console.WriteLine($"Teacher: {Name}, Subject: {Subject}, Experience: {Experience:F1} years");
        }
    }

    public class School
    {
        public Student[] students;
        public Teacher[] teachers;

        public School(int studentCount, int teacherCount)
        {
            students = new Student[studentCount];
            teachers = new Teacher[teacherCount];
        }


    }
    static void Main(string[] args)
    {

        int n = 3;

        School mySchool = new School(n, n);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();

            string? name;
            do{
                Console.Write($"Input a student name {i + 1}: ");
                name = Console.ReadLine();
            }while(string.IsNullOrEmpty(name));

            Console.Write("Input student age: ");
            int age;
            while(!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Input student age: ");
            }

            Console.Write("Input student grade (0-100): ");
            float grade;
            while(!float.TryParse(Console.ReadLine(), out grade))
            {
                Console.Write("Input student grade: ");
            }

            mySchool.students[i] = new Student(name, age, grade);            
            
        }

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine();

            string? name;
            do{
                Console.Write($"Input a teacher's name {i + 1}: ");
                name = Console.ReadLine();
            }while(string.IsNullOrEmpty(name));

            string? subject;
            do{
                Console.Write($"Input a teacher's subject: ");
                subject = Console.ReadLine();
            }while(string.IsNullOrEmpty(subject));

            Console.Write("Input teacher's experience (years): ");
            float experience;
            while(!float.TryParse(Console.ReadLine(), out experience))
            {
                Console.Write("Input a teacher's experience: ");
            }

            mySchool.teachers[i] = new Teacher(name, subject, experience);

        }

        Console.WriteLine();
                
        Console.WriteLine("Here you can see the teachers with less than 2 years of experience and\nStudent with highest mark\n");
        int maxGradeIndex = 0;

        for(int i = 0; i < n; i++)
        {     
            if(mySchool.students[maxGradeIndex].Grade < mySchool.students[i].Grade)
            {
                maxGradeIndex = i;
            }

            if(mySchool.teachers[i].Experience < 2)
            {
                mySchool.teachers[i].DisplayTeacher();
                Console.WriteLine();       
            }
        }

        mySchool.students[maxGradeIndex].DisplayStudent();
        Console.WriteLine();


    }
}
