using System.Text;
namespace Shapes;

class Program
{

    abstract class Shape
    {
        protected string? Name;
        protected int Width;
        protected int Height;
        
        public abstract int Surface();
        public abstract string Draw();

        public void Print()
        {
            Console.WriteLine($"{Name}, S = {Surface()}\n{Draw()}\n");
        }
    }

    class Square : Shape
    {
        
        public Square(int width)
        {
            this.Width = width;
            this.Height = width;
            this.Name = "Square";
        }

        public override int Surface()
        {
            return Width * Height;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    sb.Append("+ ");
                }
                sb.AppendLine();
            }
            
            return sb.ToString();
        }
    }
    
    class Rectangle : Shape
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Name = "Rectangle";
        }

        public override int Surface()
        {
            return Width * Height;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    sb.Append("+ ");
                }
                sb.AppendLine();
            }
            
            return sb.ToString();
        }
    }
    
    static void Main()
    {
        Shape[] shapes = new Shape[2];
        shapes[0] = new Square(5);
        shapes[1] = new Rectangle(3,7);
        
        foreach(Shape s in shapes){
            s.Print();
        }
    }
}