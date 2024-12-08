using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CodeZoneTest.Data.Models;
public class StoreItems:BaseModel
{
    [ForeignKey(nameof(Store))]
    public string StoreId { get; set; }
    public Store? Store { get; set; }
    [ForeignKey(nameof(Item))]
    public string ItemId { get; set; }
    public Item? Item { get; set; }
    public int ItemQuantity { get; set; }
}