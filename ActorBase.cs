namespace Dream;

public abstract class Actor
{
    public string Name { get; private set; }
    public int MaxHP { get; private set; }
    public int CurrentHP { get; set; } // Allow modification outside the class
    public int MaxMana { get; private set; }
    public int CurrentMana { get; set; } // Allow modification outside the class
    public int Level { get; private set; }
    public int Damage { get; private set; }
    public int Armor { get; private set; }
    public int Luck { get; private set; }

    public Actor(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck)
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
    public virtual void TakeDamage(int dmg){
    }
    
	
	// Simple check if Actor is alive
	public bool IsAlive()
    {
		if(CurrentHP > 0)
        {
			return true;
		} 
        else 
        {
			return false;
		}
	}
}
//Lägg till attackmetod.
//Attackm metod i player och monster.