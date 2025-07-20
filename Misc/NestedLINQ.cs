namespace NestedLINQ;

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
        var assignments = new List<(int StudentId, string AssignmentName, int Score)>
        {
            (1, "Math HW1", 85),
            (1, "Math HW2", 90),
            (2, "Science HW1", 75),
            (2, "Science HW2", 70),
            (3, "History HW1", 95)
        };

        var result =
            from s in students
            join a in assignments on s.Id equals a.StudentId
            group a by s
            into g
            where g.Any(x => x.Score > 80)
            select new
            {
                StudentName = g.Key.Name,
                TopScore = g.Max(x => x.Score)
            };

        foreach (var s in result)
        {
            Console.WriteLine($"{s.StudentName}: {s.TopScore}");
        }






















    }
}