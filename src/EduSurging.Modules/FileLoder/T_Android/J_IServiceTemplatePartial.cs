namespace FileLoder.T_Android
{
    public partial class J_IServiceTemplate
    {
        private readonly string _entityName;
        private readonly string _package;

        private readonly TableModel _models;

        public J_IServiceTemplate(string projecctName, string entityName, TableModel models)
        {
            _package = projecctName;
            _entityName = entityName;
            _models = models;
        }
    }
}