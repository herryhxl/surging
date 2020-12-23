using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreIBaseContextTemplate
    {
        private readonly string _projectName;

        public CoreIBaseContextTemplate(string projecctName)
        {
            _projectName = projecctName;
        }
    }
}