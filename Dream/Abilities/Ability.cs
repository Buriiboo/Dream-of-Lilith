// <copyright file="Ability.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Abilities
{
    using Dream.Models;

    public abstract class Ability
    {
        public Ability(string name, string description, int power, int manaCost)
        {
            this.Name = name;
            this.Description = description;
            this.Power = power;
            this.ManaCost = manaCost;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Power { get; set; }

        public int ManaCost { get; set; }

        public virtual void UseAbility(Player player, Monster currentEnemy)
        {
            if (player.CurrentMana >= this.ManaCost)
            {
                player.CurrentMana -= this.ManaCost;
                currentEnemy.CurrentHP -= this.Power;
                Console.WriteLine($"{player.Name} uses {this.Name} on {currentEnemy.Name} for {this.Power} damage.");
            }
            else
            {
                Console.WriteLine("You don't have enough mana to use this ability!");
            }
        }
    }
}
