using System;

namespace Dream.Models
{
    public class Monster : Actor
    {
        public Monster(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck)
            : base(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck)
        {
        }

        public override void Attack(Actor target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
            target.TakeDamage(Damage);
        }
    }
}
