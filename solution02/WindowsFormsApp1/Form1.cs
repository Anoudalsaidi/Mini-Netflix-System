using System;
using System.Windows.Forms;
using MiniNetflix;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        User user;
        Movie currentMovie;
        WatchSession session;

        public Form1()
        {
            InitializeComponent();
        }

        // WATCH BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox4.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (user == null)
                user = new User(textBox1.Text);

            currentMovie = new Movie(
                textBox2.Text,   // Title
                textBox4.Text,   // Genre
                0                // default rating
            );

            session = user.WatchMovie(currentMovie);

            listBox1.Items.Add($"{session.UserName} is watching {session.MovieTitle}");
        }

        // RATE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentMovie == null)
            {
                MessageBox.Show("Watch a movie first!");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int rate))
            {
                MessageBox.Show("Invalid rating!");
                return;
            }

            if (!user.HasWatched(currentMovie.Title))
            {
                MessageBox.Show("You must watch the movie first!");
                return;
            }

            if (rate < 1 || rate > 10)
            {
                MessageBox.Show("Rate must be between 1 and 10!");
                return;
            }

            user.RateMovie(currentMovie, rate);

            listBox1.Items.Add($"{user.Name} rated {currentMovie.Title} = {rate}");
        }

        // BONUS: Show watched movies
        private void ShowWatchedMovies()
        {
            listBox1.Items.Add("----- Watched Movies -----");

            foreach (var movie in user.GetWatchedMovies())
            {
                listBox1.Items.Add(movie);
            }

            listBox1.Items.Add("--------------------------");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }
    }
}