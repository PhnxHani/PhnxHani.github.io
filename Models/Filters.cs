namespace LoadoutGenerator.Models
{
    public class Filters
    {
        public int MaxWeaponSlots { get; set; } = 4;
        public HashSet<string> ExcludedWeapons { get; set; } = new();
    }
}