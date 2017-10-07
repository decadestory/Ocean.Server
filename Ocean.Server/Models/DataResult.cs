using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ocean.Server.Models
{
    public class DataResult
    {
        public int Code { get; set; }
        public List<long> FileIds { get; set; }
        public string Message { get; set; }
    }

    public class DataResult<T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }

}