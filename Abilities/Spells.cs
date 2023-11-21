using Dream;

public class Fireball : Ability
{
    public Fireball()
    {
        Name = "Fireball";
        ManaCost = 20;
        Power = 50;
    }

    public override void UseAbility(Character player, Character target)
    {
        // Using parts of the base class method
        if (player.CurrentMana >= ManaCost)
        {
            // Deduct mana cost
            base.UseAbility(player, target);

            Console.WriteLine($"You throw a {Name}!");
            // Apply additional Fireball-specific logic
            target.CurrentHP -= Power;
        }
        else
        {
            Console.WriteLine("You don't have enough mana to use this ability!");
        }
    }
}