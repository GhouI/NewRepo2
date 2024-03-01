using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicSkin.Data
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
