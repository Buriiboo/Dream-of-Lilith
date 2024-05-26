namespace Dream
{
    public abstract class Actor
    {
        public string Name { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; set; }
        public int MaxMana { get; private set; }
        public int CurrentMana { get; set; }
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

        public abstract void Attack(Actor target);

        public virtual void TakeDamage(int damage)
        {
            // Calculate the actual damage considering the Armor
            int actualDamage = damage - Armor;
            if (actualDamage < 0) actualDamage = 0; // Ensure no negative damage

            CurrentHP -= actualDamage;
            if (CurrentHP < 0) CurrentHP = 0; // Ensure HP doesn't go below 0
            Console.WriteLine($"{Name} takes {actualDamage} damage. Current HP: {CurrentHP}/{MaxHP}");
        }

        // Check if Actor is alive
        public bool IsAlive()
        {
            return CurrentHP > 0;
        }
    }
}
