using System.ComponentModel.DataAnnotations;

namespace CodeZoneTest.Models.StoreViewModels;

public class GetStoreViewModel
{
    [Required]
    [MinLength(3, ErrorMessage = "Store Minimum Length is 3 Characters")]
    public string Name { get; set; }
    public string Id { get; set; }
}