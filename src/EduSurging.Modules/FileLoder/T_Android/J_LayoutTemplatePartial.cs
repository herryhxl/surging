namespace FileLoder.T_Android
{
    public partial class J_LayoutTemplate
    {
        private readonly string _entityName;
        private readonly TableModel _models;
        private readonly string _package;

        public J_LayoutTemplate(TableModel models, string ntityName, string package)
        {
            _models = models;
            _entityName = ntityName;
            _package = package;
        }
    }
}