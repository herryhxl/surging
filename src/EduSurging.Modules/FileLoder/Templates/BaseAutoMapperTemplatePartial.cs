using System.Collections.Generic;

namespace FileLoder.Templates
{
    public partial class BaseAutoMapperTemplate
    {
        private readonly string _projectName;
        private readonly string _entityName;
        private readonly List<TableModel> _AllModel;

        public BaseAutoMapperTemplate(string projecctName,string entityName, List<TableModel> AllModel)
        {
            _projectName = projecctName;
            _entityName = entityName;
            _AllModel= AllModel;
        }
    }
}