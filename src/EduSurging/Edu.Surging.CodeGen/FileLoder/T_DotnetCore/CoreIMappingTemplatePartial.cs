using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreIMappingTemplate
    {
        private readonly string _projectName;

        public CoreIMappingTemplate(string projectName)
        {
            _projectName = projectName;
        }
    }
}