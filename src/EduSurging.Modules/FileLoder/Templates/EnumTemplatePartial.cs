using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.Templates
{
    public partial class EnumTemplate
    {
        private readonly List<EnumModel> _models;
        private readonly string _projectName;

        public EnumTemplate(List<EnumModel> models, string projectName)
        {
            _models = models;
            _projectName = projectName;
        }
    }
}