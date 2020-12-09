using System.Collections.Generic;

namespace FileLoder.T_Android
{
    public partial class J_EventTemplate
    {
        private readonly string _projectName;
        private readonly TableModel _models;
        private readonly string _package;
        private readonly List<TableModel> _AllModel;

        public J_EventTemplate(TableModel models, string projectName, string package, List<TableModel> mo)
        {
            _AllModel = mo;
            _models = models;
            _projectName = projectName;
            _package = package;
        }
    }
}