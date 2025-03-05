// <copyright file="Frostbolt.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Abilities
{
    using Dream.Logic;
    using Dream.Models;

    public class Frostbolt : Ability
    {
        public Frostbolt()
            : base("Frostbolt", "A sharp icy shard to pierce your enemies.", 60, 50)
        {
        }

        public override void UseAbility(Player player, Monster currentEnemy)
        {
            if (player.CurrentMana >= this.ManaCost)
            {
                player.CurrentMana -= this.ManaCost;
                Console.WriteLine($"You cast {this.Name}!!");
                this.TriggerMulticast(player, currentEnemy);
            }
            else
            {
                Console.WriteLine("You don't have enough mana to use this ability!");
            }
        }

        private void TriggerMulticast(Player player, Monster currentEnemy)
        {
            MulticastLogic multicastLogic = new MulticastLogic();
            int multicastLevel = multicastLogic.RollMulticastLevel(player);
            Console.WriteLine($"Multicast Level: {multicastLevel}");

            switch (multicastLevel)
            {
                case 0:
                    Console.WriteLine($"You cast a normal frostbolt and deal {this.Power * player.Damage} damage!");
                    currentEnemy.CurrentHP -= this.Power * player.Damage;
                    break;
                case 2:
                    Console.WriteLine($"Multicast level 2!! You deal {this.Power * player.Damage * 2} damage!");
                    currentEnemy.CurrentHP -= this.Power * player.Damage * 2;
                    break;
                case 3:
                    Console.WriteLine($"Multicast level 3!! You deal {this.Power * player.Damage * 3} damage!");
                    currentEnemy.CurrentHP -= this.Power * player.Damage * 3;
                    break;
                case 4:
                    Console.WriteLine($"Multicast level 4!! You deal {this.Power * player.Damage * 4} damage!");
                    currentEnemy.CurrentHP -= this.Power * player.Damage * 4;
                    break;
                default:
                    Console.WriteLine($"Your magic implodes and you deal {this.Power * player.Damage / 2} damage to yourself...");
                    player.CurrentHP -= this.Power * player.Damage / 2;
                    break;
            }
        }
    }
}
