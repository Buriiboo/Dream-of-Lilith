using Dream.Models;
using Dream.Logic;

namespace Dream.Abilities
{
    public class Fireball : Ability
    {
        public Fireball()
            : base("Fireball", "A ball of fire that burns your enemy.", 20, 50)
        {
        }

        public override void UseAbility(Player player, Monster currentEnemy)
        {
            if (player.CurrentMana >= ManaCost)
            {
                player.CurrentMana -= ManaCost;
                Console.WriteLine($"You cast {Name}!!");
                TriggerMulticast(player, currentEnemy);
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
                    Console.WriteLine($"You cast a normal fireball and deal {Power * player.Damage} damage!");
                    currentEnemy.CurrentHP -= Power * player.Damage;
                    break;
                case 2:
                    Console.WriteLine($"Multicast level 2!! You deal {Power * player.Damage * 2} damage!");
                    currentEnemy.CurrentHP -= Power * player.Damage * 2;
                    break;
                case 3:
                    Console.WriteLine($"Multicast level 3!! You deal {Power * player.Damage * 3} damage!");
                    currentEnemy.CurrentHP -= Power * player.Damage * 3;
                    break;
                case 4:
                    Console.WriteLine($"Multicast level 4!! You deal {Power * player.Damage * 4} damage!");
                    currentEnemy.CurrentHP -= Power * player.Damage * 4;
                    break;
                default:
                    Console.WriteLine($"Your magic implodes and you deal {Power * player.Damage / 4} damage to yourself...");
                    player.CurrentHP -= Power * player.Damage / 4;
                    break;
            }
        }
    }
}
