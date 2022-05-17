using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Domain.Entity
{
    public class OptionItem : BaseEntity
    {
        public virtual String Name { get; set; }
        public virtual Double Price { get; set; }
        public virtual Double LPrice { get; set; }
        public virtual Double EPrice { get; set; }
        public virtual Option Option { get; set; }
    }
}
/*
 * 
        //0 Secili Degil
        //1 Secili
        //2 Little
        //3 Extra

        public int Selected { get; set; }
*/