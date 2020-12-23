using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreEnumTemplate
    {
        private readonly List<EnumModel> _models;
        private readonly string _projectName;

        public CoreEnumTemplate(List<EnumModel> models, string projectName)
        {
            _models = models;
            _projectName = projectName;
        }
    }
}