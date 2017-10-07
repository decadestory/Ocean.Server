using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ocean.Server.Models;
using Ocean.Server.DataCore;

namespace Ocean.Server.Computer
{
    public class ManageComputer
    {
        private OceanFileData data = new OceanFileData();

        public List<OceanFile> List(string fileName, int page, int limit)
        {
            return data.List(fileName, page, limit);
        }

        public SatasticData GetSatastic()
        {
            return data.GetSatastic();
        }
    }
}