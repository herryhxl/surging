using System.Collections.Generic;
using FileLoder.TemplateModel;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Web;

namespace FileLoder.Templates
{
    public partial class ControllerTemplate
    {
        private readonly string _entityName;
        private readonly TableModel models;
        private readonly string _projectName;
        private readonly string _apiName;
        private readonly bool _pro;
        private readonly string _columnsStr;

        private readonly string _repositoryText;
        //private readonly string _menulist;

        public ControllerTemplate(TableModel _models, string ntityName, string projectName, string apiName, string repositoryText, bool pro)
        {
            models = _models;
            _entityName = ntityName;
            _projectName = projectName;
            _apiName = apiName;
            _pro = pro;
            _columnsStr = HttpUtility.UrlEncode(Newtonsoft.Json.JsonConvert.SerializeObject(_models.ColumnsList));
            _repositoryText = repositoryText;
            //StringBuilder builder = new StringBuilder();
            //_models.ColumnsList.Where(t => t.FK == true || t.Virtual == true).ToList().ForEach(item =>
            //{
            //    if (item.FK)
            //    {
            //        builder.Append("," + item.FKTable.Replace("Entity", "Controller.GetById"));
            //    }
            //    if (item.Virtual)
            //    {
            //        if (item.CodeType.EndsWith("Entity"))
            //        {
            //            builder.Append(","+item.CodeType.Replace("Entity", "Controller.GetById"));
            //        }
            //        else if (item.CodeType.EndsWith("List"))
            //        {
            //            builder.Append("," + item.CodeType.Split(new char[] { '_'})[1].Replace("List", "Controller.GetById"));
            //        }
            //    }
            //});
            //_menulist = builder.ToString();
        }

        private string getString(List<ColumnsModel> data)
        {
            StringBuilder buffer = new StringBuilder();
            XmlSerializer se = new XmlSerializer(typeof(List<ColumnsModel>));
            using (TextWriter writer = new StringWriter(buffer))
            {
                se.Serialize(writer, data);
            }
            return buffer.ToString();
        }
    }
}