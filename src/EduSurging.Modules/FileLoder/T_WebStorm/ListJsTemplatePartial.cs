using System.Collections.Generic;

namespace FileLoder.T_WebStorm
{
    public partial class ListJsTemplate
    {
        private readonly string _entityName;
        private readonly TableModel models;
        private readonly string _projectName;
        private readonly string _apiName;
        private readonly bool _pro;
        private readonly List<TableModel> _AllModel;

        public ListJsTemplate(TableModel _models, string ntityName, string projectName, string apiName, bool pro, List<TableModel> mo)
        {
            models = _models;
            _entityName = ntityName;
            _projectName = projectName;
            _apiName = apiName;
            _pro = pro;
            _AllModel = mo;
        }
    }
}