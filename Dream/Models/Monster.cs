// <copyright file="Monster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Models
{
    using System;

    public class Monster : Actor
    {
        public Monster(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck)
            : base(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck)
        {
        }

        public override void Attack(Actor target)
        {
            Console.WriteLine($"{this.Name} attacks {target.Name}!");
            target.TakeDamage(this.Damage);
        }
    }
}
