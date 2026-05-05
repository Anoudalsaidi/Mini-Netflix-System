using System;
using System.Collections.Generic;

namespace MiniNetflix
{
    // 1. This class represents a movie with basic details
    class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }

        // 2. Private field to store rating securely
        private int rating;

        // 3. Property with validation to ensure rating is between 1 and 10
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value >= 1 && value <= 10)
                    rating = value;
                else
                    Console.WriteLine("Invalid rating! Must be between 1 and 10.");
            }
        }

        // 4. Constructor initializes movie data
        public Movie(string title, string genre, int rating)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
        }
    }

    // 5. This class represents a watching session
    class WatchSession
    {
        public string UserName { get; set; }
        public string MovieTitle { get; set; }

        // 6. Constructor initializes session data
        public WatchSession(string userName, string movieTitle)
        {
            UserName = userName;
            MovieTitle = movieTitle;
        }
    }

    // 7. This class represents a user in the system
    class User
    {
        public string Name { get; set; }

        // 8. WatchCount is read-only from outside for data protection
        public int WatchCount { get; private set; } = 0;

        // 9. List stores all watched movies
        private List<string> watchedMovies = new List<string>();

        public User(string name)
        {
            Name = name;
        }

        // 10. Method to watch a movie and increase watch count
        public void WatchMovie(Movie movie)
        {
            WatchCount++;
            watchedMovies.Add(movie.Title);

            Console.WriteLine($"{Name} is watching {movie.Title}");
        }

        public void RateMovie(Movie movie, int rate)
        {
            // Prevent rating before watching
            if (!watchedMovies.Contains(movie.Title))
            {
                Console.WriteLine("You must watch the movie before rating it!");
                return;
            }

            // Validate rating input
            if (rate < 1 || rate > 10)
            {
                Console.WriteLine("Invalid rate! Must be between 1 and 10.");
                return;
            }

            movie.Rating = rate;
            Console.WriteLine($"{Name} rated {movie.Title} = {rate}");
        }

        // Print all watched movies
        public void PrintWatchedMovies()
        {
            Console.WriteLine($"{Name}'s watched movies:");
            foreach (var movie in watchedMovies)
            {
                Console.WriteLine("- " + movie);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Movie m1 = new Movie("Inception", "Sci-Fi", 9);
            User u1 = new User("Ali");

            u1.WatchMovie(m1);
            u1.RateMovie(m1, 10);

            u1.PrintWatchedMovies();
        }
    }
}