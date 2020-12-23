using System.Collections.Generic;
using System.Linq;

namespace FileLoder.T_Android
{
    public partial class J_DBOpenHelperTemplate
    {
        private readonly string _package;
        private readonly List<TableModel> _models;
        public J_DBOpenHelperTemplate(string package,List<TableModel> models)
        {
            _package = package;
            _models = models;
        }
    }
}