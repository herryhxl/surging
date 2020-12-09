using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.Templates
{
    public partial class IRepositoryTemplate
    {
        private readonly string _projectName;
        private readonly SaveOptions _options;
        private readonly string _IRepository;
        public IRepositoryTemplate(string projectName,SaveOptions options)
        {
            _options = options;
            _projectName = projectName;
            if (options.DataBaseType == DataBaseType.MSSQL)
            {
                _IRepository = "IRepository";
            }
            else if (options.DataBaseType == DataBaseType.MySql)
            {
                _IRepository = "IMySqlRepository";
            }
            else if (options.DataBaseType == DataBaseType.Oracle)
            {
                _IRepository = "IOracleRepository";
            }
        }
    }
}