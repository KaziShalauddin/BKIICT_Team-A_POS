using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKIICT_POS_Management.Models
{
   public class Party
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(8)]
        public string Code { get; set; }

        [StringLength(12)]
        public string ContactNo { get; set; }
        [StringLength(150)]
        public string Email { get; set; }

        public byte[] Img { get; set; }
        [StringLength(100)]
        public string Address { get; set; }

        public bool Customer { get; set; }
        public bool Supplier { get; set; }

        public bool IsDeleted { get; set; }

        public int? OutletId { get; set; }
        public Outlet Outlet { get; set; }

        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
