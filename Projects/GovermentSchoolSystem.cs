namespace SchoolsCourses;

sealed class School
{
    internal readonly string Name;
    private string _mail;
    private string _phoneNumber;
    private string _address;

    private List<Course> _courses = new List<Course>();
    
    public School(string name, string mail, string phoneNumber, string address)
    {
        Name = name;
        _mail = mail;
        _phoneNumber = phoneNumber;
        _address = address;
    }

    public void AddCourse(params Course[] courses)
    {
        _courses.AddRange(courses);
    }

    public void RemoveCourse(params Course[] courses)
    {
        _courses.RemoveAll(c => _courses.Contains(c));
    }

    public static void TheMostRevenueSchool(List<School> schools)
    {
        int indexMostRevenue = 0;
        double mostRevenue = 0;

        for (int i = 0; i < schools.Count; i++)
        {
            double revenue = 0;
            for (int j = 0; j < schools[i]._courses.Count; j++)
            {
                revenue += schools[i]._courses[j].Students.Count * schools[i]._courses[j].Price;
            }

            if (revenue > mostRevenue)
            {
                indexMostRevenue = i;
                mostRevenue = revenue;
            }
        }
        
        Console.WriteLine($"The most revenue school: {schools[indexMostRevenue].Name}, Revenue: {mostRevenue} AMD");
        schools[indexMostRevenue].PrintInfo();
        Console.WriteLine();
        schools[indexMostRevenue].PrintCoursesInfo();
        
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"SchoolName: {Name}, Email: {_mail}, Phone: {_phoneNumber}, Address: {_address}");
    }

    public void PrintCoursesInfo()
    {
        Console.WriteLine($"Courses: {_courses.Count} in {Name}");
        foreach (Course course in _courses)
        {
            course.PrintInfo();
        }
        Console.WriteLine();
    }
}

sealed class Course
{
    internal readonly string Name;
    private int _duration;
    private int _maxStudents;
    internal Instructor Instructor;
    private School _school;
    internal double Price;

    internal List<Student> Students = new List<Student>();

    public Course(string name, int duration, int maxStudents, Instructor instructor, School school, double price)
    {
        Name = name;
        _duration = duration;
        _maxStudents = maxStudents;
        Instructor = instructor;
        _school = school;
        Price = price;
    }

    public void AddStudent(params Student[] students)
    {
        Students.AddRange(students);
    }

    public void RemoveStudent(params Student[] students)
    {
        Students.RemoveAll(s => Students.Contains(s));
    }

    public static void AverageAgeOfStudents(List<Course> courses)
    { 
        int age = 0;
        int studentCount = 0;
        
        foreach (Course course in courses)
        {
            studentCount += course.Students.Count;
            foreach (Student student in course.Students)
            {
                age += student.GetAge();
            }
        }
        
        age = (studentCount != 0) ? age / studentCount : 0;
        
        Console.WriteLine($"Average age of all students: {age} years");
        
    }

    public static void PrintMostProfitableCourse(List<Course> courses)
    {
        double mostProfit = 0;
        int index = 0;

        for (int i = 0; i < courses.Count; i++)
        {
            double profit = 0;
            profit += courses[i].Students.Count * courses[i].Price;

            if (profit > mostProfit)
            {
                index = i;
                mostProfit = profit;
            }
        }
        
        Console.WriteLine($"The most profitable course is {courses[index].Name}");
        courses[index].PrintInfo();
        Console.WriteLine();
        courses[index].PrintCourseStudentsInfo();
        
    }

    public static void PrintAllCourses(List<Course> courses)
    {
        foreach (Course course in courses)
        {
            Console.WriteLine($"{course._school.Name} - {course.Name}: {course.Students.Count}, {course.Price} => {course.Students.Count * course.Price}");
        }
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Course: {Name}, School: {_school.Name}, Instructor: {Instructor} Duration: {_duration} months, Max Students: {_maxStudents}, Price: {Price} AMD");
    }

    public void PrintCourseStudentsInfo()
    {
        Console.WriteLine($"Students: {Students.Count} in {Name} course");
        foreach (Student student in Students)
        {
            student.PrintInfo();
        }
    }
}

sealed class Student
{
    internal readonly string Name;
    private string _email;
    private string _phoneNumber;
    private DateTime _dateOfBirth;

    internal List<Course> Courses = new List<Course>();
    public Student(string name, string email, string phoneNumber, DateTime dateOfBirth)
    {
        Name = name;
        _email = email;
        _phoneNumber = phoneNumber;
        _dateOfBirth = dateOfBirth;
        
    }
    
    public void AddCourse(params Course[] courses)
    {
        Courses.AddRange(courses);
    }

    public void RemoveCourse(params Course[] courses)
    {
        Courses.RemoveAll(c => Courses.Contains(c));
    }

    public int GetAge()
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - _dateOfBirth.Year;

        if (currentDate < _dateOfBirth.AddYears(age)) age--;
        
