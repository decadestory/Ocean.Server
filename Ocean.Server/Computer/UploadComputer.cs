using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Ocean.Server.DataCore;
using Ocean.Server.Models;

namespace Ocean.Server.Computer
{
    public class UploadComputer
    {
        public readonly string UploadPath = ConfigurationManager.AppSettings["upload_path"];
        public readonly string UploadPathDir = DateTime.Now.ToString("yyyy-MM-dd-HH");
        private OceanFileData data = new OceanFileData();

        public async Task<DataResult> HandleUpload(HttpRequestMessage request,string version)
        {
            if (!request.Content.IsMimeMultipartContent("form-data"))
                return new DataResult { Code = 500, FileIds = new List<long>(), Message = "Not MimeMultipart Content" };

            try
            {
                var curFileDir = UploadPath + "\\" + UploadPathDir;
                if (!Directory.Exists(UploadPath)) Directory.CreateDirectory(UploadPath);
                if (!Directory.Exists(curFileDir)) Directory.CreateDirectory(curFileDir);
                // 设置上传目录
                var provider = new MultipartFormDataStreamProvider(UploadPath);
                // 接收数据，并保存文件
                await request.Content.ReadAsMultipartAsync(provider);

                var srcIp = GetClientIp();
                var fileIds = new List<long>();
                foreach (var fileData in provider.FileData)
                {
                    if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                        return new DataResult { Code = 500, FileIds = new List<long>(), Message = "This request is not properly formatted" };

                    var fileName = fileData.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                        fileName = fileName.Trim('"');
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                        fileName = Path.GetFileName(fileName);

                    var fileOriginName = fileData.Headers.ContentDisposition.FileName;
                    fileOriginName = fileOriginName.Trim('\"');
                    var fileContentType = fileData.Headers.ContentType.MediaType;

                    version = version.Replace("_",".");

                    var cate = HttpContext.Current.Request.QueryString["cate"];
                    cate = string.IsNullOrWhiteSpace(cate) ? "" : cate;

                    var fileinfo = new FileInfo(fileData.LocalFileName);
                    var fileSize = fileinfo.Length;
                    var ext = Path.GetExtension(fileName);
                    var curFileDirExt = curFileDir + "\\" + ext;
                    if (!Directory.Exists(curFileDirExt)) Directory.CreateDirectory(curFileDirExt);
                    fileName = Guid.NewGuid().ToString("N") + ext;
                    File.Move(fileData.LocalFileName, Path.Combine(curFileDirExt, fileName));

                    var entity = new OceanFile
                    {
                        FileName = fileName,
                        Ext = ext,
                        FilePath = curFileDirExt,
                        FileSize = fileSize,
                        FileType = cate,
                        OriginName = fileOriginName,
                        ContentType = fileContentType,
                        SrcIp = srcIp,
                        FileKey = "",
                        Version = version,
                        AddTime = DateTime.Now
                    };

                    var id = data.AddFile(entity);
                    fileIds.Add(id);
                }

                return new DataResult { Code = 200, FileIds = fileIds, Message = "" };
            }
            catch (Exception ex)
            {
                return new DataResult { Code = 500, FileIds = new List<long>(), Message = ex.Message };
            }
        }


        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp()
        {
            var result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }


    }
}