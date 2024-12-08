using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CodeZoneTest.Models.StoreViewModels;

public class AddStoreViewModel
{
    [MinLength(3 ,ErrorMessage ="Store Minimum Length is 3 Characters")]
    [Required]
    public string Name { get; set; }
}