        return age;
    }

    public static void SpendsTheMost(List<Student> students)
    {
        double most = 0;
        int index = 0;

        for (int i = 0; i < students.Count; i++)
        {
            double sum = 0;
            for (int j = 0; j < students[i].Courses.Count; j++)
            {
                sum += students[i].Courses[j].Price;
            }

            if (sum > most)
            {
                most = sum;
                index = i;
            }
        }
        
        Console.WriteLine($"The most spending student: {students[index].Name}, {most} AMD");
        students[index].PrintInfo();
        Console.WriteLine();
        students[index].PrintCoursesInfo();
        
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Student: {Name}, Email: {_email}, Phone: {_phoneNumber}, DOB: {_dateOfBirth.ToShortDateString()}");
    }
    
    public void PrintCoursesInfo()
    {
        Console.WriteLine($"Courses: {Courses.Count} for student {Name}");
        foreach (Course course in Courses)
        {
            course.PrintInfo();
        }
        Console.WriteLine();
    }
    
    
}

sealed class Instructor
{
    internal readonly string Name;
    private string _email;
    private string _phoneNumber;
    private int _yearsOfExperience;

    internal List<Course> Courses = new List<Course>();
    public Instructor(string name, string email, string phoneNumber, int yearsOfExperience)
    {
        Name = name;    
        _email = email;
        _phoneNumber = phoneNumber;
        _yearsOfExperience = yearsOfExperience;
    }

    public void AddCourse(params Course[] courses)
    {
        Courses.AddRange(courses);
    }

    public void RemoveCourse(params Course[] courses)
    {
        Courses.RemoveAll(c => Courses.Contains(c));
    }

    public static void TheMostExperiencedInstructor(List<Instructor> instructors)
    {
        int index = 0;
        
        for (int i = 1; i < instructors.Count; i++)
        {
            if (instructors[i]._yearsOfExperience > instructors[index]._yearsOfExperience) index = i;
        }
        
        Console.WriteLine($"The most experienced instructor is {instructors[index].Name}");
        instructors[index].PrintInfo();
        Console.WriteLine();
        instructors[index].PrintCoursesInfo();
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Instructor: {Name}, Email: {_email}, Phone: {_phoneNumber}, Experience: {_yearsOfExperience} years");
    }
    
    public void PrintCoursesInfo()
    {
        Console.WriteLine($"Courses: {Courses.Count} for instructor {Name}");
        foreach (Course course in Courses)
        {
            course.PrintInfo();
        }
        Console.WriteLine();
    }
}



