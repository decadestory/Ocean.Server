using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ocean.Server.Models;
using Orm.Son.Core;

namespace Ocean.Server.DataCore
{
    public class OceanFileData
    {
        public int AddFile(OceanFile file)
        {
            using (var db = new OsConn())
            {
                var result = db.Insert(file);
                return result;
            }
        }

        public OceanFile GetFileById(int fileId)
        {
            using (var db = new OsConn())
            {
                var file = db.Find<OceanFile>(fileId);
                return file;
            }
        }
    }
}