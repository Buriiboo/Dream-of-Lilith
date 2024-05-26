using System;
using Dream.Models;
using Dream.Abilities;

namespace Dream.Logic
{
    public class BattleLogic
    {
        private Monster currentEnemy;

        public void StartBattle(Player player, Monster enemy)
        {
            currentEnemy = enemy;
            Console.WriteLine($"You encounter a {currentEnemy.Name}!");

            while (player.CurrentHP > 0 && currentEnemy.CurrentHP > 0)
            {
                Console.WriteLine($"{player.Name}'s HP: {player.CurrentHP}/{player.MaxHP} | {currentEnemy.Name}'s HP: {currentEnemy.CurrentHP}/{currentEnemy.MaxHP}");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Ability");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.Attack(currentEnemy);
                        break;
                    case "2":
                        UseAbility(player, currentEnemy);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                if (currentEnemy.IsAlive())
                {
                    currentEnemy.Attack(player);
                }
            }

            if (player.CurrentHP <= 0)
            {
                Console.WriteLine("You were defeated!");
            }
            else
            {
                Console.WriteLine($"You defeated the {currentEnemy.Name}!");
            }
        }

        private void UseAbility(Player player, Monster enemy)
        {
            Console.WriteLine("Choose an ability:");
            for (int i = 0; i < player.Abilities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Abilities[i].Name}");
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
