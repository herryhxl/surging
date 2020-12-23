using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreDbContextTemplate
    {
        private readonly string _projectName;
        private readonly string _dbContext;
        private readonly SaveOptions _options;
        private readonly bool _pro;
        public CoreDbContextTemplate(string projectName, SaveOptions options)
        {
            _options = options;
            _projectName = projectName;
            _pro = options.Procedures && options.DataBaseType == DataBaseType.MSSQL;
            if (options.DataBaseType == DataBaseType.MSSQL)
            {
                _dbContext = "EfDbContext";
            }
            else if (options.DataBaseType == DataBaseType.MySql)
            {
                _dbContext = "MySqlEfDbContext";
            }
            else if (options.DataBaseType == DataBaseType.Oracle)
            {
                _dbContext = "OracleEfDbContext";
            }
        }
    }
}