using System;
using System.Collections.Generic;
using Dream.Abilities;

namespace Dream.Models
{
    public class Player : Actor
    {
        int Exp { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Ability> Abilities { get; set; }

        public Player(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck, int exp, List<Item> inventory, List<Ability> abilities)
            : base(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck)
        {
            Exp = exp;
            Inventory = inventory ?? new List<Item>();
            Abilities = abilities ?? new List<Ability>();
        }

        public override void Attack(Actor target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
            target.TakeDamage(Damage);
        }

        public static Player CharacterCreation()
        {
            Console.WriteLine("What is your name, traveler?");
            string name = Console.ReadLine() ?? "Unknown Hero";
            int maxHP = 500;
            int currentHP = 500;
            int maxMana = 100;
            int currentMana = 100;
            int level = 1;
            int damage = 10;
            int armor = 5;
            int luck = 30;
            int exp = 0;
            List<Item> inventory = new List<Item>();
            List<Ability> abilities = new List<Ability> { new Fireball(), new Frostbolt() };
            Console.WriteLine($"Number of abilities: {abilities.Count}");

            return new Player(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck, exp, inventory, abilities);
        }
    }
}
