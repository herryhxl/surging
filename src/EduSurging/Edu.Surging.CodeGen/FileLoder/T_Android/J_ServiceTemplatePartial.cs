
namespace FileLoder.T_Android
{
    public partial class J_ServiceTemplate
    {
        private readonly string _entityName;
        private readonly string _pcckage;
        private readonly TableModel _models;

        public J_ServiceTemplate(string package, string entityName, TableModel Models)
        {
            _pcckage = package;
            _entityName = entityName;
            _models = Models;
        }
    }
}