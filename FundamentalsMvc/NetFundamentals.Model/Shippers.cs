using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetFundamentals.Model
{
    public partial class Shippers
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int ShipperID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
