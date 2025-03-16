using System.Text;

namespace TicTacToeGame;

class Program
{
    class Grid
    {
        private int _size;
        public int Size => _size;
        
        public char[,] _grid;
        
        public Grid(int size)
        {
            if (size <= 0)
            {
                Console.WriteLine("Size must be greater than 0");
                Environment.Exit(1);
            }
            _size = size;
            _grid = new char[_size, _size];
            GenerateGrid();
        }
        private void GenerateGrid()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _grid[i, j] = ' ';
                }
            }
        }

        internal void ShowGrid()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine();
            
            for (int k = 0; k < _size; k++)
                sb.Append("______");
            sb.Append("_\n");
            
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    sb.Append("|");
                    sb.Append($"  {_grid[i,j]}  ");
                }
                sb.Append("|\n");
                for (int k = 0; k < _size; k++)
                    sb.Append("______");
                sb.Append("_\n");
            }
            Console.WriteLine(sb.ToString());
        }

        internal bool Occupy(int i, int j)
        {
            return _grid[i, j] != ' ';
        }
    }
    
    abstract class Player
    {
        internal int ChosenRow;
        internal int ChosenColumn;
        internal abstract void Move(Grid grid);
    }
    
    class RealPlayer : Player
    {
        internal char Symbol;

        internal RealPlayer(char symbol) => Symbol = symbol;
        
        internal override void Move(Grid grid)
        {
            Console.Write("Row: ");
            while (!int.TryParse(Console.ReadLine(), out ChosenRow) || ChosenRow < 0 || ChosenRow >= grid.Size)
                Console.Write("Row: ");
            
            Console.Write("Column: ");
            while (!int.TryParse(Console.ReadLine(), out ChosenColumn) || ChosenColumn < 0 || ChosenColumn >= grid.Size)
                Console.Write("Column: ");

            if (grid.Occupy(ChosenRow, ChosenColumn))
            {
                Console.WriteLine("Field is occupied!");
                Move(grid);
            }
            else
            {
                grid._grid[ChosenRow, ChosenColumn] = Symbol;
                grid.ShowGrid();
            }
        }
    }

    class AiPlayer : Player
    {
        internal char Symbol;
        internal AiPlayer(char symbol) => Symbol = symbol;

        private Random rand = new Random();
        internal override void Move(Grid grid)
        {
            int row, col;
            do
            {
                row = rand.Next(0, grid.Size);
                col = rand.Next(0, grid.Size);
            } while (grid.Occupy(row, col));
            
            grid._grid[row, col] = Symbol;
            grid.ShowGrid();
        }
    }
    
    class GameProcess
    {
        private static bool _turn = true;
        private static bool _winX, _winO;
        
        static RealPlayer realPlayer = new RealPlayer('X');
        static AiPlayer aiPlayer = new AiPlayer('O');

        internal static void StartOfTheGame(Grid grid)
        {
            Console.Write("Choose [x] or [o]: ");
            char ch = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (ch != 'x' && ch != 'o') StartOfTheGame(grid);
            
            realPlayer.Symbol = (ch == 'x') ? 'X' : 'O';
            aiPlayer.Symbol = (realPlayer.Symbol == 'X') ? 'O' : 'X';
            
            _turn = (realPlayer.Symbol == 'X');
            
            ProcessOfGame(grid);
        }

        private static void ProcessOfGame(Grid grid)
        {
            grid.ShowGrid();
            while (true)
            {
                if (_turn) realPlayer.Move(grid);
                else aiPlayer.Move(grid);

                if (GameFinishWin(grid))
                {
                    grid.ShowGrid();
                    if(_winX) Console.WriteLine("X wins!");
                    else if(_winO) Console.WriteLine("O wins!");
                    else Console.WriteLine("Draw!");
                    
                    break;
                }
                
                _turn = !_turn;
            }
        }
        
        private static bool GameFinishWin(Grid grid)
        {
            bool filled = true;

            int diagX = 0, diagO = 0;
            int revDiagX = 0, revDiagO = 0;
            
            for (int i = 0; i < grid.Size; i++)
            {
                int rowX = 0, rowO = 0;
                int colX = 0, colO = 0;
                
                for (int j = 0; j < grid.Size; j++)
                {
                    if (!grid.Occupy(i, j)) filled = false;
                    
                    if (grid._grid[i, j] == 'X') rowX++;
                    else if (grid._grid[i, j] == 'O') rowO++;
                    
                    if (grid._grid[j, i] == 'X') colX++;
                    else if (grid._grid[j, i] == 'O') colO++;
                }
                
                if (grid._grid[i, i] == 'X') diagX++;
                else if (grid._grid[i, i] == 'O') diagO++;
                
                if (grid._grid[i, grid.Size - 1 - i] == 'X') revDiagX++;
                else if (grid._grid[i, grid.Size - 1 - i] == 'O') revDiagO++;
                
                if (rowX == grid.Size || colX == grid.Size || diagX == grid.Size || revDiagX == grid.Size) return _winX = true;
                if (rowO == grid.Size || colO == grid.Size || diagO == grid.Size || revDiagO == grid.Size) return _winO = true;
            }
            return filled;
        }
    }

    static void Main()
    {
        Grid grid = new Grid(3 );
        GameProcess.StartOfTheGame(grid);
    }
}
