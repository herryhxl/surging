using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreRepositoryTemplate
    {
        private readonly string _projectName;
        private readonly SaveOptions _options;
        private readonly string _RepositoryName;
        private readonly string _DbContextName;
        public CoreRepositoryTemplate(string projectName, SaveOptions options)
        {
            _projectName = projectName;
            _options = options;
            if (options.DataBaseType == DataBaseType.MSSQL)
            {
                _RepositoryName = "EfRepository";
                _DbContextName = "IDbContext";
            }
            else if (options.DataBaseType == DataBaseType.MySql)
            {
                _RepositoryName = "MySqlEfRepository";
                _DbContextName = "IMySqlDbContext";
            }
            else if (options.DataBaseType == DataBaseType.Oracle)
            {
                _RepositoryName = "OracleEfRepository";
                _DbContextName = "IOracleDbContext";
            }
        }
    }
}