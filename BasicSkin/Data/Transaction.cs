using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicSkin.Data
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public DateTime TransactionDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}
