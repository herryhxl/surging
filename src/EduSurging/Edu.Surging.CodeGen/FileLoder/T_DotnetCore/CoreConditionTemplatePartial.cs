﻿using System.Collections.Generic;
using FileLoder.TemplateModel;

namespace FileLoder.T_DotnetCore
{
    public partial class CoreConditionTemplate
    {
        private readonly string _entityName;
        private readonly List<ColumnsModel> _models;
        private readonly string _projectName;

        public CoreConditionTemplate(List<ColumnsModel> models, string entityName, string projectName)
        {
            _models = models;
            _entityName = entityName;
            _projectName = projectName;
        }
    }
}