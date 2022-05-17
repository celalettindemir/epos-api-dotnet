using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ButtonWidth { get; set; }
        public List<ProductDTO> products { get; set; }

        public virtual List<int> MealsID { get; set; }
    }
}
