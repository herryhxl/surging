using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.Templates
{
    public partial class ConditionTemplate
    {
        private readonly string _entityName;
        private readonly List<ColumnsModel> _models;
        private readonly string _projectName;

        public ConditionTemplate(List<ColumnsModel> models, string entityName, string projectName)
        {
            _models = models;
            _entityName = entityName;
            _projectName = projectName;
        }
    }
}