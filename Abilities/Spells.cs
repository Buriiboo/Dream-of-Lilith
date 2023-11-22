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
            // Apply additional Fireball-specific logic
            currentEnemy.CurrentHP -= Power;
        }
        else
        {
            Console.WriteLine("You don't have enough mana to use this ability!");
        }
    }
}