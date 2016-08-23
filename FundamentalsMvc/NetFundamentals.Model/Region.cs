using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFundamentals.Model
{
    [Table("Region")]
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        public int RegionID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
