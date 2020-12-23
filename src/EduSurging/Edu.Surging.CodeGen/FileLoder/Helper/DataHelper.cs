using FileLoder.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FileLoder.Helper
{
    public class DataHelper
    {

        public static List<string> GetDataBaseNameList(DataSourceInfo info)
        {
            var result = new List<string>();
            if (info.SqlType == DataBaseType.MySql)
            {
                string Sql = "select TABLE_SCHEMA as Source from COLUMNS where TABLE_SCHEMA <> 'information_schema' and TABLE_SCHEMA <> 'mysql' and TABLE_SCHEMA <> 'performance_schema' and TABLE_SCHEMA <> 'sys' group by TABLE_SCHEMA order by TABLE_SCHEMA asc";
                info.DataBaseName = "information_schema";

                DataSet set = GetTableData(info, Sql);
                if (set.Tables.Count > 0)
                {
                    foreach (DataRow item in set.Tables[0].Rows)
                    {
                        result.Add(item["Source"].ToString());
                    }
                }
            }
            else if (info.SqlType == DataBaseType.MSSQL)
            {
                info.DataBaseName = "master";
                string Sql = "SELECT name as Source from sysdatabases where name <>'master' and name <>'tempdb' and name <>'model' and name <>'msdb' and name <>'ReportServer' and name <>'ReportServerTempDB' order by name asc ";

                DataSet set = GetTableData(info, Sql);
                if (set.Tables.Count > 0)
                {
                    foreach (DataRow item in set.Tables[0].Rows)
                    {
                        result.Add(item["Source"].ToString());
                    }
                }
            }
            return result;
        }

        public static DataSet GetTableData(DataSourceInfo info, string SqlStr)
        {
            DataSet set = null;
            if (info.SqlType == DataBaseType.MySql)
                set = new MySqlDbHelper(info.Connect).Query(SqlStr);
            else if (info.SqlType == DataBaseType.MSSQL)
                set = new MsSqlDbHelper(info.Connect).Query(SqlStr);
            return set;
        }


        public static List<TableModel> GetData(Main.UpdateUi update, Main myUi, DataSourceInfo info)
        {
            var messageinfo = new ReportInfo { Message = "开始处理数据", Percent = 0 };
            myUi.Invoke(update, messageinfo, null);
            if (info.SqlType == DataBaseType.MySql)
            {
                messageinfo.Message = "开始获取MySql数据";
                messageinfo.Percent += 1;
                myUi.Invoke(update, messageinfo, null);
                string BeginDataBaseName = info.DataBaseName;
                info.DataBaseName = "information_schema";
                List<DataBaseInfo> dainfo = new List<DataBaseInfo>();
                string Sql = "select TABLE_SCHEMA as Source,TABLE_NAME as TaleName,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,COLUMN_NAME,COLUMN_KEY,COLUMN_COMMENT from COLUMNS where TABLE_SCHEMA <> 'information_schema' and TABLE_SCHEMA <> 'mysql' and TABLE_SCHEMA <> 'performance_schema' and TABLE_SCHEMA <> 'sys' "
                    + (string.IsNullOrWhiteSpace(BeginDataBaseName) ? "" : " and TABLE_SCHEMA='" + BeginDataBaseName + "'") + " order by TABLE_SCHEMA asc ";
                DataSet da = GetTableData(info, Sql);
                messageinfo.Message = "获取MySql数据成功，开始整理数据";
                messageinfo.Percent += 20;
                myUi.Invoke(update, messageinfo, null);

                DataTable tab = da.Tables[0];
                double other = 100 - messageinfo.Percent - 5;
                double tip = other / tab.Rows.Count;
                messageinfo.Message = "整理数据中......";
                foreach (DataRow item in tab.Rows)
                {
                    messageinfo.Percent += tip;
                    messageinfo.Message = null;
                    myUi.Invoke(update, messageinfo, null);
                    int length;
                    int.TryParse(item["CHARACTER_MAXIMUM_LENGTH"].ToString(), out length);
                    dainfo.Add(new DataBaseInfo
                    {
                        DataBaseName = item["Source"].ToString(),
                        TableName = item["TaleName"].ToString(),
                        DataType = item["DATA_TYPE"].ToString(),
                        IsNull = (item["IS_NULLABLE"].ToString() == "NO"),
                        Length = length,
                        ColName = item["COLUMN_NAME"].ToString(),
                        PK = (item["COLUMN_KEY"].ToString() == "PRI"),
                        Comment = item["COLUMN_COMMENT"].ToString()
                    });
                }
                messageinfo.Message = "整理完成，开始分组计算";
                messageinfo.Percent += 1;
                myUi.Invoke(update, messageinfo, null);

                List<TableModel> result = dainfo.GroupBy(t => new { t.DataBaseName, t.TableName }).Select(x => new TableModel
                {
                    DataBaseName = x.Key.DataBaseName,
                    Code = x.Key.TableName,
                    Id = Guid.NewGuid().ToString(),
                    Name = x.Key.TableName,
                    Comment = "",
                    Count = x.Count(),
                    ColumnsList = x.Select(t => new ColumnsModel
                    {
                        Code = t.ColName,
                        CodeType = "",
                        Comment = t.Comment,
                        DataType = t.DataType,
                        EM = false,
                        PK = t.PK,
                        Id = Guid.NewGuid().ToString(),
                        IsNull = t.IsNull,
                        Length = t.Length,
                        Name = t.Comment,
                        Search = Helper.GetSearchType(t.DataType),
                        OrderBy = t.PK
                    }).OrderBy(r => r.Code).ToList()
                }).ToList();//.OrderBy(r => r.Code)
                messageinfo.Message = "操作完成。";
                messageinfo.Percent += 100 - messageinfo.Percent;
                myUi.Invoke(update, messageinfo, null);
                return result;
            }
            else if (info.SqlType == DataBaseType.MSSQL)
            {
                messageinfo.Message = "开始获取MSSql数据库信息";
                messageinfo.Percent += 1;
                myUi.Invoke(update, messageinfo, null);
                string BeginDataBaseName = info.DataBaseName;
                info.DataBaseName = "master";

                List<TableModel> result = new List<TableModel>();
                string Sql = "SELECT name as Source from sysdatabases where name <>'master' and name <>'tempdb' and name <>'model' and name <>'msdb' and name <>'ReportServer' and name <>'ReportServerTempDB' "
                    + (string.IsNullOrWhiteSpace(BeginDataBaseName) ? "" : " and name='" + BeginDataBaseName + "'") + " order by name asc ";
                DataSet set = GetTableData(info, Sql);

                DataTable tab = set.Tables[0];
                messageinfo.Message = "数据库信息获取完成，共" + tab.Rows.Count + "个数据库";
                messageinfo.Percent += 4;
                myUi.Invoke(update, messageinfo, null);


                double per = 100 - messageinfo.Percent;
                double tip = (per / tab.Rows.Count);
                foreach (DataRow item in tab.Rows)
                {
                    messageinfo.Message = "开始获取" + item["Source"] + "数据库表信息";
                    messageinfo.Percent += 0;
                    myUi.Invoke(update, messageinfo, null);
                    Sql = "SELECT a.id,a.name,a.XType,a.parent_obj,b.value as Comment FROM SysObjects as a left outer join  sys.extended_properties as b on a.id=b.major_id and b.minor_id=0";

                    info.DataBaseName = item["Source"].ToString();
                    DataSet table = GetTableData(info, Sql);
                    DataTable tTab = table.Tables[0];

                    messageinfo.Message = "获取" + item["Source"] + "数据库表信息成功，开始整理数据";
                    messageinfo.Percent += tip / 3;
                    myUi.Invoke(update, messageinfo, null);

                    var da = new List<TableModel>();
                    foreach (DataRow item2 in tTab.Rows)
                    {
                        da.Add(new TableModel
                        {
                            DataBaseName = item["Source"].ToString(),
                            Name = item2["id"].ToString(),
                            Code = item2["name"].ToString(),
                            Id = item2["id"].ToString(),
                            XType = item2["XType"].ToString().Trim(),
                            Parent_Obj = item2["parent_obj"].ToString(),
                            Comment = item2["Comment"].ToString()
                        });
                    }
                    List<SysconstraintsModel> sysModel = new List<SysconstraintsModel>();
                    Sql = "SELECT id,colid,constid,b.column_id as column_id FROM Sysconstraints as a left join  sys.index_columns as b on a.id =b.object_id";
                    DataSet syscol = GetTableData(info, Sql);
                    DataTable syscolCol = syscol.Tables[0];
                    foreach (DataRow tCo in syscolCol.Rows)
                    {
                        sysModel.Add(new SysconstraintsModel
                        {
                            colid = tCo["colid"].ToString(),
                            constid = tCo["constid"].ToString(),
                            id = tCo["id"].ToString(),
                            column_id = tCo["column_id"].ToString()
                        });
                    }
                    messageinfo.Message = "开始获取" + item["Source"] + "所有表字段信息";
                    messageinfo.Percent += 0;
                    myUi.Invoke(update, messageinfo, null);
                    Sql = "SELECT id,colid,a.name,status,type_name(xtype) as data_type,length,isnullable,colstat,b.Value as Comment FROM Syscolumns as a left outer join  sys.extended_properties as b on a.id=b.major_id and a.colid=b.minor_id";
                    DataSet col = GetTableData(info, Sql);
                    DataTable tCol = col.Tables[0];
                    messageinfo.Message = item["Source"] + "表字段信息成功，开始整理数据[" + tCol.Rows.Count + "]";
                    messageinfo.Percent += tip / 3;
                    myUi.Invoke(update, messageinfo, null);
                    List<ColumnsModel> model = new List<ColumnsModel>();
                    foreach (DataRow tCo in tCol.Rows)
                    {
                        int length;
                        int.TryParse(tCo["length"].ToString(), out length);
                        var mycol = new ColumnsModel
                        {
                            Id = tCo["id"].ToString().Trim(),
                            Code = tCo["name"].ToString(),
                            DataType = tCo["data_type"].ToString(),
                            Length = length,
                            IsNull = tCo["isnullable"].ToString().Trim() == "1",
                            //PK= t_co["status"].ToString() == "128"
                            Colid = tCo["colid"].ToString(),
                            Comment = tCo["Comment"].ToString(),
                            IsAutoAdd = tCo["colstat"].ToString().Trim() == "1"
                        };
                        var pr = sysModel.Where(t => t.id == mycol.Id && t.column_id == mycol.Colid).ToList();//&& t.colid == t_co["colid"].ToString().Trim()
                        pr.ForEach(km =>
                        {
                            var te = da.FirstOrDefault(t => t.Id == km.constid && t.Parent_Obj == mycol.Id);
                            if (te?.XType != null && te.XType.Trim() == "PK")
                            {
                                mycol.PK = true;
                                mycol.OrderBy = true;
                            }
                            //if (lm.XType == "F")
                            //{


                            //}
                        });
                        model.Add(mycol);
                    }
                    da.Where(t => t.XType == "U").ToList().ForEach(rr =>
                    {
                        var data = model.Where(t => t.Id == rr.Id).ToList();
                        data.ForEach(r =>
                        {
                            r.Name = r.Comment;
                            r.CodeType = CodeType(r.DataType.ToLower(), r.IsNull);
                            r.Search = Helper.GetSearchType(r.DataType);
                            r.Id = Guid.NewGuid().ToString();
                        });
                        rr.DataBaseName = item["Source"].ToString();
                        rr.Id = Guid.NewGuid().ToString();
                        rr.Name = rr.Comment;
                        rr.ColumnsList = data.ToList();//.OrderBy(r => r.Code)
                        result.Add(rr);
                    });
                    messageinfo.Message = item["Source"] + "数据整理完成";
                    messageinfo.Percent += tip / 3;
                    myUi.Invoke(update, messageinfo, null);
                }
                messageinfo.Percent += 100 - messageinfo.Percent;
                messageinfo.Message = "处理完成";
                myUi.Invoke(update, messageinfo, null);
                return result.OrderBy(r => r.Code).ToList();
            }
            else
            {
                return null;
            }

        }
        public static string CodeType(string datype, bool isNull)
        {
            string result = Helper.GetCodeType(datype);
            if (isNull)
            {
                if (result != "string")
                    result += "?";
            }
            return result;
        }
    }
}
