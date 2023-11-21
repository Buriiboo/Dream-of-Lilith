namespace Dream;

public abstract class Character
{
    public string Name {get; set;}
    public int MaxHP {get; set;}
    public int CurrentHP {get; set;}
    public int MaxMana {get; set;}
    public int CurrentMana {get; set;}
    public int Level {get; set;}
    public int Damage {get; set;}
    public int Armor   {get; set;}
    public int Luck {get; set;}
    public Character(string name, int maxHP, int currentHP, int MaxMana, int CurrentMana, int level, int damage, int armor, int luck)
    {
        Name = name;
        MaxHP = maxHP;
        CurrentHP = currentHP;
        MaxMana = maxMana;
        CurrentMana = currentMana;
        Level = level;
        Damage = damage;
        Armor = armor;
        Luck = luck;

    }
}
