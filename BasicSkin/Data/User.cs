using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BasicSkin.Data
{
    public class User : IdentityUser
    {
        [Key]
        public string UserId { get; set; }
        public string Biography { get; set; }
        public int Balance { get; set; }

        [InverseProperty("User")]
        public virtual Cart Cart { get; set; }

        public virtual ICollection<OrderItem> Inventory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public User()
        {
            Inventory = new List<OrderItem>();
            Orders = new List<Order>();
            Transactions = new List<Transaction>();
            Biography = string.Empty;
            Cart = new Cart();
        }
    }
}