class Program
{
    static void Main()
    {
        List<School> schools = new List<School>
            {
                new School("TUMO Center for Creative Technologies", "info@tumo.org", "+374-10-398413", "Yerevan, Armenia"), // Tumo
                new School("Armenian Code Academy", "info@aca.am", "+374-99-123456", "Yerevan, Armenia"), // ACA
                new School("MIC Academy", "info@mic.am", "+374-93-654321", "Yerevan, Armenia"), // MIC
                new School("PicsArt Academy", "info@picsart.com", "+374-11-567890", "Yerevan, Armenia"), //PicsArt
            };

            List<Instructor> instructors = new List<Instructor>
            {
                new Instructor("Arman Harutyunyan", "arman@tumo.org", "+374-91-456789", 8), //Tumo
                new Instructor("Narek Sargsyan", "narek@aca.am", "+374-93-987654", 5), // ACA
                new Instructor("Sona Avetisyan", "sona@mic.am", "+374-94-333222", 6), // MIC
                new Instructor("David Mkrtchyan", "david@picsart.com", "+374-98-654987", 7), //PicsArt
                new Instructor("Vahan Sahakyan", "vahan@tumo.org", "+374-95-123321", 9), // Tumo
                new Instructor("Anahit Ghazaryan", "anahit@aca.am", "+374-98-741852", 4), // ACA
                new Instructor("Edgar Khachatryan", "edgar@mic.am", "+374-99-369852", 10), // MIC
                new Instructor("Marina Vardanyan", "marina@picsart.com", "+374-97-258147", 6), //PicsArt
            };
            

            List<Course> courses = new List<Course>
            {
                new Course("C# Fundamentals", 3, 15, instructors[3], schools[3], 80000), // PicsArt
                new Course("ASP.NET Web Development", 4, 20, instructors[7], schools[3], 95000), //PicsArt
                new Course("Python for Data Science", 5, 18, instructors[1], schools[1], 120000), // ACA
                new Course("Machine Learning", 6, 12, instructors[5], schools[1], 150000), // ACA
                new Course("Graphic Design with AI", 4, 20, instructors[0], schools[0], 85000), // Tumo
                new Course("Mobile App Development", 5, 16, instructors[4], schools[0], 110000), // Tumo
                new Course("Cybersecurity Basics", 6, 14, instructors[6], schools[2], 130000), // MIC
                new Course("UI/UX Design", 4, 22, instructors[2], schools[2], 90000), // MIC
            };
            

            List<Student> students = new List<Student>
            {
                new Student("Karen Petrosyan", "karen@example.com", "+374-91-111111", new DateTime(2002, 4, 15)),
                new Student("Mariam Hakobyan", "mariam@example.com", "+374-99-222222", new DateTime(2001, 9, 22)),
                new Student("Hayk Grigoryan", "hayk@example.com", "+374-95-333333", new DateTime(1999, 11, 5)),
                new Student("Ani Manukyan", "ani@example.com", "+374-96-444444", new DateTime(2000, 7, 30)),
                new Student("Lusine Davtyan", "lusine@example.com", "+374-97-555555", new DateTime(2003, 3, 10)),
                new Student("Gor Hovhannisyan", "gor@example.com", "+374-94-666666", new DateTime(2002, 5, 18)),
                new Student("Aram Poghosyan", "aram@example.com", "+374-93-777777", new DateTime(1998, 8, 25)),
                new Student("Diana Avagyan", "diana@example.com", "+374-92-888888", new DateTime(2004, 2, 14)),
                new Student("Varduhi Sargsyan", "varduhi@example.com", "+374-91-999999", new DateTime(2001, 6, 12)),
                new Student("Tigran Melikyan", "tigran@example.com", "+374-98-000000", new DateTime(2000, 12, 20)),
                new Student("Narek Avetisyan", "narek@example.com", "+374-94-101010", new DateTime(1999, 10, 5)),
                new Student("Sofya Grigoryan", "sofya@example.com", "+374-97-202020", new DateTime(2002, 11, 17)),
                new Student("David Hakobyan", "david@example.com", "+374-93-212121", new DateTime(2003, 1, 3)),
                new Student("Lilit Manukyan", "lilit@example.com", "+374-94-232323", new DateTime(2000, 4, 8)),
                new Student("Armen Harutyunyan", "armen@example.com", "+374-95-242424", new DateTime(2001, 9, 25)),
                new Student("Siranush Petrosyan", "siranush@example.com", "+374-96-252525", new DateTime(2002, 6, 17)),
                new Student("Karen Mkrtchyan", "karen.m@example.com", "+374-91-262626", new DateTime(1999, 5, 12)),
                new Student("Liana Avagyan", "liana@example.com", "+374-92-272727", new DateTime(2003, 7, 19)),
                new Student("Vahagn Grigoryan", "vahagn@example.com", "+374-93-282828", new DateTime(1998, 10, 28)),
                new Student("Marine Davtyan", "marine@example.com", "+374-94-292929", new DateTime(2004, 12, 5)),
                new Student("Edgar Sargsyan", "edgar@example.com", "+374-95-303030", new DateTime(2002, 2, 14)),
                new Student("Tatevik Poghosyan", "tatevik@example.com", "+374-96-313131", new DateTime(2001, 11, 20)),
                new Student("Gevorg Melikyan", "gevorg@example.com", "+374-91-323232", new DateTime(1999, 8, 30)),
                new Student("Nune Hovhannisyan", "nune@example.com", "+374-92-333333", new DateTime(2000, 3, 18))
            };
            
            schools[0].AddCourse(courses[4], courses[5]);
            schools[1].AddCourse(courses[2], courses[3]);
            schools[2].AddCourse(courses[6], courses[7]);
            schools[3].AddCourse(courses[0], courses[1]);
            
            instructors[0].AddCourse(courses[4]);
            instructors[1].AddCourse(courses[2]);
            instructors[2].AddCourse(courses[6]);
            instructors[3].AddCourse(courses[0]);
            instructors[4].AddCourse(courses[5]);
            instructors[5].AddCourse(courses[3]);
            instructors[6].AddCourse(courses[7]);
            instructors[7].AddCourse(courses[1]);
            
            courses[0].AddStudent(students[0], students[1], students[2], students[3], students[4]);
            courses[1].AddStudent(students[5], students[6], students[7], students[8], students[9]);
            courses[2].AddStudent(students[10], students[11], students[12], students[13], students[14]);
            courses[3].AddStudent(students[15], students[16], students[17], students[18], students[19]);
            courses[4].AddStudent(students[20], students[21], students[22], students[23]);
            courses[5].AddStudent(students[0], students[5], students[10], students[15], students[20]);
            courses[6].AddStudent(students[4], students[9], students[0], students[19], students[23]);
            courses[7].AddStudent(students[2], students[6], students[12], students[16]);

            foreach (Student student in students)
            {
                foreach (Course course in courses)
                {
                    if (course.Students.Contains(student))
                    {
                        student.AddCourse(course);
                    }
                }
            }
            
            Console.WriteLine("\nAll courses:\n");
            Course.PrintAllCourses(courses);
            Console.WriteLine("\n");
            
            School.TheMostRevenueSchool(schools);
            Console.WriteLine();

            Student.SpendsTheMost(students);
            Console.WriteLine();
            
            Course.AverageAgeOfStudents(courses);
            Console.WriteLine("\n");
            
            Course.PrintMostProfitableCourse(courses);
            Console.WriteLine("\n");
            
            Instructor.TheMostExperiencedInstructor(instructors);
            Console.WriteLine();
            
    }
}