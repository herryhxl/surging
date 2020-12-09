using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreSqlFunctionTemplate
    {

        private readonly string _entityName;
        private readonly TableModel _models;
        private readonly string _projectName;

        public CoreSqlFunctionTemplate(TableModel models, string ntityName, string projectName)
        {
            _models = models;
            _entityName = ntityName;
            _projectName = projectName;
        }
    }
}