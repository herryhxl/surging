using FileLoder.TemplateModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoder
{
    public class ExcelResult
    {
        public bool Success { set; get; }
        public string ExcelPath { set; get; }
    }

    public class CodePara
    {
        public DataTable Table { set; get; }
        public ExcelType Type { set; get; }
        public SaveOptions Option { set; get; }
        public List<string> Tag { set; get; }
        public List<TableModel> TableList { set; get; }
        public List<TableModel> AllTableList { set; get; }
    }

    public class FileInfoMessage
    {
        public string Type { set; get; }
        public string Code { set; get; }
        public string FileName { set; get; }
        public string Length { set; get; }
        public int? VersionCode { set; get; }
        public string FilePath { set; get; }
        public string Path { set; get; }
        public DateTime LastWriteTime { set; get; }
        public DateTime CreationTime { set; get; }
        public string Suffix { set; get; }
        //作品名称
        public string WorksName { set; get; }
        //学生姓名
        public string StuName { set; get; }
        //学生电话
        public string StuPhone { set; get; }
        //教师姓名
        public string TeName { set; get; }
        //教师电话
        public string TePhone { set; get; }
    }

    public class ReportInfo
    {
        public double Percent { set; get; }
        public string Message { set; get; }
    }
    public enum ExcelType
    {
        数据库结构 = 1,
        数据 = 2
    }

    public enum CreateCodeType
    {
        AdoNet代码 = 1,
        CodeFirst代码 = 2,
        Android代码 = 3,
        LigerUI代码 = 4,
        EFCore代码 = 5
    }
    public enum DataBaseType
    {
        MSSQL = 1,
        MySql = 2,
        Oracle = 3
    }

    public class SaveOptions
    {
        public CreateCodeType CreateCodeType { set; get; }
        public string OutPath { set; get; }
        public string NameSpace { set; get; }
        public bool Entity { set; get; }
        public bool ChangeService { set; get; }
        public bool Mappings { set; get; }
        public bool Controller { set; get; }
        public bool ViewModels { set; get; }
        public bool Service { set; get; }
        public bool BaseService { set; get; }
        public bool Base { set; get; }
        //public string LinkServerNameSpace { set; get; }
        public string ApiNameSpace { set; get; }
        public string MapText { set; get; }
        public string RepositoryText { set; get; }
        public bool IsCancel { set; get; }
        public DataBaseType DataBaseType { set; get; }
        public bool Procedures { set; get; }
        public string Schmal { set; get; }
    }

    public class SysconstraintsModel
    {
        public string column_id { set; get; }
        public string constid { set; get; }
        public string id { set; get; }
        public string colid { set; get; }
    }

    public class DataBaseInfo
    {
        public string DataBaseName { set; get; }

        public string TableName { set; get; }

        public string DataType { set; get; }

        public bool IsNull { set; get; }

        public bool PK { set; get; }


        public int Length { set; get; }

        public string ColName { set; get; }

        public string Comment { set; get; }
    }

    public class DataSourceInfo
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public string DataSourceName { set; get; }

        public string UserName { set; get; }

        public string PassWord { set; get; }

        public DataBaseType SqlType { set; get; }

        public int Port { set; get; }
        public bool IsCancel { set; get; }
        /// <summary>
        /// 选择数据库
        /// </summary>
        public string DataBaseName { set; get; }

        public bool IsValied()
        {
            return DataSourceName != null && UserName != null && PassWord != null && IsCancel != true;
        }

        override
        public string ToString()
        {
            return DataSourceName;
        }

        public string Connect
        {
            get
            {
                if (SqlType == DataBaseType.MySql)
                    return string.Format("Data Source={0};Initial Catalog={1};user id={2};password={3};port={4}", DataSourceName, DataBaseName, UserName, PassWord, Port);
                else if (SqlType == DataBaseType.MSSQL)
                    return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=False;Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=True", DataSourceName, DataBaseName, UserName, PassWord);
                else throw new Exception("");
            }
        }
    }

    public class TableModel
    {
        public string Id { set; get; }
        public string ObjectID { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Comment { set; get; }
        public List<ColumnsModel> ColumnsList { set; get; }
        //public List<KeysModel> KeysModelList { set; get; }
        //public List<PrimaryKeyModel> PrimaryKey { set; get; }
        //public string DataBaseName { set; get; }

        public string Parent_Obj { set; get; }
        public string XType { set; get; }
        public string DataBaseName { set; get; }
        public int Count { set; get; }
    }
    public class ColumnsModel
    {
        public string Id { set; get; }
        public bool IsAutoAdd { set; get; }
        public string Colid { set; get; }
        public string ObjectID { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string DataType { set; get; }
        public string CodeType { set; get; }
        public string C_CodeType { set; get; }
        public bool IsNull { set; get; }
        public int Length { set; get; }
        //public string Mandatory { set; get; }
        public bool PK { set; get; }
        public bool FK { set; get; }
        public bool One { set; get; }
        public List<EnumValueModel> EmodelList { set; get; }
        public bool EM { set; get; }
        public string EnumName { set; get; }
        public string Comment { set; get; }
        public string FKTable { set; get; }
        public string FKCode { set; get; }
        public SearchType Search { set; get; }
        public bool OrderBy { set; get; }
        public string Remark { set; get; }
        public bool Virtual { set; get; }
        public bool IsXML { set; get; }
        public bool XMLMany { set; get; }
        public List<XmlModel> XModel { set; get; }
    }
    public class XmlModel
    {
        /// <summary>
        /// xml字段的描述
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// xml字段的数据类型
        /// </summary>
        public string DataType { set; get; }
        /// <summary>
        /// xml字段的名称
        /// </summary>
        public string Code { set; get; }

        public string CodeType { set; get; }


        /// <summary>
        /// xml字段的搜索
        /// </summary>
        public string Search { set; get; }
    }

    public class KeysModel
    {
        public string Id { set; get; }
        public string ObjectID { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }

        public List<RefModel> ColumnKey { set; get; }
    }
    public class RefModel
    {
        public string Ref { set; get; }
    }
    public class PrimaryKeyModel
    {
        public string Ref { set; get; }
    }

    public class ReferenceModel
    {
        public string Id { set; get; }
        public string ObjectID { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string ParentTable { set; get; }
        public string ChildTable { set; get; }
        public string ParentKey { set; get; }
        public string Comment { set; get; }
        public bool One { set; get; }

        public string Object1 { set; get; }
        public string Object2 { set; get; }
    }
}
