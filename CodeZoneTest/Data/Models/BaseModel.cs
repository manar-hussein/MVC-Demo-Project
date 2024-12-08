namespace CodeZoneTest.Data.Models;

public class BaseModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public bool IsDeleted { get; set; } = false;
}