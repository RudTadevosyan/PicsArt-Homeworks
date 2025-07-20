namespace MultiLevelJoinLinq;

class Program
{
    static void Main(string[] args)
    {
        var students = new List<(int Id, string Name)>
        {
            (1, "Alice"),
            (2, "Bob"),
            (3, "Charlie")
        };

        var enrollments = new List<(int StudentId, int CourseId)>
        {
            (1, 101),
            (1, 102),
            (2, 102),
            (3, 103)
        };

        var courses = new List<(int CourseId, string CourseName, int Difficulty)>
        {
            (101, "Math", 4),
            (102, "Science", 3),
            (103, "History", 2)
        };

        var result = from enr in enrollments
            join student in students on enr.StudentId equals student.Id
            join course in courses on enr.CourseId equals course.CourseId
            where course.Difficulty > 3
            select new
            {
                StudentName = student.Name,
                CourseName = course.CourseName,
                Difficulty = course.Difficulty
            };

        foreach (var s in result)
        {
            Console.WriteLine($"{s.StudentName} is enrolled in {s.CourseName} (Difficulty: {s.Difficulty})");
        }
        
        
    }
}