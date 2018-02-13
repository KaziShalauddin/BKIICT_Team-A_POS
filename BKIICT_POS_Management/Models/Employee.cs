using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKIICT_POS_Management.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(8)]
        public string Code { get; set; }

        //public string Outlet { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }

        public byte[] Img { get; set; }
        [StringLength(12)]
        public string ContactNo { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        //public string? Reference { get; set; }
        [StringLength(12)]
        public string EmergencyContactNo { get; set; }
        [StringLength(50)]
        public string NID { get; set; }
        [StringLength(100)]
        public string FathersName { get; set; }
        [StringLength(100)]
        public string MothersName { get; set; }
        [StringLength(100)]
        public string PresentAddress { get; set; }
        [StringLength(100)]
        public string PermanentAddress { get; set; }

        public int? OutletId { get; set; }
        public Outlet Outlet { get; set; }

        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }


    }
}
