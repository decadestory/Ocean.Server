using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Ocean.Server.DataCore;

namespace Ocean.Server.Computer
{
    public class DownLoadComputer
    {
        private OceanFileData data = new OceanFileData();

        public void DownLoad(int fileId)
        {
            var file = data.GetFileById(fileId);

            var filePath = file.FilePath + "/" + file.FileName;
            var fs = new FileStream(filePath, FileMode.Open);
            var bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(file.FileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public void ShowDoc(int fileId)
        {
            var file = data.GetFileById(fileId);

            var filePath = file.FilePath + "/" + file.FileName;
            var fs = new FileStream(filePath, FileMode.Open);
            var bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();

            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + HttpUtility.UrlEncode(file.FileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public void Show(int fileId)
        {
            var file = data.GetFileById(fileId);

            var filePath = file.FilePath + "/" + file.FileName;
            var fs = new FileStream(filePath, FileMode.Open);
            var bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            HttpContext.Current.Response.ContentType = file.ContentType;
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + HttpUtility.UrlEncode(file.FileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public void Cdn(string fileName,string version)
        {
            var file = data.GetFileById(fileName,version);

            var filePath = file.FilePath + "/" + file.FileName;
            var fs = new FileStream(filePath, FileMode.Open);
            var bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            HttpContext.Current.Response.ContentType = file.ContentType;
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + HttpUtility.UrlEncode(file.FileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

    }
}