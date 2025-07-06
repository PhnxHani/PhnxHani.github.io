namespace LoadoutGenerator.Models
{
    public class Loadout
    {
        public LoadoutItem? Primary { get; set; } = new();
        public LoadoutItem? Secondary { get; set; } = new();
        public List<LoadoutItem>? Tools { get; set; } = new();
        public List<LoadoutItem>? Consumables { get; set; } = new();
        
    }
 }