// <copyright file="Fireball.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Abilities
{
    using Dream.Logic;
    using Dream.Models;

    public class Fireball : Ability
    {
        public Fireball()
            : base("Fireball", "A ball of fire that burns your enemy.", 20, 50)
        {
        }

        public override void UseAbility(Player Player, Monster currentEnemy)
        {
            if (Player.CurrentMana >= this.ManaCost)
            {
                Player.CurrentMana -= this.ManaCost;
                Console.WriteLine($"You cast {this.Name}!!");
                this.TriggerMulticast(Player, currentEnemy);
            }
            else
            {
                Console.WriteLine("You don't have enough mana to use this ability!");
            }
        }

        private void TriggerMulticast(Player Player, Monster currentEnemy)
        {
            MulticastLogic multicastLogic = new MulticastLogic();
            int multicastLevel = multicastLogic.RollMulticastLevel(Player);
            Console.WriteLine($"Multicast Level: {multicastLevel}");

            switch (multicastLevel)
            {
                case 0:
                    Console.WriteLine($"You cast a normal fireball and deal {this.Power * Player.Damage} damage!");
                    currentEnemy.CurrentHP -= this.Power * Player.Damage;
                    break;
                case 2:
                    Console.WriteLine($"Multicast level 2!! You deal {this.Power * Player.Damage * 2} damage!");
                    currentEnemy.CurrentHP -= this.Power * Player.Damage * 2;
                    break;
                case 3:
                    Console.WriteLine($"Multicast level 3!! You deal {this.Power * Player.Damage * 3} damage!");
                    currentEnemy.CurrentHP -= this.Power * Player.Damage * 3;
                    break;
                case 4:
                    Console.WriteLine($"Multicast level 4!! You deal {this.Power * Player.Damage * 4} damage!");
                    currentEnemy.CurrentHP -= this.Power * Player.Damage * 4;
                    break;
                default:
                    Console.WriteLine($"Your magic implodes and you deal {this.Power * Player.Damage / 4} damage to yourself...");
                    Player.CurrentHP -= this.Power * Player.Damage / 4;
                    break;
            }
        }
    }
}
