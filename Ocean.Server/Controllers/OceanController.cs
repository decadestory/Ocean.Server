using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Ocean.Server.Models;
using System.IO;
using Ocean.Server.Computer;

namespace Ocean.Server.Controllers
{
    public class OceanController : ApiController
    {
        private UploadComputer computer = new UploadComputer();

        [HttpGet]
        public string Test()
        {
            return "API Is Running ...";
        }

        [HttpPost]
        public async Task<DataResult>  Upload()
        {
            return await computer.HandleUpload(Request);
        }
    }
}
