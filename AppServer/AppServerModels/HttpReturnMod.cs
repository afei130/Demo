using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.Models
{
    public class HttpReturnMod
    {
        public HttpReturnMod()
        {
            Code = 0;
            Msg = "未知错误";
            Dic = new Dictionary<string, string>();
        }
        public int Code { get; set; }
        public string Msg { get; set; }
        public Dictionary<string,string> Dic { get; set; }
        public string ToUrl { get; set; }
    }
}
