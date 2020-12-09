using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_LigerUI
{
    public partial class ControllerTemplate
    {
        private readonly string _entityName;
        private readonly TableModel models;
        private readonly string _projectName;
        private readonly string _apiName;
        private readonly bool _pro;

        public ControllerTemplate(TableModel _models, string ntityName, string projectName,string apiName,bool pro)
        {
            models = _models;
            _entityName = ntityName;
            _projectName = projectName;
            _apiName = apiName;
            _pro = pro;
        }
    }
}