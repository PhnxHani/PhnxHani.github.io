using System.Runtime.CompilerServices;
namespace LoadoutGenerator.Models
{
    public class LoadoutItem
    {
        public string Name { get; set; } = "";
        public int Cost { get; set; } = 0;
        public int Size { get; set; } = 0;
        public string Category { get; set; } = "";
        public string? Variant { get; set; }
        public List<string>? Ammo { get; set; }
        public List<string>? SecondaryAmmo  { get; set; }
        public List<string> Tags { get; set; } = new();
        public string? ImagePath { get; set; }
    }
}

