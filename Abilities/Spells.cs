using Dream;

public class Fireball : Ability
{
    public Fireball()
        : base("Fireball", "A ball of fire that burns your enemy.", 20, 50)
    {
    }

    public override void UseAbility(Player player, Monster currentEnemy)
    {
        // Check for null before accessing properties or methods
        if (player != null && currentEnemy != null)
        {
            // Deduct mana cost
            player.CurrentMana -= ManaCost;

            Console.WriteLine($"You cast {Name}!!");
            // Apply additional Fireball-specific logic here
            TriggerMulticast(player, currentEnemy);
        }
        else
        {
            Console.WriteLine("You don't have enough mana to use this ability!");
        }
    }

        public void TriggerMulticast(Player player, Monster currentEnemy)
        {
            MulticastLogic multicastLogic = new MulticastLogic();
            int multicastLevel = multicastLogic.RollMulticastLevel(player);
            Console.WriteLine($"Multicast Level: {multicastLevel}");

            // Add additional effects based on multicastLevel
            switch (multicastLevel)
            {
                case 0:
                    Console.WriteLine($"You cast a normal fireboll and deal {Power * player.Damage} damage!");
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
                    Console.WriteLine($"Your magic implodes and you deal {Power * player.Damage / 2} damage to yourself...");
                    player.CurrentHP -= Power * player.Damage / 2;
                    break;
            }
        }
}
public class Frostbolt : Ability
{
    public Frostbolt()
        : base("Frostbolt", "A sharp icy shard to pierce your enemies.", 60, 50)
    {
    }

    public override void UseAbility(Player player, Monster currentEnemy)
    {
        // Check for null before accessing properties or methods
        if (player != null && currentEnemy != null)
        {
            // Deduct mana cost
            player.CurrentMana -= ManaCost;

            Console.WriteLine($"You cast {Name}!!");
            // Apply additional Fireball-specific logic here
            TriggerMulticast(player, currentEnemy);
        }
        else
        {
            Console.WriteLine("You don't have enough mana to use this ability!");
        }
    }

        public void TriggerMulticast(Player player, Monster currentEnemy)
        {
            MulticastLogic multicastLogic = new MulticastLogic();
            int multicastLevel = multicastLogic.RollMulticastLevel(player);
            Console.WriteLine($"Multicast Level: {multicastLevel}");

            // Add additional effects based on multicastLevel
            switch (multicastLevel)
            {
                case 0:
                    Console.WriteLine($"You cast a normal frostbolt and deal {Power * player.Damage} damage!");
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
                    Console.WriteLine($"Your magic implodes and you deal {Power * player.Damage / 2} damage to yourself...");
                    player.CurrentHP -= Power * player.Damage / 2;
                    break;
            }
        }

}



//---------------------------------------------------------------------------------------------
public class MulticastLogic
    {
        public int RollMulticastLevel(Player player)
        {
            // Define the probabilities for each level based on Luck
            int[] probabilities = CalculateProbabilities(player);

            // Roll a random number between 1 and 100
            int roll = new Random().Next(1, 101);

            // Determine the multicast level based on the rolled number and probabilities
            if (roll <= probabilities[0])
                return 0;
            else if (roll <= probabilities[0] + probabilities[1])
                return 2;
            else if (roll <= probabilities[0] + probabilities[1] + probabilities[2])
                return 3;
            else if (roll <= probabilities[0] + probabilities[1] + probabilities[2] + probabilities[3])
                return 4;
            else
                return -1; // Invalid multicast level
        }

    public int[] CalculateProbabilities(Player player)
        {
        
            // Adjust the probabilities based on the Luck stat
            int baseProbability = 25;
            int luckModifier = player.Luck / 10; // Adjust this based on how much Luck affects probabilities

            int[] probabilities = new int[4];
            probabilities[0] = baseProbability;
            probabilities[1] = baseProbability + luckModifier;
            probabilities[2] = baseProbability - luckModifier;
            probabilities[3] = luckModifier;

            // Ensure probabilities are within the valid range (1-100)
            for (int i = 0; i < probabilities.Length; i++)
            {
                probabilities[i] = Math.Max(1, Math.Min(100, probabilities[i]));
            }

            return probabilities;
        }
    }