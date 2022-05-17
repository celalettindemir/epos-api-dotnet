using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class CategoryProductsViewDTO
    {
        public string Name { get; set; }
        public List<ProductsViewDTO> Products { get; set; }
    }
    public class ProductsViewDTO
    {
        public string ProductName { get; set; }
        public string Price { get; set; }
    }
}
