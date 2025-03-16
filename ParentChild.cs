namespace ParentChild;

class Program
{
    abstract class Human
    {
        public string Name { get; init; }
        public int Age { get; init; }

        protected Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    sealed class Parent : Human
    {
        public double Salary { get; private set; }

        public Parent(string name, int age, double salary) : base(name, age)
        {
            Salary = salary;
        }
    }

    sealed class Child : Human
    {
        private Parent Father { get; }
        private Parent Mother { get; }

        public Child(string name, int age, Parent parent1, Parent parent2):base(name, age)
        {
            Father = parent1;
            Mother = parent2;
            AddChild(this);
        }
        
        private static int _capacity = 10;
        private static int _size;
        private static Child[] _children = new Child[_capacity];

        private static void AddChild(Child a)
        {
            if (_size >= _capacity)
            {
                _capacity *= 2;
                Array.Resize(ref _children, _capacity);
            }
            
            _children[_size] = a;
            _size++;
        }

        public static void DisplayAllChildren()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(_children[i]);
            }
            Console.WriteLine();
        }

        public static void DisplayParentsAgeLess70()
        {
            for (int i = 0; i < _size; i++)
            {
                if(_children[i].Father.Age + _children[i].Mother.Age < 70) Console.WriteLine(_children[i]);
            }
        }

        public static void ElderChildFatherSalary()
        {
            int index = 0;
            for (int i = 1; i < _size; i++)
            {
                if (_children[index].Age < _children[i].Age) index = i;
            }

            Console.WriteLine($"{_children[index].Name} - {_children[index].Father.Name} {_children[index].Father.Salary}");
        }

        public static void DisplayRichestFamilyChild()
        {
            int index = 0;
            for (int i = 1; i < _size; i++)
            {
                if((_children[index].Father.Salary + _children[index].Mother.Salary) < (_children[i].Father.Salary + _children[i].Mother.Salary)) index = i;
            }
            
            Console.WriteLine($"{_children[index]} - Family's budget {_children[index].Father.Salary + _children[index].Mother.Salary}");
        }

        public static void SwapOlderLittleChildren()
        {
            int older = 0;
            int little = 0;

            for (int i = 0; i < _size; i++)
            {
                if(_children[older].Age < _children[i].Age) older = i;
                if(_children[little].Age > _children[i].Age) little = i;
            }
            
            (_children[older], _children[little]) = (_children[little], _children[older]);
        }

        public override string ToString()
        {
            return $"{Name} {Age} yo: Parents - {Father.Name}, {Mother.Name}";
        }
        
    }


    static void Main()
    {

        Child c1 = new Child("Tigran", 13, new Parent("Anna", 32, 270000), new Parent("Arman", 44, 500000));
        Child c2 = new Child("Mariam", 12, new Parent("Karen", 27, 350000), new Parent("Sona", 38, 480000));
        Child c3 = new Child("David", 14, new Parent("Gor", 45, 600000), new Parent("Narine", 42, 550000));
        Child c4 = new Child("Sargis", 11, new Parent("Artyom", 39, 320000), new Parent("Anahit", 36, 410000));
        Child c5 = new Child("Lilit", 15, new Parent("Vahan", 47, 700000), new Parent("Marina", 44, 550000));
        Child c6 = new Child("Narek", 13, new Parent("Hovhannes", 41, 500000), new Parent("Lusine", 40, 470000));
        Child c7 = new Child("Arman", 12, new Parent("Sergey", 37, 310000), new Parent("Gayane", 32, 390000));
        Child c8 = new Child("Emma", 14, new Parent("Artak", 43, 560000), new Parent("Hasmik", 41, 530000));
        Child c9 = new Child("Aren", 10, new Parent("Tigran", 35, 290000), new Parent("Sofya", 34, 370000));
        Child c10 = new Child("Ani", 11, new Parent("Levon", 38, 330000), new Parent("Mane", 31, 420000));
        
        Console.WriteLine("\nDisplaying all children\n");
        Child.DisplayAllChildren();
        
        Console.WriteLine("\nDisplaying all children whose parents age < 70\n");
        Child.DisplayParentsAgeLess70();
        
        Console.WriteLine("\nDisplaying Elder child's father salary");
        Child.ElderChildFatherSalary();
        
        Console.WriteLine("\nDisplaying Richest familie's child");
        Child.DisplayRichestFamilyChild();
        
        Console.WriteLine("\nSwaping Older Little Children (Lilit, Aren)\n");
        Child.SwapOlderLittleChildren();
        Child.DisplayAllChildren();
        

    }
}