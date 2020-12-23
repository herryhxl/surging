using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.Templates
{
    public partial class ViewModelDoTemplate
    {
        private readonly string _entityName;
        private readonly TableModel _models;
        private readonly string _projectName;

        public ViewModelDoTemplate(TableModel models, string ntityName, string projectName)
        {
            _models = models;
            _entityName = ntityName;
            _projectName = projectName;
        }
    }
}