namespace Dream;

public abstract class Character
{
    public string Name {get; set;}
    public int MaxHP {get; set;}
    public int CurrentHP {get; set;}
    public double Damage {get; set;}
    public int Armor   {get; set;}
    public int Luck {get; set;}
    public Character(string name, int maxHP, int currentHP, double damage, int armor, int luck)
    {
        Name = name;
        MaxHP = maxHP;
        CurrentHP = currentHP;
        Damage = damage;
        Armor = armor;
        Luck = luck;
    }
}
