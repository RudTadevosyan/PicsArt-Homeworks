using System;
namespace GridNavigation;

class Program
{
    static void Main(string[] args)
    {
            Random randomNumber = new Random();
            int row  = 10;
            int col = 10;
            char[,] grid = new char[row,col];

            int rowCoordinates = 0;
            int colCoordinates = 0;

            int randomRowIndex = 0;
            int randomColIndex = 0;

            do{
                randomRowIndex = randomNumber.Next(0, row);
                randomColIndex = randomNumber.Next(0, col);
            }while(randomRowIndex == 0 && randomColIndex == 0);

            grid[rowCoordinates,colCoordinates] = 'P';
            grid[randomRowIndex,randomColIndex] = 'X';

            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    if((i == rowCoordinates && j == colCoordinates) || (i == randomRowIndex && j == randomColIndex)){
                        continue;
                    }
                    grid[i,j] = '*';
                }
            }

            Console.WriteLine();

            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                   Console.Write(grid[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.Write("You need to navigate P -> X\nFor exiting press 'X'\n\nFor navigation use A(<), D(>), W(^), S(v)\n");
            while(true)
            {
                Console.Write("Navigate the P: ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if(input != 0)
                {
                    input = char.ToUpper(input);
                    switch(input)
                    {
                        case 'A':
                            if(colCoordinates != 0)
                            {
                                grid[rowCoordinates, colCoordinates - 1] = 'P';
                                grid[rowCoordinates, colCoordinates] = '*';
                                
                                colCoordinates -= 1;
                                
                                for(int i = 0; i < grid.GetLength(0); i++)
                                {
                                    for(int j = 0; j < grid.GetLength(1); j++)
                                    {
                                        Console.Write(grid[i,j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();
                            }
                            else{
                                Console.WriteLine("You can't go left");
                            }
                            break;

                        case 'D':
                            if(colCoordinates != col - 1)
                            {
                                grid[rowCoordinates, colCoordinates + 1] = 'P';
                                grid[rowCoordinates, colCoordinates] = '*';

                                colCoordinates += 1;
                                
                                for(int i = 0; i < grid.GetLength(0); i++)
                                {
                                    for(int j = 0; j < grid.GetLength(1); j++)
                                    {
                                        Console.Write(grid[i,j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();
                            }
                            else{
                                Console.WriteLine("You can't go right");
                            }
                            break;
                        case 'W':
                            if(rowCoordinates != 0)
                            {
                                grid[rowCoordinates - 1, colCoordinates] = 'P';
                                grid[rowCoordinates, colCoordinates] = '*';

                                rowCoordinates -= 1;
                                
                                for(int i = 0; i < grid.GetLength(0); i++)
                                {
                                    for(int j = 0; j < grid.GetLength(1); j++)
                                    {
                                        Console.Write(grid[i,j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();
                            }
                            else{
                                Console.WriteLine("You can't go up");
                            }
                            break;                        
                        case 'S':
                            if(rowCoordinates != row - 1)
                            {
                                grid[rowCoordinates + 1, colCoordinates] = 'P';
                                grid[rowCoordinates, colCoordinates] = '*';

                                rowCoordinates += 1;
                                
                                for(int i = 0; i < grid.GetLength(0); i++)
                                {
                                    for(int j = 0; j < grid.GetLength(1); j++)
                                    {
                                        Console.Write(grid[i,j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();
                            }
                            else{
                                Console.WriteLine("You can't go down");
                            }
                            break;               
                        case 'X':
                            return;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input can't be empty!");
                }

                if(rowCoordinates == randomRowIndex && colCoordinates == randomColIndex){
                    Console.WriteLine("You Won!");
                    break;
                }
            }

    }
}