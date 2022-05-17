using Epos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class Category : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual double ButtonWidth { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CategoryMeal> CategoryMeals { get; set; }
    }
}
