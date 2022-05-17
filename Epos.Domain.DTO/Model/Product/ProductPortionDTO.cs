using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.DTO.Model
{
    public class ProductPortionDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int MealId { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public int PositionId { get; set; }
        public string Color { get; set; }
    }
}
