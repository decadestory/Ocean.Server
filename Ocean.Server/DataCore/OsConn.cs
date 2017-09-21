using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orm.Son.Core;

namespace Ocean.Server.DataCore
{
    public class OsConn:SonConnection
    {
        public OsConn() : base("conn")
        {
        }
    }
}