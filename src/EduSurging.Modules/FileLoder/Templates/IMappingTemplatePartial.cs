using FileLoder.TemplateModel;

namespace FileLoder.Templates
{
    public partial class IMappingTemplate
    {
        private readonly string _projectName;

        public IMappingTemplate(string projectName)
        {
            _projectName = projectName;
        }
    }
}