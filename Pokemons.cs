using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public abstract class Pokemons
    {
        private string name;
        private int level;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 2 || value.Length > 15)
                    throw new ArgumentException("The name must be between 2 and 15 characters");
                name = value;
            }
        }

        public int Level
        {
            get => level;
            set
            {
                if (value < 1)
                    throw new ArgumentException("The level must be at least 1");
                level = value;
            }
        }

        public ElementType Type { get; set; }
        public List<Attack> Attacks { get; set; }

        public Pokemons(string name, int level, ElementType type, List<Attack> attacks) 
        { 
            Name = name;
            Level = level;
            Type = type;
            Attacks = attacks ?? throw new ArgumentNullException(nameof(attacks));
        }
        public void RandomAttack()
        {
            var random = new Random();
            int index = random.Next(Attacks.Count);
            Attack selectedAttack = Attacks[index];

            selectedAttack.Use(Level);
        }

        public void Attack()
        {
            Console.WriteLine($"Which attack should {Name} use?");
            for (int i = 0; i < Attacks.Count; i++) 
            {
                Console.WriteLine($"{i + 1}. {Attacks[i].Name} (Power: {Attacks[i].BasePower})");
            }

            Console.Write("Choose attack: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= Attacks.Count)
            {
                Attack selected = Attacks[choice - 1];
                selected.Use(Level);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        public void RaiseLevel()
        {
            Level++;
            Console.WriteLine($"{Name} leveled up! New level: {Level}");
        }

    }

    public class FirePokemon : Pokemons
    {
        public FirePokemon(string name, int level, List<Attack> attacks) : base(name, level, ElementType.Fire, attacks)
        {
        }
    }
    public class GrassPokemon : Pokemons
    {
        public GrassPokemon(string name, int level, List<Attack> attacks) : base(name, level, ElementType.Grass, attacks)
        {
        }
    }
    public class WaterPokemon : Pokemons
    {
        public WaterPokemon(string name, int level, List<Attack> attacks) : base(name, level, ElementType.Water, attacks)
        {
        }
    }

    public class ElectricPokemon : Pokemons
    {
        public ElectricPokemon(string name, int level, List<Attack> attacks) : base(name, level, ElementType.Electric, attacks)
        {
        }
    }

    public class Charmander: FirePokemon
    {
        public Charmander(int level) : base("Charmander", level, new List<Attack>
        {
            new Attack("Scratch", ElementType.Normal, 5),
            new Attack("Ember", ElementType.Fire, 10),
            new Attack("Growl", ElementType.Normal, 1),
            new Attack("Flamethrower", ElementType.Fire, 20)
        })
        {
        }

        public void Evolve()
        {
            string oldName = Name;
            Name = "Charmeleon";
            Level += 10;
            Console.WriteLine($"{oldName} is evolving... {oldName} evolved into {Name}! New level: {Level}");
        }
    }

    public class Squirtle : WaterPokemon
    {
        public Squirtle(int level) : base("Squirtle", level, new List<Attack>
        {
            new Attack("Tackle", ElementType.Normal, 6),
            new Attack("Tail Whip", ElementType.Normal, 1),
            new Attack("Water gun", ElementType.Water, 12),
            new Attack("Bubble", ElementType.Water, 8)
        })
        {
        }
    }

    public class Bulbasaur : GrassPokemon
    {
        public Bulbasaur(int level) : base("Bulbasaur", level, new List<Attack>
        {
            new Attack("Tackle", ElementType.Normal, 6),
            new Attack("Growl", ElementType.Normal, 1),
            new Attack("Vine Whip", ElementType.Grass, 12),
            new Attack("Leech seed", ElementType.Grass, 5),
        })
        {
        }
    }

    public class Pikachu : ElectricPokemon
    {
        public Pikachu(int level) : base("Pikachu", level, new List<Attack>
        {
            new Attack("Quick Attack", ElementType.Normal, 8),
            new Attack("Thunder Shock", ElementType.Electric, 12),
            new Attack("Growl", ElementType.Normal, 1),
            new Attack("Thunderbolt", ElementType.Electric, 25),
        })
        {
        }
    }
}
