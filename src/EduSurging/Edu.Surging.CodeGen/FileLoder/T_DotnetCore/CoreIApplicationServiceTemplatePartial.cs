using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreIApplicationServiceTemplate
    {

        private readonly string _entityName;
        private readonly string _projectName;
        private readonly SaveOptions _options;
        private readonly TableModel _models;
        private readonly bool _pro;
        public CoreIApplicationServiceTemplate(string projecctName, string entityName, TableModel models, bool pro)
        {
            _projectName = projecctName;
            _entityName = entityName;
            _models = models;
            _pro = pro;
        }
    }
}