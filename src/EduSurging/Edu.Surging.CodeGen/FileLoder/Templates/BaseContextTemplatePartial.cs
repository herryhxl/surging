namespace FileLoder.Templates
{
    public partial class BaseContextTemplate
    {
        private readonly string _projectName;
        private readonly string _entityName;

        public BaseContextTemplate(string projecctName,string entityName)
        {
            _projectName = projecctName;
            _entityName = entityName;
        }
    }
}