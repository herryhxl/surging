using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreMappingTemplate
    {

        private readonly TableModel _eModel;
        private readonly string _entityName;
        private readonly string _projectName;
        private readonly string _mapText;
        private readonly SaveOptions _options;
        private readonly bool _oracle;
        private readonly string _schmal;
        public CoreMappingTemplate(TableModel Model, string projectName,
            string entityName, string mapText, SaveOptions options)
        {
            _eModel = Model;
            _projectName = projectName;
            _entityName = entityName;
            _mapText = mapText;
            _options = options;
            _oracle = options.DataBaseType == DataBaseType.Oracle;
            _schmal = options.Schmal;
        }
    }
}