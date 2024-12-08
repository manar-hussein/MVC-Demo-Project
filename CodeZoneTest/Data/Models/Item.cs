namespace CodeZoneTest.Data.Models;
public class Item:BaseModel
{
    public string Name { get; set; } 
    public ICollection<Store>? Stores { get; set; }
}