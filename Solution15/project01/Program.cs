using System.Threading.Channels;

namespace project01
{
    internal class Program
    {
        class books
        {
            public void generalbook()
            {
                Console.WriteLine("This is general book");
            }

            public virtual void storybook()
            {
                Console.WriteLine("This is story book");
            }

            public virtual void normalbook()
            {
                Console.WriteLine("This is normal book");
            }
        }

        class ReadsBook : books
        {
            public override void storybook()
            {
                Console.WriteLine("Reeding is a story books");
            }

            public override void normalbook()
            {
                Console.WriteLine("Writing is a normal books");
            }
        }
        static void Main(string[] args)
        {
           ReadsBook bok = new ReadsBook();
            
           
            bok.storybook();
            bok.normalbook();

        }
    }
}
