﻿using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreServiceTemplate
    {
        private readonly string _entityName;
        private readonly string _projectName;
        private readonly List<ColumnsModel> _sModels;
        private readonly TableModel models;
        private readonly SaveOptions _options;
        private readonly string _repositoryText;
        private readonly bool _pro;
        private readonly List<TableModel> _AllModels;

        public CoreServiceTemplate(string projectName, string entityName, List<ColumnsModel> sModels, TableModel Models, string repositoryText,
            bool pro, SaveOptions options, List<TableModel> AllModels)
        {
            _projectName = projectName;
            _entityName = entityName;
            _sModels = sModels;
            models = Models;
            _AllModels = AllModels;
            _repositoryText = repositoryText;
            _pro = pro;
            _options = options;
        }
    }
}