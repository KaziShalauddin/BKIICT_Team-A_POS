using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKIICT_POS_Management.Models
{
    public class Outlet
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Code { get; set; }
        [MaxLength(12)]
        public string ContactNo { get; set; }
        public byte[] Logo { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }

        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Party> Parties { get; set; }
    }
}
