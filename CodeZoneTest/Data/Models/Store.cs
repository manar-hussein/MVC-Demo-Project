namespace CodeZoneTest.Data.Models;
public class Store:BaseModel
{
    public string Name { get; set; }
    public ICollection<Item>? Items { get; set; }
}