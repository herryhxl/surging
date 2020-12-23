using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileLoder.TemplateModel;
using System.Data.OleDb;
using System.Net;
using System.IO;
using Aspose.Words;

namespace FileLoder.Helper
{
    public class Helper
    {
        public static OleDbConnection GetConnect(string path)
        {
            var ConStr = "";
            if (path.EndsWith("xls")) ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
            else if (path.EndsWith("xlsx")) ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";
            else if (path.EndsWith("xlsb")) ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(ConStr);
            conn.Open();
            return conn;
        }

        public static string Post(string text, string url)
        {
            HttpWebRequest requestScore = (HttpWebRequest)WebRequest.Create(url);
            byte[] data = Encoding.UTF8.GetBytes(text);
            requestScore.Method = "Post";
            requestScore.ContentType = "application/x-www-form-urlencoded";
            requestScore.ContentLength = data.Length;
            requestScore.KeepAlive = true;

            //使用cookies
            //requestScore.CookieContainer = ...;
            Stream stream = requestScore.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse responseSorce = (HttpWebResponse)requestScore.GetResponse();
            StreamReader reader = new StreamReader(responseSorce.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            requestScore = null;
            responseSorce.Close();
            responseSorce = null;
            reader = null;
            stream = null;
            return content;
        }

        public static string Get(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch
            {
                return "";
            }
        }

        public static List<FileInfoMessage> GetFilesInfo(string filepath)
        {
            List<FileInfoMessage> fileinfo = new List<FileInfoMessage>();
            DirectoryInfo directory = new DirectoryInfo(filepath);
            GetFile(directory, fileinfo);
            return fileinfo;
        }
        private static void GetFile(DirectoryInfo directory, List<FileInfoMessage> fileinfo)
        {
            var infos = directory.GetFileSystemInfos();
            if (infos.Length == 0)
            {
                var sp = directory.FullName.Split(new char[] { '\\' });
                var Length = sp.Length;
                FileInfoMessage info = new FileInfoMessage
                {
                    FileName = directory.Name,
                    Length = "0",
                    FilePath = directory.FullName,
                    Path = directory.FullName.Substring(0, directory.FullName.LastIndexOf("\\")),
                    LastWriteTime = directory.LastWriteTime,
                    Code = sp[Length - 2],
                    CreationTime = directory.CreationTime,
                    Suffix = "",
                    Type = "目录"
                };
                fileinfo.Add(info);
            }
            foreach (var item in infos)
            {
                var sp = item.FullName.Split(new char[] { '\\' });
                var Length = sp.Length;
                if (item is FileInfo)
                {
                    FileInfo FileInfoitem = (FileInfo)item;
                    var Suffix = "";
                    if (item.Name.LastIndexOf(".") > 0)
                        Suffix = item.Name.Substring(item.Name.LastIndexOf(".")).ToLower();
                    FileInfoMessage info = new FileInfoMessage
                    {
                        FileName = item.Name,
                        Length = (int)(FileInfoitem.Length / 1024) + "KB",
                        FilePath = item.FullName,
                        Path = item.FullName.Substring(0, item.FullName.LastIndexOf("\\")),
                        LastWriteTime = item.LastWriteTime,
                        Code = sp[Length - 2],
                        CreationTime = item.CreationTime,
                        Suffix = Suffix,
                        Type = "文件"
                    };
                    fileinfo.Add(info);
                }
                else if (item is DirectoryInfo)
                {
                    DirectoryInfo DirectoryInfoitem = (DirectoryInfo)item;
                    GetFile(DirectoryInfoitem, fileinfo);
                }
            }
        }

        public static string getDocText(string filepath)
        {
            try
            {
                Document doc = new Document(filepath);
                //var doclist= doc.ChildNodes.ToArray();

                return doc.GetText();
            }
            catch
            {
                return "";
            }
        }


        public static string[] GetStoredPro(TableModel item)
        {
            var store = new string[] { "", "" };
            var proName = item.Code + "_Pro" + "_Search";
            var funcName = item.Code + "_Func" + "_Search";
            var sqlStr = new StringBuilder();
            var sqlFunc = new StringBuilder();
            var sqlWhere = new StringBuilder();
            var sqlPara = new StringBuilder();
            var returns = new StringBuilder();
            var inserts = new StringBuilder();

            string retu = "returns @tab table(_RowNumber int{0}) ";
            string inse = "insert into @tab(_RowNumber{0}) ";
            var orderBy = " order by (case When @OrderBy IS NULL THEN Id {0} END)";

            var seCount = string.Format("IF @Page=1 AND @PageCount IS NOT NULL begin select count(*) from {0}", item.Code) + " where {0} end";

            var StrPRO = "CREATE PROCEDURE [{0}] ({1}) AS IF @{2} IS NULL OR @{2}=0 begin {3} {4} End ElSE begin {5} {6}  END {7}";
            var StrFUN = "CREATE FUNCTION [{0}] ({1})	{2} as begin  IF @{3} IS NULL OR @{3}=0 begin {4} {5} {6}  End ElSE begin {7} {8} {9} END return; end";

            sqlWhere.Append("where ");
            sqlPara.Append(string.Format("@{0} bit = NULL ", "IsDescending"));
            sqlPara.Append(string.Format(",@{0} int = NULL ", "OrderBy"));
            sqlPara.Append(string.Format(",@{0} int = NULL ", "Page"));
            sqlPara.Append(string.Format(",@{0} int = NULL ", "PageCount"));
            sqlWhere.Append(string.Format("((case When @{0} IS NULL OR  @{1} IS NULL THEN 1	else ( 	case when [_RowNumber] BETWEEN @{0}*@{1} and (@{0}+1)*@{1} then 1	else  0 end)END)=1)", "Page", "PageCount"));

            sqlStr.Append(" SELECT * from (SELECT ROW_NUMBER() OVER({0} ) AS [_RowNumber], ");
            sqlFunc.Append(" SELECT * from ( SELECT ROW_NUMBER() OVER({0}) AS [_RowNumber],");
            var data = item.ColumnsList.Where(r => r.Virtual == false).ToList();
            var sum = data.Count;
            var t = 0;
            int orderCount = 1;
            foreach (var model in data)
            {
                var type = model.DataType.Replace("?", "");
                t++;
                if (model.Search == SearchType.In || model.Search == SearchType.Like || model.Search == SearchType.Equal || model.Search == SearchType.Range)
                {
                    sqlWhere.Append(" and ");
                    sqlPara.Append(" , ");
                }
                if (model.OrderBy)//排序参数
                {
                    orderBy = string.Format(orderBy, "else (case when @OrderBy = " + orderCount + " then [" + model.Code + "] {0} end)");
                    orderCount++;
                }

                returns.Append(string.Format(",[{0}] {1} ", model.Code, type));
                inserts.Append(string.Format(",[{0}] ", model.Code));

                if (model.Search == SearchType.In)//数组类型参数
                {
                    sqlPara.Append(string.Format("@{0}s text = NULL ", model.Code));
                    sqlWhere.Append(string.Format("((case When @{0}s IS NULL  THEN 1	else ( 	case when [{0}] in (@{0}s) then 1	else  0 end)END)=1)", model.Code));
                }
                else if (model.Search == SearchType.Like)
                {
                    sqlPara.Append(string.Format("@{0} text = NULL ", model.Code));
                    sqlWhere.Append(string.Format("((case When @{0} IS NULL  THEN 1	else ( 	case when [{0}] Like '%'+@{0}+'%' then 1	else  0 end)END)=1)", model.Code));
                }
                else if (model.Search == SearchType.Equal)
                {
                    sqlPara.Append(string.Format("@{0} {1} = NULL ", model.Code, type));
                    sqlWhere.Append(string.Format("((case When @{0} IS NULL  THEN 1	else ( 	case when [{0}] = @{0} then 1	else  0 end)END)=1)", model.Code));
                }
                else if (model.Search == SearchType.Range)
                {
                    sqlPara.Append(string.Format("@{0} {1} = NULL ", model.Code + "Begin", type));
                    sqlWhere.Append(string.Format("((case When @{0}Begin IS NULL  THEN 1	else ( 	case when [{0}] >= @{0}Begin then 1	else  0 end)END)=1)", model.Code));
                    sqlPara.Append(string.Format(",@{0} {1} = NULL ", model.Code + "End", type));
                    sqlWhere.Append(string.Format("and ((case When @{0}End IS NULL  THEN 1	else ( 	case when [{0}] < @{0}End then 1	else  0 end)END)=1)", model.Code));
                }
                if (t != sum)
                {
                    sqlStr.Append(string.Format("[{0}],", model.Code));
                    sqlFunc.Append(string.Format("[{0}],", model.Code));
                }
                else
                {
                    sqlStr.Append(string.Format("[{0}]", model.Code));
                    sqlFunc.Append(string.Format("[{0}]", model.Code));
                }

            }
            string order = string.Format(orderBy, "else Id ");
            string orderAsc = order + " ASC";
            string orderDesc = order + " DESC";
            var where = sqlWhere.ToString();
            sqlStr.Append(string.Format(" FROM [{0}]", item.Code));
            sqlStr.Append(string.Format(") as y {0}", where));
            sqlFunc.Append(string.Format(" FROM [{0}]", item.Code));
            sqlFunc.Append(string.Format(") as y {0}", where));
            var st = where.Substring(where.IndexOf("=1)"));
            var cou = string.Format(seCount, st.Substring(st.IndexOf("and") + 3));
            var SqlS = string.Format(StrPRO, proName, sqlPara.ToString(), "IsDescending", string.Format(sqlStr.ToString(), orderAsc), orderAsc, string.Format(sqlStr.ToString(), orderDesc), orderDesc, cou);
            var SqlF = string.Format(StrFUN, funcName, sqlPara.ToString(), string.Format(retu, returns.ToString()), "IsDescending", string.Format(inse, inserts.ToString()), string.Format(sqlStr.ToString(), orderAsc), orderAsc, string.Format(inse, inserts.ToString()), string.Format(sqlStr.ToString(), orderDesc), orderDesc);
            store[0] = SqlS;
            store[1] = SqlF;
            return store;
        }
        public static string GetMapDataType(DataBaseType type, string dataType)
        {
            string rtype = "";
            dataType = dataType.IndexOf("(") == -1 ? dataType.Replace("?", "") : dataType.Substring(0, dataType.IndexOf("(")).Replace("?", "");
            if (type == DataBaseType.Oracle)
            {
                switch (dataType)
                {
                    case "int":
                        rtype = "NUMBER(10,0)";
                        break;
                    case "tinyint":
                        rtype = "NUMBER(3,0)";
                        break;
                    case "bigint":
                        rtype = "NUMBER(19,0)";
                        break;
                    case "char":
                        rtype = "CHAR";
                        break;
                    case "nvarchar":
                        rtype = "VARCHAR2";
                        break;
                    case "bit":
                        rtype = "NUMBER(1)";
                        break;
                    case "varchar":
                        rtype = "VARCHAR2";
                        break;
                    case "datetime":
                        rtype = "DATE";
                        break;
                    case "datetime2":
                        rtype = "TIMESTAMP";
                        break;
                    case "date":
                        rtype = "DATE";
                        break;
                    case "text":
                        rtype = "CLOB";
                        break;
                    case "ntext":
                        rtype = "NCLOB";
                        break;
                    case "decimal":
                        rtype = "NUMBER";
                        break;
                    case "money":
                        rtype = "NUMBER(19,4)";
                        break;
                    case "float":
                        rtype = "FLOAT";
                        break;
                    case "xml":
                        rtype = "NCLOB";
                        break;
                    case "uniqueidentifier":
                        rtype = "CHAR(38)";
                        break;
                    default: throw new Exception("类型错误：【" + dataType + "】");
                }
            }
            else if (type == DataBaseType.MySql)
            {
                switch (dataType)
                {
                    case "int":
                        rtype = "int";
                        break;
                    case "tinyint":
                        rtype = "tinyint";
                        break;
                    case "bigint":
                        rtype = "bigint";
                        break;
                    case "char":
                        rtype = "char";
                        break;
                    case "nvarchar":
                        rtype = "varchar";
                        break;
                    case "bit":
                        throw new Exception("MySql支持Bool联查有误");
                        rtype = "bit";
                        break;
                    case "varchar":
                        rtype = "varchar";
                        break;
                    case "datetime":
                        rtype = "datetime";
                        break;
                    case "datetime2":
                        rtype = "datetime";
                        break;
                    case "date":
                        rtype = "date";
                        break;
                    case "text":
                        rtype = "text";
                        break;
                    case "decimal":
                        rtype = "decimal";
                        break;
                    case "money":
                        rtype = "decimal";
                        break;
                    case "float":
                        rtype = "float";
                        break;
                    case "xml":
                        rtype = "text";
                        break;
                    case "uniqueidentifier":
                        rtype = "varchar";
                        break;
                    default: throw new Exception("类型错误：【" + dataType + "】");
                }
            }
            else if (type == DataBaseType.MSSQL)
            {
                string[] r_type = new string[] { "int", "tinyint" ,"bigint"
                ,"char","nvarchar","bit","varchar","datetime","datetime2","date",
                "text","decimal","money","float","xml","uniqueidentifier"};
                if (!r_type.Contains(dataType))
                    throw new Exception("类型错误：【" + dataType + "】");
            }
            return rtype;
        }

        public static string GetScriptDataType(DataBaseType type, string dataType, int Length)
        {
            var OldDataType = dataType;
            dataType = dataType.IndexOf("(") == -1 ? dataType.Replace("?", "") : dataType.Substring(0, dataType.IndexOf("(")).Replace("?", "");
            var rtype = "";
            if (type == DataBaseType.Oracle)
            {
                switch (dataType)
                {
                    case "int":
                        rtype = "NUMBER(10,0)";
                        break;
                    case "tinyint":
                        rtype = "NUMBER(3,0)";
                        break;
                    case "bigint":
                        rtype = "NUMBER(19,0)";
                        break;
                    case "char":
                        rtype = $"CHAR({Length})";
                        break;
                    case "nvarchar":
                        rtype = $"VARCHAR2({Length})";
                        break;
                    case "bit":
                        rtype = "NUMBER(1)";
                        break;
                    case "varchar":
                        rtype = $"VARCHAR2({Length})";
                        break;
                    case "datetime":
                        rtype = "DATE";
                        break;
                    case "datetime2":
                        rtype = "TIMESTAMP";
                        break;
                    case "date":
                        rtype = "DATE";
                        break;
                    case "text":
                        rtype = "CLOB";
                        break;
                    case "ntext":
                        rtype = "NCLOB";
                        break;
                    case "decimal":
                        rtype = "NUMBER";
                        break;
                    case "money":
                        rtype = "NUMBER(19,4)";
                        break;
                    case "float":
                        rtype = "FLOAT";
                        break;
                    case "xml":
                        rtype = "NCLOB";
                        break;
                    case "uniqueidentifier":
                        rtype = "CHAR(38)";
                        break;
                    default: throw new Exception("类型错误：【" + dataType + "】");
                }
            }
            else if (type == DataBaseType.MySql)
            {
                switch (dataType)
                {
                    case "int":
                        rtype = "int";
                        break;
                    case "tinyint":
                        rtype = "tinyint";
                        break;
                    case "bigint":
                        rtype = "bigint";
                        break;
                    case "char":
                        rtype = $"char({Length})";
                        break;
                    case "nvarchar":
                        rtype = $"varchar({Length})";
                        break;
                    case "bit":
                        throw new Exception("MySql支持Bool联查有误");
                        rtype = "bit";
                        break;
                    case "varchar":
                        rtype = $"varchar({Length})";
                        break;
                    case "datetime":
                        rtype = "datetime";
                        break;
                    case "datetime2":
                        rtype = "datetime";
                        break;
                    case "date":
                        rtype = "date";
                        break;
                    case "text":
                        rtype = "text";
                        break;
                    case "decimal":
                        rtype = OldDataType.Replace("[", "(").Replace("]", ")");
                        break;
                    case "money":
                        rtype = "decimal(18,2)";
                        break;
                    case "float":
                        rtype = "float";
                        break;
                    case "xml":
                        rtype = "text";
                        break;
                    case "uniqueidentifier":
                        rtype = "varchar(38)";
                        break;
                    default: throw new Exception("类型错误：【" + dataType + "】");
                }
            }
            else if (type == DataBaseType.MSSQL)
            {
                switch (dataType)
                {
                    case "int":
                        rtype = "int";
                        break;
                    case "tinyint":
                        rtype = "tinyint";
                        break;
                    case "bigint":
                        rtype = "bigint";
                        break;
                    case "char":
                        rtype = $"char({Length})";
                        break;
                    case "nvarchar":
                        rtype = $"varchar({Length})";
                        break;
                    case "bit":
                        rtype = "bit";
                        break;
                    case "varchar":
                        rtype = $"varchar({Length})";
                        break;
                    case "datetime":
                        rtype = "datetime";
                        break;
                    case "datetime2":
                        rtype = "datetime";
                        break;
                    case "date":
                        rtype = "date";
                        break;
                    case "text":
                        rtype = "text";
                        break;
                    case "decimal":
                        rtype = "decimal";
                        break;
                    case "money":
                        rtype = "decimal";
                        break;
                    case "float":
                        rtype = "float";
                        break;
                    case "xml":
                        rtype = "text";
                        break;
                    case "uniqueidentifier":
                        rtype = "uniqueidentifier";
                        break;
                    default: throw new Exception("类型错误：【" + dataType + "】");
                }
            }
            return rtype;
        }
        public static string getDbType(DataBaseType type, string datatype, int length)
        {
            datatype = datatype.IndexOf("(") == -1 ? datatype.Replace("?", "") : datatype.Substring(0, datatype.IndexOf("(")).Replace("?", "");
            string result = datatype;
            if (type == DataBaseType.MSSQL)
            {
                switch (datatype.ToLower())
                {
                    case "int":
                        result = "SqlDbType.Int," + length;
                        break;
                    case "tinyint":
                        result = "SqlDbType.TinyInt," + length;
                        break;
                    case "bigint":
                        result = "SqlDbType.BigInt," + length;
                        break;
                    case "char":
                        result = "SqlDbType.Char," + length;
                        break;
                    case "nvarchar":
                        result = "SqlDbType.NVarChar," + length;
                        break;
                    case "bit":
                        result = "SqlDbType.Bit," + length;
                        break;
                    case "varchar":
                        result = "SqlDbType.VarChar," + length;
                        break;
                    case "datetime":
                        result = "SqlDbType.DateTime";
                        break;
                    case "datetime2":
                        result = "SqlDbType.datetime2," + length;
                        break;
                    case "date":
                        result = "SqlDbType.date," + length;
                        break;
                    case "text":
                        result = "SqlDbType.Text";
                        break;
                    case "decimal":
                        result = "SqlDbType.Decimal," + length;
                        break;
                    case "money":
                        result = "SqlDbType.Money," + length;
                        break;
                    case "float":
                        result = "SqlDbType.Float," + length;
                        break;
                    case "xml":
                        result = "SqlDbType.Xml," + length;
                        break;
                    case "uniqueidentifier":
                        result = "SqlDbType.UniqueIdentifier," + length;
                        break;
                }
            }

            return result;
        }

        public static string DropTableScript(SaveOptions options, TableModel tableModel)
        {
            var Start = "";
            var End = "";
            var TableCode = tableModel.Code;
            if (options.DataBaseType == DataBaseType.MSSQL)
            {
                Start = "["; End = "]";
            }
            else if (options.DataBaseType == DataBaseType.MySql)
            {
                Start = "`"; End = "`";
                TableCode = TableCode.ToLower();
            }
            return $"drop table if exists {Start}{TableCode}{End};";
        }
        public static string CreateTableScript(SaveOptions options, TableModel tableModel)
        {
            var Start = "";
            var End = "";
            var TableCode = tableModel.Code;
            if (options.DataBaseType == DataBaseType.MSSQL)
            {
                Start = "["; End = "]";
            }
            else if (options.DataBaseType == DataBaseType.MySql)
            {
                Start = "`"; End = "`";
                TableCode = TableCode.ToLower();
            }
            var FieldString = string.Join(",\r\n", tableModel.ColumnsList.Where(t => t.Virtual == false).Select(r => $"     {Start}{r.Code}{End}     {GetScriptDataType(options.DataBaseType, r.DataType, r.Length)} {(r.IsNull ? "null" : "not null")} {(r.Comment == null || r.Comment == "" || r.Comment.Trim() == "" ? $"comment '{r.Name}'" : $"comment '{r.Comment}'")} {(r.PK ? "AUTO_INCREMENT" : "")}").ToList());
            var PKString = $"     primary key ({Start}{tableModel.ColumnsList.Where(t => t.PK == true).FirstOrDefault()?.Code}{End})";
            return $"create table {Start}{TableCode}{End} (\r\n {FieldString},\r\n{PKString} \r\n); \r\n alter table {Start}{TableCode}{End} comment '{tableModel.Name}';";
        }
        public static string CreateFKScript(SaveOptions options, TableModel tableModel)
        {
            var Start = "";
            var End = "";
            var TableCode = tableModel.Code;
            if (options.DataBaseType == DataBaseType.MSSQL)
            {
                Start = "["; End = "]";
            }
            else if (options.DataBaseType == DataBaseType.MySql)
            {
                Start = "`"; End = "`";
                TableCode = TableCode.ToLower();
            }
            if (tableModel.ColumnsList.Any(t => t.FK == true))
            {
                return string.Join("\r\n", tableModel.ColumnsList.Where(t => t.FK == true).Select(t => $"alter table {Start}{TableCode}{End} add constraint {tableModel.Code}_{t.Code} foreign key({Start}{t.Code}{End}) references {Start}{t.FKTable.Replace("Entity", "").ToLower()}{End} (`{t.FKCode}`) on delete restrict on update restrict;"));
            }
            return "";
        }

        public static string getDefaultValue(DataBaseType type, string dataType, bool IsNull)
        {
            string Value = "";
            if (IsNull)
            {
                Value = "null";
            }
            else if (type == DataBaseType.Oracle)
            {
                switch (dataType)
                {
                    case "int":
                        Value = "0";
                        break;
                    case "nvarchar":
                        Value = "\"\"";
                        break;
                    case "xml":
                        Value = "\"\"";
                        break;
                }
            }
            else if (type == DataBaseType.MySql)
            {
                switch (dataType)
                {
                    case "int":
                        Value = "0";
                        break;
                    case "tinyint":
                        Value = "0";
                        break;
                    case "bigint":
                        Value = "0";
                        break;
                    case "char":
                        Value = "\"\"";
                        break;
                    case "nvarchar":
                        Value = "\"\"";
                        break;
                    case "bit":
                        Value = "false";
                        break;
                    case "varchar":
                        Value = "\"\"";
                        break;
                    case "datetime":
                        Value = "DateTime.Now";
                        break;
                    case "datetime2":
                        Value = "DateTime.Now";
                        break;
                    case "date":
                        Value = "DateTime.Now";
                        break;
                    case "text":
                        Value = "\"\"";
                        break;
                    case "decimal":
                        Value = "0";
                        break;
                    case "money":
                        Value = "0";
                        break;
                    case "float":
                        Value = "0";
                        break;
                    case "xml":
                        Value = "\"\"";
                        break;
                    case "uniqueidentifier":
                        Value = "\"\"";
                        break;
                }
            }
            else if (type == DataBaseType.MSSQL)
            {
                switch (dataType)
                {
                    case "int":
                        Value = "0";
                        break;
                    case "tinyint":
                        Value = "0";
                        break;
                    case "bigint":
                        Value = "0";
                        break;
                    case "money":
                        Value = "0";
                        break;
                    case "char":
                        Value = "\"\"";
                        break;
                    case "nvarchar":
                        Value = "\"\"";
                        break;
                    case "bit":
                        Value = "false";
                        break;
                    case "varchar":
                        Value = "\"\"";
                        break;
                    case "datetime":
                        Value = "DateTime.Now";
                        break;
                    case "datetime2":
                        Value = "DateTime.Now";
                        break;
                    case "date":
                        Value = "DateTime.Now";
                        break;
                    case "text":
                        Value = "\"\"";
                        break;
                    case "decimal":
                        Value = "0";
                        break;
                    case "float":
                        Value = "0";
                        break;
                    case "xml":
                        Value = "\"\"";
                        break;
                    case "uniqueidentifier":
                        Value = "varchar";
                        break;
                }
            }
            return Value;
        }
        public static string GetCodeType(string pdmDataType)
        {
            var datatype = pdmDataType;
            if (datatype.IndexOf("(") != -1)
            {
                datatype = datatype.Substring(0, datatype.IndexOf("("));
            }
            string codetype = "string";
            switch (datatype.ToLower().Replace("?", ""))
            {
                case "int":
                    codetype = "int";
                    break;
                case "tinyint":
                    codetype = "int";
                    break;
                case "bigint":
                    codetype = "long";
                    break;
                case "bit":
                    codetype = "bool";
                    break;
                case "uniqueidentifier":
                    codetype = "Guid";
                    break;
                case "datetime2":
                    codetype = "DateTime";
                    break;
                case "datetimeoffset":
                    codetype = "DateTime";
                    break;
                case "decimal":
                    codetype = "decimal";
                    break;
                case "money":
                    codetype = "decimal";
                    break;
                case "float":
                    codetype = "float";
                    break;
                case "datetime":
                    codetype = "DateTime";
                    break;
                case "date":
                    codetype = "DateTime";
                    break;
                case "char":
                    codetype = "string";
                    break;
                case "text":
                    codetype = "string";
                    break;
                case "varchar":
                    codetype = "string";
                    break;
                case "nvarchar":
                    codetype = "string";
                    break;

            }
            return codetype;
        }
        public static SearchType GetSearchType(string datatype)
        {
            datatype = datatype.IndexOf("(") != -1 ? datatype.Substring(0, datatype.IndexOf("(")) : datatype;
            SearchType searchtype = SearchType.Null;
            switch (datatype.ToLower().Replace("?", ""))
            {
                case "int":
                    searchtype = SearchType.Equal;
                    break;
                case "bigint":
                    searchtype = SearchType.Equal;
                    break;
                case "tinyint":
                    searchtype = SearchType.Equal;
                    break;
                case "bit":
                    searchtype = SearchType.Equal;
                    break;
                case "uniqueidentifier":
                    searchtype = SearchType.Equal;
                    break;
                case "datetime2":
                    searchtype = SearchType.Range;
                    break;
                case "datetimeoffset":
                    searchtype = SearchType.Null;
                    break;
                case "decimal":
                    searchtype = SearchType.Range;
                    break;
                case "money":
                    searchtype = SearchType.Range;
                    break;
                case "float":
                    searchtype = SearchType.Range;
                    break;
                case "datetime":
                    searchtype = SearchType.Range;
                    break;
                case "date":
                    searchtype = SearchType.Range;
                    break;
                case "char":
                    searchtype = SearchType.Like;
                    break;
                case "text":
                    searchtype = SearchType.Like;
                    break;
                case "varchar":
                    searchtype = SearchType.Like;
                    break;
                case "nvarchar":
                    searchtype = SearchType.Like;
                    break;
            }
            return searchtype;
        }
    }
}
