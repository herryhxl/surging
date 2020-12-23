using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreDataBaseScriptTemplate
    {
        private readonly string _projectName;
        private readonly DataBaseType _dataBaseType;
        private readonly List<TableModel> _allModel;
        private readonly SaveOptions _options;
        public CoreDataBaseScriptTemplate(string projecctName, SaveOptions options, List<TableModel> Model)
        {
            _projectName = projecctName;
            _dataBaseType = options.DataBaseType;
            _allModel = Model;
            _options = options;
        }
    }
}