using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orm.Son.Mapper;

namespace Ocean.Server.Models
{
    public class OceanFile
    {
        [Description("文件Id")]
        public long Id { get; set; }
        [Description("文件类型：1，图片 2，音频 3，视频 4，文档，5，压缩包  6，js/css/html 7，app安装包 100，其它")]
        public int FileType { get; set; }
        [Description("文件路径")]
        public string FilePath { get; set; }
        [Description("文件名")]
        public string FileName { get; set; }
        [Description("文件大小")]
        public long FileSize { get; set; }
        [Description("扩展名")]
        public string Ext { get; set; }
        [Description("七牛Id")]
        public string FileKey { get; set; }
        [Description("版本号")]
        public string Version { get; set; }
        [Description("上传IP")]
        public string SrcIp { get; set; }
        [Description("添加时间")]
        public DateTime AddTime { get; set; }
    }
}