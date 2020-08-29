using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ApiRuleta.Core.Models
{
    public class Response
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public object Payload { get; set; }
    }
}
