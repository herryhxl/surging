using System.Collections.Generic;

namespace FileLoder.T_Android
{
    public partial class J_LayoutMainTemplate
    {
        private readonly string _projectName;
        private readonly List<TableModel> _models;
        private readonly string _package;

        public J_LayoutMainTemplate(List<TableModel> models, string projectName, string package)
        {
            _models = models;
            _projectName = projectName;
            _package = package;
        }
    }
}