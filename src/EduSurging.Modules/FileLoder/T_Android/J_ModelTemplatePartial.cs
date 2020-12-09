using System.Collections.Generic;

namespace FileLoder.T_Android
{
    public partial class J_ModelTemplate
    {
        private readonly string _entityName;
        private readonly TableModel _models;
        private readonly string _package;
        private readonly List<TableModel> _AllModel;

        public J_ModelTemplate(TableModel models, string ntityName, string package, List<TableModel> mo)
        {
            _models = models;
            _entityName = ntityName;
            _package = package;
            _AllModel = mo;
        }
    }
}