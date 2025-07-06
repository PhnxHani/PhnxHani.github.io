using System.Net.Http.Json;
using System.Text.Json;
using LoadoutGenerator.Models;

public class InventoryService
{
    private List<LoadoutItem> _allLoadoutItems = new();
    private readonly HttpClient _http;

    public InventoryService(HttpClient http)
    {
        _http = http;
    }
    public async Task LoadInvetoryAsync()
    {
        _allLoadoutItems = await _http.GetFromJsonAsync<List<LoadoutItem>>("data/Items.json") ?? new List<LoadoutItem>();
    }
    public List<LoadoutItem> GetByCategory(string category)
    {
        return _allLoadoutItems.Where(i => i.Category == category).ToList();
    }
    public List<string> GetAllTags() =>
        _allLoadoutItems.SelectMany(x => x.Tags).Distinct().ToList();
}
