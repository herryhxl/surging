using System;
using System.Collections.Generic;

namespace FileLoder.T_AdoNet
{
    public partial class NewServiceTemplate
    {
        private readonly string _entityName;
        private readonly string _projectName;
        private readonly List<ColumnsModel> _Columns;
        private readonly SaveOptions _options;
        public NewServiceTemplate(string ProjectName, TableModel model,SaveOptions options)
        {
            _projectName = ProjectName;
            this._entityName = model.Code;
            this._Columns = model.ColumnsList;
            _options = options;
        }
    }
}