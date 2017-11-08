using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HPlusSportsAPITwo.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required]
        public decimal? TotalDue { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int SalespersonId { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Salesperson Salesperson { get; set; }
    }
}
