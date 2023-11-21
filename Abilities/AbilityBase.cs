namespace Dream;

public abstract class Ability
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Power {get; set;}
    public int ManaCost {get; set;}
   
    public Ability(string name, string description, int power, int manaCost)
    {
        Name = name;
        Description = description;
        Power = power;
        ManaCost = manaCost;
    }
  
    public virtual void UseAbility(Character player, Character target);
    {
        if (player.CurrentMana >= ManaCost)
        {
            player.CurrentMana -= ManaCost;
            target.CurrentHP -= Power;
        }
        else
        {
            Console.WriteLine("You don't have enough mana to use this ability!");
        }
    }
}