namespace Dream;

public class Room
{
    public string Description {get; set;}
    public string Name {get; set;}
    public string Exits {get; set;}
    public Room(string description, string name, string exits)
    {
        Description = description;
        Name = name;
        Exits = exits;
    }

}