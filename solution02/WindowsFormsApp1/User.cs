using System.Collections.Generic;

namespace MiniNetflix
{
    class User
    {
        public string Name { get; }

        public int WatchCount { get; private set; } = 0;

        private List<string> watchedMovies = new List<string>();

        public User(string name)
        {
            Name = name;
        }

        // Watch Movie
        public WatchSession WatchMovie(Movie movie)
        {
            if (movie == null)
                return null;

            WatchCount++;
            watchedMovies.Add(movie.Title);

            return new WatchSession(Name, movie.Title);
        }

        // Check if watched
        public bool HasWatched(string movieTitle)
        {
            return watchedMovies.Contains(movieTitle);
        }

        // Rate Movie (BONUS)
        public bool RateMovie(Movie movie, int rate)
        {
            if (!HasWatched(movie.Title))
                return false;

            if (rate < 1 || rate > 10)
                return false;

            movie.Rating = rate;
            return true;
        }

        // Bonus: print watched movies
        public List<string> GetWatchedMovies()
        {
            return watchedMovies;
        }
    }
}