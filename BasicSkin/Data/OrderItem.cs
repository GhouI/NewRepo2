using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicSkin.Data
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderItemId { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
