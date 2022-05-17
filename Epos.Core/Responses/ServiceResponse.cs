using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Core.Responses
{
    public class ServiceResponse<T>
    {
        public bool status { get; set; } = false;
        public string message { get; set; } = "";
        public T data { get; set; }
    }
}
            