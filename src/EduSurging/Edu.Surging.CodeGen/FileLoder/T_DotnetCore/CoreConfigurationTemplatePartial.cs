using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreConfigurationTemplate
    {

        private readonly List<TableModel> _models;
        private readonly string _projectName;
        private readonly bool _pro;
        private readonly DataBaseType _dataBaseType;
        public CoreConfigurationTemplate(List<TableModel> models, string projectName, SaveOptions options)
        {
            _models = models;
            _projectName = projectName;
            _pro = options.Procedures && options.DataBaseType == DataBaseType.MSSQL;
            _dataBaseType = options.DataBaseType;
        }
    }
}