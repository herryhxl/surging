using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace FileLoder.Helper
{
    public class XmlLoder
    {
        private readonly string _filename = "Setting.xml";
        private readonly string _optionsFilename = "Options.xml";

        public XmlLoder()
        {
        }

        protected virtual string MapPath(string path)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            var mypath = Path.Combine(baseDirectory, path);
            if (!Directory.Exists(mypath))
            {
                Directory.CreateDirectory(mypath);
            }
            return mypath;
        }

        public void Process(DataSourceInfo info)
        {
            var oldData = Info;
            var data = oldData.FirstOrDefault(t => t.DataSourceName == info.DataSourceName);
            if (data != null)
                oldData.Remove(data);
            oldData.Add(info);
            Info = oldData;
        }
        public void ProcessOptions(SaveOptions info)
        {
            var oldData = OptionsInfo;
            var data = oldData.FirstOrDefault(t => t.CreateCodeType == info.CreateCodeType&&t.OutPath==info.OutPath);
            if (data != null)
                oldData.Remove(data);
            oldData.Add(info);
            OptionsInfo = oldData;
        }


        public List<DataSourceInfo> Info
        {
            get
            {
                var filePath = Path.Combine(MapPath("~/Config/"), _filename);
                if (File.Exists(filePath))
                {
                    var text = File.ReadAllText(filePath);
                    return XmlDeserialize<List<DataSourceInfo>>(text);
                }
                return new List<DataSourceInfo>();
            }
            private set
            {
                string filePath = Path.Combine(MapPath("~/Config/"), _filename);
                string text = ToXml(value);
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath))
                    {
                    }
                }
                File.WriteAllText(filePath, text);
            }
        }

        public List<SaveOptions> OptionsInfo
        {
            get
            {
                var filePath = Path.Combine(MapPath("~/Config/"), _optionsFilename);
                if (File.Exists(filePath))
                {
                    var text = File.ReadAllText(filePath);
                    return XmlDeserialize<List<SaveOptions>>(text);
                }
                return new List<SaveOptions>();
            }
            private set
            {
                string filePath = Path.Combine(MapPath("~/Config/"), _optionsFilename);
                string text = ToXml(value);
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath))
                    {}
                }
                File.WriteAllText(filePath, text);
            }
        }

        private string ToXml<T>(T entity) where T : new()
        {
            StringBuilder buffer = new StringBuilder();
            XmlSerializer se = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(buffer))
            {
                se.Serialize(writer, entity);
            }
            return buffer.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        private T XmlDeserialize<T>(string xmlString)
        {
            T cloneObject;
            var buffer = new StringBuilder();
            buffer.Append(xmlString);
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(buffer.ToString()))
            {
                var obj = serializer.Deserialize(reader);
                cloneObject = (T)obj;
            }
            return cloneObject;
        }
    }
}
