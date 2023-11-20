public class Item
{
    public string Name {get; set;}
    public int Value {get; set;}
    public int Rarity {get; set;}
    public Item(string name, int value, int rarity)
    {
        Name = name;
        Value = value;
        Rarity = rarity;
    }
}
public class Consumable : Item
{
    public int HealthRestore {get; set;}
    public int ManaRestore {get; set;}
    public Consumable(string name, int value, int rarity, int healthRestore, int manaRestore)
        : base(name, value, rarity)
    {
        HealthRestore = healthRestore;
        ManaRestore = manaRestore;
    }
}