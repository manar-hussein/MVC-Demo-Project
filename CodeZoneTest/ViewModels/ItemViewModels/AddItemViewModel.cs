using System.ComponentModel.DataAnnotations;

namespace CodeZoneTest.ViewModels.ItemViewModels
{
    public class AddItemViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Item Name Minimum Length is 3 Characters")]
        public string Name { get; set; }
    }
}
