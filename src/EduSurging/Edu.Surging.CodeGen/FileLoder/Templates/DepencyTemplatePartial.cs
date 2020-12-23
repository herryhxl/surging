namespace FileLoder.Templates
{
    public partial class DepencyTemplate
    {
        private readonly string _projectName;
        private readonly DataBaseType _dataBaseType;
        public DepencyTemplate(string projecctName,SaveOptions options)
        {
            _projectName = projecctName;
            _dataBaseType = options.DataBaseType;
        }
    }
}