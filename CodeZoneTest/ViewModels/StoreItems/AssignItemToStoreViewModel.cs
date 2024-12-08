using System.ComponentModel.DataAnnotations;

namespace CodeZoneTest.ViewModels.StoreItems
{
    public class AssignItemToStoreViewModel
    {
        public string StoreId { get; set; }
        public string ItemId { get; set; }
        public int ItemQuantity { get; set; }
    }
}
