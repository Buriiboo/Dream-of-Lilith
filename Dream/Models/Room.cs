namespace Dream.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnemyDescription { get; set; }

        public Room(string name, string description, string enemyDescription)
        {
            Name = name;
            Description = description;
            EnemyDescription = enemyDescription;
        }
    }
}
