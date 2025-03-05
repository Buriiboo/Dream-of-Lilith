// <copyright file="BattleLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Logic
{
    using System;
    using Dream.Abilities;
    using Dream.Models;

    public class BattleLogic
    {
        required public Monster CurrentEnemy { get; set; }

        public BattleLogic()
        {
            this.CurrentEnemy = new Monster(string.Empty, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public void StartBattle(Player player, Monster enemy)
        {
            this.CurrentEnemy = enemy;
            Console.WriteLine($"You encounter a {this.CurrentEnemy.Name}!");

            while (player.CurrentHP > 0 && this.CurrentEnemy.CurrentHP > 0)
            {
                Console.WriteLine($"{player.Name}'s HP: {player.CurrentHP}/{player.MaxHP} | {this.CurrentEnemy.Name}'s HP: {this.CurrentEnemy.CurrentHP}/{this.CurrentEnemy.MaxHP}");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Ability");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        player.Attack(this.CurrentEnemy);
                        break;
                    case "2":
                        this.UseAbility(player, this.CurrentEnemy);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                if (this.CurrentEnemy.IsAlive())
                {
                    this.CurrentEnemy.Attack(player);
                }
            }

            if (player.CurrentHP <= 0)
            {
                Console.WriteLine("You were defeated!");
            }
            else
            {
                Console.WriteLine($"You defeated the {this.CurrentEnemy.Name}!");
            }
        }

        private void UseAbility(Player player, Monster enemy)
        {
            Console.WriteLine("Choose an ability:");
            for (int i = 0; i < player.Abilities.Count; i++)
            {
                var ability = player.Abilities[i];
                Console.WriteLine($"{i + 1}. {ability.Name} - {ability.Description} (Damage: {ability.Power}, Mana Cost: {ability.ManaCost})");
            }

            if (int.TryParse(Console.ReadLine(), out int abilityIndex) && abilityIndex > 0 && abilityIndex <= player.Abilities.Count)
            {
                player.Abilities[abilityIndex - 1].UseAbility(player, enemy);
            }
            else
            {
                Console.WriteLine("Invalid choice. No ability used.");
            }
        }
    }
}
