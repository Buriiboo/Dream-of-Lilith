namespace Dream;
using System.Collections.Generic;

public class Monster : Character
{
    public string MonsterType { get; set; }    
    public int Exp { get; set; }
    public int LootRarity { get; set; }
    public Monster(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck, string monsterType, int exp, int lootRarity)
        : base(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck)
    {
        MonsterType = monsterType;
        LootRarity = lootRarity;
        Exp = exp;
    }    
}

public class UndeadList
{
    public List<Monster> Monsters { get; }
    public UndeadList()
    {
        Monsters = new List<Monster>
        {
            new Monster("Zombie", 100, 100, 20, 20, 1, 10, 5, 3, "Undead", 50, 2),
            new Monster("Skeleton", 150, 150, 20, 20, 2, 15, 8, 5, "Undead", 75, 3),
            new Monster("Ghost", 200, 200, 20, 20, 3, 20, 10, 8, "Undead", 100, 4)
        };
    }
    public Monster GetRandomUndead()    
    {
        Random random = new Random();
        int index = random.Next(Monsters.Count);
        return Monsters[index];
    }
}

