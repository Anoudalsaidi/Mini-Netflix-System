
            using System;
            using System.Collections.Generic;

namespace MiniNetflix
    {
        // ===================== Movie Class =====================
        class Movie
        {
            public string Title { get; set; }
            public string Genre { get; set; }

            private int rating;
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

            public Movie(string title, string genre, int rating)
            {
                Title = title;
                Genre = genre;
                Rating = rating; // > uses validation
            }
        }
    }

// ================= WatchSession Class =====================
class WatchSession
{
    public string UserName { get; set; }
    public string MovieTitle { get; set; }

    public WatchSession(string userName, string movieTitle)
    {
        UserName = userName;
        MovieTitle = movieTitle;
    }
}
// =================== User Class =====================
class User
{
    public string Name { get; set; }

    public int WatchCount { get; private set; } = 0;

    private List<string> watchedMovies = new List<string>();

    public User(string name)
    {
        Name = name;
    }

    public void WatchMovie(Movie movie)
    {
        WatchCount++;
        watchedMovies.Add(movie.Title);

        Console.WriteLine($"{Name} is watching {movie.Title}");
    }

    public void RateMovie(Movie movie, int rate)
    {
        // prevent rating before watching
        if (!watchedMovies.Contains(movie.Title))
        {
            Console.WriteLine("You must watch the movie before rating it!");
            return;
        }

        if (rate < 1 || rate > 10)
        {
            Console.WriteLine("Invalid rate! Must be between 1 and 10.");
            return;
        }

        movie.Rating = rate;
        Console.WriteLine($"{Name} rated {movie.Title} = {rate}");
    }

    // print watched movies
    public void PrintWatchedMovies()
    {
        Console.WriteLine($"{Name}'s watched movies:");
        foreach (var movie in watchedMovies)
        {
            Console.WriteLine("- " + movie);
        }
    }
}

// ===================== Main =====================
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
