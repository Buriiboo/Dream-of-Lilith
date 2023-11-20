public class Spell
{
    public string Name {get; set;}
    public int ManaCost {get; set;}
    public double Damage {get; set;}
    public Spell(string name, int manaCost, double damage)
    {
        Name = name;
        ManaCost = manaCost;
        Damage = damage;
    }
}