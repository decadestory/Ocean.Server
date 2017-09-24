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

        public OceanFile GetFileById(string fileName, string version)
        {
            using (var db = new OsConn())
            {
                var file = db.Top<OceanFile>(t => t.OriginName == fileName && t.Version == version, t => t.AddTime, true);
                return file;
            }
        }

        public List<OceanFile> List(string fileName,int page,int limit)
        {
            using (var db = new OsConn())
            {
                var files = !string.IsNullOrWhiteSpace( fileName) 
                    ? db.FindPage<OceanFile>(t=>t.OriginName.Contains(fileName),t=>t.AddTime,page,limit,true)
                    : db.FindPage<OceanFile>(t => t.OriginName != "", t => t.AddTime, page, limit, true);
                return files.Item1;
            }
        }

    }
}