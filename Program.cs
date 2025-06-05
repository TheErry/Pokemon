namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myTeam = new List<Pokemons>
            {
                new Charmander(10),
                new Squirtle(9),
                new Bulbasaur(8),
                new Pikachu(11)
            };

            Console.WriteLine("Your team:");
            foreach (var p in myTeam) 
            {
                Console.WriteLine($"{p.Name} (Level: {p.Level}, Type: {p.Type})");
            }

            Console.WriteLine("It's time for a training session!");

            foreach (var p in myTeam) 
            {
                Console.WriteLine($"{p.Name}'s turn!");
                p.Attack();
                //p.RandomAttack();

                p.RaiseLevel();

                if (p is IEvolvalbe evolvalbe)
                {
                    evolvalbe.Evolve();
                }

                Console.WriteLine();
            }
            Console.WriteLine("All pokemon trained!");
        }
    }
}
