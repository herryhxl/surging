namespace FileLoder.T_Android
{
    public partial class J_AdapterTemplate
    {
        private readonly string _projectName;
        private readonly TableModel _models;
        private readonly string _package;

        public J_AdapterTemplate(TableModel models, string projectName, string package)
        {
            _models = models;
            _projectName = projectName;
            _package = package;
        }
    }
}