namespace MiniNetflix
{
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
            }
        }

        public Movie(string title, string genre, int rating)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
        }
    }
}