// <copyright file="Actor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Models
{
    public abstract class Actor

    {
        public Actor(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.CurrentHP = currentHP;
            this.MaxMana = maxMana;
            this.CurrentMana = currentMana;
            this.Level = level;
            this.Damage = damage;
            this.Armor = armor;
            this.Luck = luck;
        }

        public string Name { get; private set; }

        public int MaxHP { get; private set; }

        public int CurrentHP { get; set; }

        public int MaxMana { get; private set; }

        public int CurrentMana { get; set; }

        public int Level { get; private set; }

        public int Damage { get; private set; }

        public int Armor { get; private set; }

        public int Luck { get; private set; }

        public abstract void Attack(Actor target);

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = damage - this.Armor;
            if (actualDamage < 0)
            {
                actualDamage = 0;
            }

            this.CurrentHP -= actualDamage;
            if (this.CurrentHP < 0)
            {
                this.CurrentHP = 0;
            }

            Console.WriteLine($"{this.Name} takes {actualDamage} damage. Current HP: {this.CurrentHP}/{this.MaxHP}");
        }

        public bool IsAlive()
        {
            return this.CurrentHP > 0;
        }
    }
}
