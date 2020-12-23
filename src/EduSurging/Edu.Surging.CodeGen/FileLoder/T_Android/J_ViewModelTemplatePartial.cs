using System.Collections.Generic;

namespace FileLoder.T_Android
{
    public partial class J_ViewModelTemplate
    {
        private readonly string _entityName;
        private readonly TableModel _models;
        private readonly string _package;
        private readonly List<TableModel> _AllModel;
        private readonly string _projectName;

        public J_ViewModelTemplate(TableModel models, string ntityName, string package,List<TableModel> mo,string projectName)
        {
            _models = models;
            _entityName = ntityName;
            _package = package;
            _AllModel = mo;
            _projectName = projectName;
        }
    }
}