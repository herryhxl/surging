using System.Collections.Generic;

namespace FileLoder.T_Android
{
    public partial class J_DataViewMainTemplate
    {
        private readonly string _projectName;
        private readonly List<TableModel> _models;
        private readonly string _package;

        public J_DataViewMainTemplate(List<TableModel> models, string projectName, string package)
        {
            _models = models;
            _projectName = projectName;
            _package = package;
        }
    }
}