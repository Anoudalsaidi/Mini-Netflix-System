namespace MiniNetflix
{
    class WatchSession
    {
        public string UserName { get; }
        public string MovieTitle { get; }

        public WatchSession(string userName, string movieTitle)
        {
            UserName = userName;
            MovieTitle = movieTitle;
        }
    }
}