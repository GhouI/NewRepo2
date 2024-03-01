using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicSkin.Data
{
    public class Order
    {
        [Key] public Guid OrderId { get; set; }
        [ForeignKey("User")]
        public string UserId; 
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Currency)] public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } //completed or processing.

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }  

    }
}
