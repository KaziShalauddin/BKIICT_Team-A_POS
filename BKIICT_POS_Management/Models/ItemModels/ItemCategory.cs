using System.Collections.Generic;
using BKIICT_POS_Management.Models.Item;

namespace BKIICT_POS_Management.Models.ItemModels
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public int RootId { get; set; }
        public int ChildId { get; set; }

        //public int OutletId { get; set; }
        //public Outlet Outlet { get; set; }

        //public int OrganizationId { get; set; }
        //public Organization Organization { get; set; }

        public List<ProductItem> ProductItems { get; set; }
    }
}
