namespace CodeZoneTest.Models;

public class PaginationViewModel<T>
{
    public int TotalItems  { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int TotalPages  { get; set; }
}