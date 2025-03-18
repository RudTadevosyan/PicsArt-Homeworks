namespace AcademyCourses;

class Program
{
    class Course
    {
        public string CourseName { get; init; }
        public int MonthlyPrice { get; private set; }
        
        private static Module[]? _modules;

        protected Course(string courseName, int monthlyPrice, Module[] modules)
        {
            if(monthlyPrice < 0) { throw new ArgumentException(nameof(monthlyPrice)); }
            
            CourseName = courseName;
            MonthlyPrice = monthlyPrice;
            _modules = modules;
        }
        
        
    }
    class Module
    {
        public string Title { get; init; }
        public int Duration { get; private set; }

        public Module(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }
    }

    class Group
    {
        public string GroupName { get; init; }
        public int StudentCount { get; private set; }
        public Course Course { get; init; }

        public Group(string groupName, int studentCount, Course course)
        {
            GroupName = groupName;
            StudentCount = studentCount;
            Course = course;
        }
    }

    class Web : Course
    {
        public string WebType { get; init; }

        public Web(string courseName, int monthlyPrice, string webType, Module[] modules) : base(courseName,
            monthlyPrice, modules)
        {
            if (webType != "frontend" && webType != "backend" && webType != "fullstack")
            {
                throw new ArgumentException(nameof(webType));
            }

            WebType = webType;
        }
    }

    class Game : Course
    {
        public string GameEngine { get; init; }
        
        public Game(string courseName, int monthlyPrice, string gameEngine, Module[] modules) : base(courseName,
            monthlyPrice, modules)
        {
            if (gameEngine != "unity" && gameEngine != "unreal")
            {
                throw new ArgumentException(nameof(gameEngine));
            }
            
            GameEngine = gameEngine;
        }
    }

    class Ai : Course
    {
        public Ai(string courseName, int monthlyPrice, Module[] modules): base(courseName, monthlyPrice, modules) { }
    }

    static void FindWebStudents(Group[] groups)
    {
        int count = 0;
        foreach (Group group in groups)
        {
            if (group.Course is Web)
            {
                count += group.StudentCount;
            }
        }
        
        Console.WriteLine($"\nWeb Development learning students: {count}");
    }

    static void UnrealEngineIncome(Group[] groups)
    {
        int income = 0;
        foreach (Group group in groups)
        {
            if (group.Course is Game game && game.GameEngine == "unreal")
            {
                income += group.StudentCount * group.Course.MonthlyPrice;
            }
        }
        
        Console.WriteLine($"\nGame Development income for Unreal: {income}");
    }

    static void TheMostRequiredCourse(Group[] groups)
    {
        int index = 0;
        for (int i = 1; i < groups.Length; i++)
        {
            if (groups[index].StudentCount < groups[i].StudentCount) index = i;
        }
        
        Console.WriteLine($"\nThe Most Required Course: {groups[index].Course.CourseName}");
    }
    
    static void Main()
    {
        Course[] courses = new Course[]
        {
            new Web("FrontEnd Development", 50000, "frontend", new Module[]{
                new Module("HTML & CSS", 2), new Module("JavaScript", 3)
            }),

            new Web("FullStack Development", 60000, "fullstack", new Module[]
            {
                new Module("Node.js", 4), new Module("React", 5)
            }),

            new Web("BackEnd Development", 55000, "backend", new Module[]
            {
                new Module("C# Core", 4), new Module("C# .NET", 5)
            }),

            new Game("GameDevelopment", 72000, "unity", new Module[]
            {
                new Module("C# for Unity", 5), new Module("Physics in Games", 4)
            }),

            new Game("Game Dev Advanced", 42000, "unreal", new Module[]
            {
                new Module("Blueprints", 6), new Module("C++ for Unreal", 7)
            }),

            new Ai("Machine Learning", 80000, new Module[]
            {
                new Module("Python for AI", 6), new Module("Deep Learning", 8)
            })
        };


        Group[] groups = new Group[]
        {
            new Group("FrontEnd group 1", 15, courses[0]),
            new Group("FullStack group 1", 12, courses[1]),
            new Group("BackEnd group 1", 11, courses[2]),
            new Group("Game Dev Group 1", 20, courses[3]),
            new Group("Game Dev Group 2", 18, courses[4]),
            new Group("AI Group 1", 10, courses[5]),
        };
        
        FindWebStudents(groups);
        UnrealEngineIncome(groups);
        TheMostRequiredCourse(groups);
        
        
    }
}