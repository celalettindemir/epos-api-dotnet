using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class CategoryMeal:BaseEntity
    {
        public virtual Category Category { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
