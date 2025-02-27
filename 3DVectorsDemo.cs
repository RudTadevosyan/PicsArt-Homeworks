namespace _3DVectorsDemo;
class Program
{
    public class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;
        
        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        
        public override string ToString()
        {
            return $"({_x} ,{_y}, {_z})";
        }
        
        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a._x + b._x, a._y + b._y, a._z + b._z);
        }
        
        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a._x - b._x, a._y - b._y, a._z - b._z);
            
        }
        
        public static Vector3D operator *(Vector3D a, double b)
        {
            return new Vector3D(a._x * b, a._y * b, a._z * b);
        }
        
        public static Vector3D operator /(Vector3D a, double b)
        {
            if(b == 0)
            {
                Console.WriteLine("Can't divide on 0!");
                return a;
            }
            return new Vector3D(a._x / b, a._y / b, a._z / b);
        }
        
        public static bool operator ==(Vector3D a, Vector3D b)
        {
            return a._x == b._x && a._y == b._y && a._z == b._z;
        }
        
        public static bool operator !=(Vector3D a, Vector3D b)
        {
            return !(a._x == b._x && a._y == b._y && a._z == b._z);
        }
        
        public static bool operator false(Vector3D a)
        {
            return a._x == 0 && a._y == 0 && a._z == 0;     
        }
        
        public static bool operator true(Vector3D a)
        {
            return !(a._x == 0 && a._y == 0 && a._z == 0);     
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            return this == (Vector3D)obj;
        }
        
        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
        }
        
    }
    
    
    public static void Main(string[] args)
    {
        Vector3D vector1 = new Vector3D(1, 5, 3.5);
        Vector3D vector2 = new Vector3D(4.0, 5.0, 6.5);

        Vector3D sum = vector1 + vector2;
        Console.WriteLine($"Sum: {sum}");

        Vector3D difference = vector1 - vector2;
        Console.WriteLine($"Difference: {difference}");

        Vector3D product = vector1 * 2;
        Console.WriteLine($"Product: {product}");

        Vector3D quotient = vector1 / 2;
        Console.WriteLine($"Quotient: {quotient}");
        
        Vector3D quotient0 = vector2 / 0;
        Console.WriteLine($"Quotient: {quotient}");

        Console.WriteLine($"\nAre vectors equal? {vector1 == vector2}");
        Console.WriteLine($"Are vectors not equal? {vector1 != vector2}");
    
    }
}