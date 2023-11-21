namespace Dream;
using System.Collections.Generic;

public class Monster : Character
{
    public string MonsterType { get; set; }    
    public int ExperiencePoints { get; set; }
    public int LootRarity { get; set; }
    public Monster(string name, int maxHP, int currentHP, int level, double damage, int armor, int luck)
        : base(name, maxHP, currentHP, level, damage, armor, luck)
    {
        MonsterType = "";
        LootRarity = 0;
        
        
        ExperiencePoints = 0;
    }    
}

public class UndeadList
{
    public List<Monster> Monsters { get; }
    public UndeadList()
    {
        Monsters = new List<Monster>
        {
            new Monster("Undead Monster", 100, 100, 10.0, 5, 3)
            {
                MonsterType = "Undead",
                LootRarity = 2,
                SpecialAbilities = new List<string>() { "Drain Life", "Summon Skeletons" },
                DropItems = new List<string>() { "Health Potion", "Gold Coin" },
                ExperiencePoints = 50
            }
        };
    }
}
