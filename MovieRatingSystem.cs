namespace MovieRatingSystem;

class Program
{
    public class MovieRatingSystem
    {
        public string Name;
        private int _rating;

        public MovieRatingSystem(string name)
        {
            this.Name = name;
        }

        public void RatingSystem()
        {
            Console.WriteLine();
            Console.Write($"Please rate the movie {this.Name} (0 - 5): ");
            int rate;
            while(!int.TryParse(Console.ReadLine(), out rate))
            {
                Console.WriteLine("Invalid Input!");
                Console.Write($"Please rate the movie {this.Name} (0 - 5): ");
            }

            this.MovieRating = rate;
            
        }

        public int MovieRating
        {
            get
            {
                return this._rating;
            }

            set
            {
                if(value < 0 || value > 5)
                {
                    Console.WriteLine("Wrong rating, please rate from 0 to 5!");
                    this.RatingSystem();
                }
                else
                {
                    this._rating = value;
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Movie name: {this.Name}, Rating: {this._rating}");
        }

    }


    static void Main(string[] args)
    {
        MovieRatingSystem[] movies = new MovieRatingSystem[2];

        movies[0] = new MovieRatingSystem("James Bond");
        movies[1] = new MovieRatingSystem("Rocky");


        foreach(MovieRatingSystem movie in movies)
        {
            movie.RatingSystem();
        }

        Console.WriteLine();

        foreach(MovieRatingSystem movie in movies)
        {
            movie.DisplayInfo();
        }

    }
}
