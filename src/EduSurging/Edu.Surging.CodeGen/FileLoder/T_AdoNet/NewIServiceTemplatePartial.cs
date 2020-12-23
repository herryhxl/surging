using System.Collections.Generic;

namespace FileLoder.T_AdoNet
{
    public partial class NewIServiceTemplate
    {
        private readonly string _entityName;
        private readonly string _projectName;
        private readonly List<ColumnsModel> _Columns;
        public NewIServiceTemplate(string ProjectName, TableModel model)
        {
            _projectName = ProjectName;
            this._entityName = model.Code;
            this._Columns = model.ColumnsList;
        }
    }
}