using LoadoutGenerator.Models;

public class LoadoutGeneratorService
{
    private readonly InventoryService _inventory;
    private readonly Random _random = new();

    public LoadoutGeneratorService(InventoryService inventory)
    {
        _inventory = inventory;
    }

    public Loadout GenerateLoadout(Filters filter)
    {
        var weapons = GetWeapons(filter);
        var tools = GetTools();
        var consumables = GetConsumables();
        var maxWeaponSlots = filter.MaxWeaponSlots;

        return new Loadout
        {
            Primary = SelectPrimaryWeapon(weapons, out int selectedSize),
            Secondary = SelectSecondaryWeapon(weapons, maxWeaponSlots, selectedSize),
            Tools = SelectTools(tools, 4),
            Consumables = SelectConsumables(consumables, 4)
        };
    }

    private List<LoadoutItem> GetWeapons(Filters filter)
    {
        var allWeapons = _inventory.GetByCategory("Weapon");
        return allWeapons.Where(w => !w.Tags.Any(tag => filter.ExcludedWeapons.Contains(tag))).ToList();
    }
    private List<LoadoutItem> GetTools()
    {
        var allTools = _inventory.GetByCategory("Tool");
        return allTools;
    }
    private List<LoadoutItem> GetConsumables()
    {
        var allConsumables = _inventory.GetByCategory("Consumable");
        return allConsumables;
    }
    private LoadoutItem SelectPrimaryWeapon(List<LoadoutItem> availableWeapons, out int selectedSize)
    {
        LoadoutItem selectedWeapon = availableWeapons[_random.Next(availableWeapons.Count)];
        selectedSize = selectedWeapon.Size;
        return selectedWeapon;
    }
    private LoadoutItem SelectSecondaryWeapon(List<LoadoutItem> availableWeapons, int maxSize, int primarySize)
    {
        availableWeapons = availableWeapons.Where(w => w.Size <= maxSize - primarySize).ToList(); ;
        return availableWeapons[_random.Next(availableWeapons.Count)];
    }
    private List<LoadoutItem> SelectTools(List<LoadoutItem> availableTools, int count)
    {
        return availableTools.OrderBy(t => _random.Next()).Take(count).ToList();
    }
    private List<LoadoutItem> SelectConsumables(List<LoadoutItem> availableConsumables, int count)
    {
        return availableConsumables.OrderBy(t => _random.Next()).Take(count).ToList();
    }
}