namespace FileLoder.T_Android
{
    public partial class J_DAOTemplate
    {
        private readonly string _entityName;
        private readonly string _package;

        private readonly TableModel _models;

        public J_DAOTemplate(string projecctName, string entityName, TableModel models)
        {
            _package = projecctName;
            _entityName = entityName;
            _models = models;
        }
    }
}