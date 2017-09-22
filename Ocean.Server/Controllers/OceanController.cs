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
        private DownLoadComputer dcomputer = new DownLoadComputer();

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

        [HttpGet]
        public void DownLoad(int id)
        {
            dcomputer.DownLoad(id);
        }

        [HttpGet]
        public void ShowDoc(int id)
        {
            dcomputer.ShowDoc(id);
        }

        [HttpGet]
        public void Show(int id)
        {
            dcomputer.Show(id);
        }

    }
}
