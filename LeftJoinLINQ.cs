using System.Diagnostics.Tracing;

namespace LeftJoinLINQ;

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
        var submissions = new List<(int StudentId, string AssignmentName)>
        {
            (1, "Math HW1"),
            (2, "Math HW2"),
            (2, "Science HW1")
        };

        var result =
            from s in students
            join sb in submissions on s.Id equals sb.StudentId into studentSb
            select new 
            {
                StudentName = s.Name,
                Submissions = studentSb.Count()
            }into wCount
            orderby wCount.Submissions descending
            select wCount;
                
        foreach (var s in result)
        {
            Console.WriteLine($"{s.StudentName} - {s.Submissions}");
        }
        
    }
}