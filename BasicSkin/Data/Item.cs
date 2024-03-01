using BasicSkin.Data.Flags;
using System.ComponentModel.DataAnnotations;

namespace BasicSkin.Data
{
    public class Item 
    {
        [Key]
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ImageURL { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<string> Categories { get; set; }
    }
}
