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
        private ManageComputer mcomputer = new ManageComputer();

        [HttpGet]
        public string Test()
        {
            return "API Is Running ...";
        }

        [HttpPost]
        public async Task<DataResult> Upload(string id = "1_0")
        {
            return await computer.HandleUpload(Request,id);
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

        [HttpGet]
        public void Cdn(string id, string ver = "1")
        {
            dcomputer.Cdn(id, ver);
        }

        [HttpGet]
        public DataResult<List<OceanFile>> List(string fileName, int page =1 ,int limit=20)
        {
            try
            {
                var result = mcomputer.List(fileName, page, limit);
                return new DataResult<List<OceanFile>> { Code = 200, Data = result };
            }
            catch (Exception ex)
            {
                return new DataResult<List<OceanFile>> { Code = 500, Data = new List<OceanFile>(),Message = ex.Message };
            }
        }

        [HttpGet]
        public DataResult<SatasticData> GetSatastic()
        {
            try
            {
                var result = mcomputer.GetSatastic ();
                return new DataResult<SatasticData> { Code = 200, Data = result };
            }
            catch (Exception ex)
            {
                return new DataResult<SatasticData> { Code = 500, Data = new SatasticData(), Message = ex.Message };
            }
        }

    }
}
