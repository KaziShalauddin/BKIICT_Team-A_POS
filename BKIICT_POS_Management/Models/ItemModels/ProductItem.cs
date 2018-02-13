using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKIICT_POS_Management.Models.ItemModels;

namespace BKIICT_POS_Management.Models.Item
{
   public  class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }


    }
}
