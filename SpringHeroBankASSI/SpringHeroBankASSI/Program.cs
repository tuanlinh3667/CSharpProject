using SpringHeroBankASSI.entity;
using SpringHeroBankASSI.view;

namespace SpringHeroBankASSI
{
    static class Program
    {
        public static Account CurrentLoggedIn;

        static void Main(string[] args)
        {
            MainView.GenerateMenu();

        }
    }
}