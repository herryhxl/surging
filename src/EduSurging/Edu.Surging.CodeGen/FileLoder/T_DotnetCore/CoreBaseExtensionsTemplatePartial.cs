using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreBaseExtensionsTemplate
    {
        private readonly string _projectName;
        private readonly List<TableModel> _AllModel;
        private readonly SaveOptions _options;

        public CoreBaseExtensionsTemplate(string projecctName, SaveOptions options, List<TableModel> AllModel)
        {
            _projectName = projecctName;
            _AllModel = AllModel;
            _options = options;
        }
    }
}