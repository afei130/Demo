using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StartServer : ControllerBase
    {
        public string Msg { get; set; }
        public StartServer()
        {
            Msg = "启动成功";
        }
        public string Start()
        {
            return Msg;
        }
    }
}
