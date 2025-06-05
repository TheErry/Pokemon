using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Attack
    {
        public string Name { get; set; }
        public ElementType Type { get; set; }
        public int BasePower { get; set; }

        public Attack(string name, ElementType type, int basePower)
        {
            Name = name;
            Type = type;
            BasePower = basePower;
        }
        public void Use(int level)
        {
            int totalPower = BasePower + level;
            Console.WriteLine($"{Name} hits with total power {totalPower}!");
        }
    }
}
