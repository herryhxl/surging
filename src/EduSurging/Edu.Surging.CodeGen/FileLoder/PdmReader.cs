using FileLoder.Helper;
using FileLoder.TemplateModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace FileLoder
{
    public class PdmReader
    {
        public static void WriteToExcel(string saveFilePath, List<TableModel> Table, UI.UpdateUi update, UI myUi)
        {
            ReportInfo minfo = new ReportInfo
            {
                Percent = 0,
                Message = "开始处理数据共选中【" + Table.Count + "】张数据表"
            };
            myUi.Invoke(update, minfo, null);

            minfo.Message = "开始构建Table数据";
            myUi.Invoke(update, minfo, null);

            DataTable mdatatable = new DataTable();
            mdatatable.Columns.Add("flag", Type.GetType("System.Int32"));
            mdatatable.Columns.Add("flagData", Type.GetType("System.String"));
            mdatatable.Columns.Add("序号", Type.GetType("System.Int32"));
            mdatatable.Columns.Add("字段名", Type.GetType("System.String"));
            mdatatable.Columns.Add("字段类型", Type.GetType("System.String"));
            mdatatable.Columns.Add("主外键标识", Type.GetType("System.String"));
            mdatatable.Columns.Add("是否为空", Type.GetType("System.String"));
            mdatatable.Columns.Add("C#属性名", Type.GetType("System.String"));
            mdatatable.Columns.Add("C#类型", Type.GetType("System.String"));
            mdatatable.Columns.Add("搜索类型", Type.GetType("System.String"));
            mdatatable.Columns.Add("是否排序", Type.GetType("System.String"));
            mdatatable.Columns.Add("中文描述", Type.GetType("System.String"));
            mdatatable.Columns.Add("备注", Type.GetType("System.String"));


            Table.ToList().ForEach(table =>
            {
                //DataRow _3dr = mdatatable.NewRow();
                //_3dr["flag"] = 4;
                //_3dr["flagData"] = table.Name;
                //mdatatable.Rows.Add(_3dr);
                DataRow _0Dr = mdatatable.NewRow();
                _0Dr["flag"] = 0;
                _0Dr["flagData"] = (table.Comment == null || table.Comment.Trim() == "") ? "【表名：" + table.Code + "】" : table.Comment + "【表名：" + table.Code + "】";
                mdatatable.Rows.Add(_0Dr);

                DataRow _2dr = mdatatable.NewRow();
                _2dr["flag"] = -2;
                _2dr["flagData"] = "数据库描述" + "#" + "代码描述";
                mdatatable.Rows.Add(_2dr);



                DataRow dr1 = mdatatable.NewRow();
                dr1["flag"] = 1;

                dr1["序号"] = "10";
                dr1["字段名"] = "25";
                dr1["字段类型"] = "25";
                dr1["主外键标识"] = "10";
                dr1["是否为空"] = "10";
                dr1["C#属性名"] = "30";
                dr1["C#类型"] = "30";

                dr1["搜索类型"] = "10";
                dr1["是否排序"] = "8";
                dr1["中文描述"] = "30";
                dr1["备注"] = "40";
                mdatatable.Rows.Add(dr1);

                var data = table.ColumnsList.OrderBy(t => t.Virtual).ToList();
                for (int i = 0; i < data.Count; i++)
                {
                    var Column = data[i];
                    DataRow dr = mdatatable.NewRow();
                    dr["flag"] = 2;
                    dr["备注"] = Column.Name;
                    dr["序号"] = i + 1;
                    dr["字段类型"] = Column.DataType;
                    dr["主外键标识"] = Column.PK == true ? "PK" : Column.FK == true ? "FK" : "";
                    dr["是否为空"] = Column.IsNull ? "1" : "0";
                    if (Column.FK)
                    {
                        dr["字段名"] = Column.Code;
                        dr["C#属性名"] = Column.FKTable;
                        if (Column.IsNull)
                            dr["C#类型"] = Column.FKTable + "?";
                        else
                            dr["C#类型"] = Column.FKTable;
                        if (Column.PK) dr["是否排序"] = "1";
                        else dr["是否排序"] = "0";
                    }
                    else if (Column.Virtual)
                    {
                        dr["C#属性名"] = Column.Code;
                        dr["C#类型"] = Column.DataType;
                        dr["是否排序"] = "0";
                    }
                    else
                    {
                        dr["字段名"] = Column.Code;
                        dr["C#属性名"] = Column.Code;
                        dr["C#类型"] = Column.CodeType;
                        if (Column.PK)
                        {
                            dr["是否排序"] = "1";
                        }
                        else
                        {
                            dr["是否排序"] = Column.OrderBy ? "1" : "0";
                        }
                        dr["搜索类型"] = Column.Search;
                        dr["备注"] = Column.Remark;
                    }
                    dr["中文描述"] = Column.Comment;
                    mdatatable.Rows.Add(dr);
                }
                DataRow _4dr = mdatatable.NewRow();
                _4dr["flag"] = 4;
                _4dr["flagData"] = table.Code;
                mdatatable.Rows.Add(_4dr);
            });

            minfo.Message = "构建数据成功，开始生成Excel文件";
            minfo.Percent += 5;
            myUi.Invoke(update, minfo, null);

            Excel.ToExcelFile(mdatatable, saveFilePath, new string[] { }, new[] { "字段名", "字段类型", "C#属性名", "C#类型", "中文描述", "备注" }, update, myUi);
        }
        public static List<TableModel> Load(string dpmfilepath, string[] AddField = null)
        {
            List<TableModel> table = new List<TableModel>();
            List<ReferenceModel> reference = new List<ReferenceModel>();
            List<KeysModel> keysModelList = new List<KeysModel>();
            List<PrimaryKeyModel> primaryKeyList = new List<PrimaryKeyModel>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(dpmfilepath);
            XmlNode models = xmlDoc.SelectSingleNode("Model");
            if (models != null)
            {
                //var trs = models.ChildNodes;
                //foreach (XmlNode item in trs)
                //{
                //    foreach (XmlNode item2 in item.ChildNodes)
                //    {
                //        foreach (XmlNode item3 in item2.ChildNodes)
                //        {
                //            foreach (XmlNode item4 in item3.ChildNodes)
                //            {

                //            }
                //        }
                //    }
                //}
                var data = models.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes;
                foreach (XmlNode item4 in data)
                {
                    if (item4.LocalName == "References")
                    {
                        foreach (XmlNode item5 in item4.ChildNodes)
                        {
                            ReferenceModel referenceModel = new ReferenceModel();
                            foreach (XmlNode r3 in item5.Attributes)
                            {
                                //Console.WriteLine(string.Format("{0},{1}", r3.Name, r3.Value));
                                if (r3.Name == "Id") referenceModel.Id = r3.Value;
                            }
                            //Console.WriteLine(string.Format("名称：{0}:内容{1}", item5.LocalName, item5.InnerText));
                            foreach (XmlNode item6 in item5.ChildNodes)
                            {
                                if (item6.LocalName == "ParentTable")
                                {
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        foreach (XmlNode item8 in item7.Attributes)
                                        {
                                            if (item8.Name == "Ref") referenceModel.ParentTable = item8.Value;
                                        }
                                    }
                                }
                                else if (item6.LocalName == "ChildTable")
                                {
                                    //Console.WriteLine(string.Format("{0}", item6.LocalName));
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        foreach (XmlNode item8 in item7.Attributes)
                                        {
                                            //Console.WriteLine(string.Format("{0}:{1}", item8.Name, item8.Value));
                                            if (item8.Name == "Ref") referenceModel.ChildTable = item8.Value;
                                        }
                                    }
                                }
                                else if (item6.LocalName == "ParentKey")
                                {
                                    //Console.WriteLine(string.Format("{0}", item6.LocalName));
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        foreach (XmlNode item8 in item7.Attributes)
                                        {
                                            //Console.WriteLine(string.Format("{0}:{1}", item8.LocalName, item8.InnerText));
                                            if (item8.Name == "Ref") referenceModel.ParentKey = item8.Value;
                                        }
                                    }
                                }
                                else if (item6.LocalName == "Joins")
                                {
                                    //Console.WriteLine(string.Format("{0}", item6.LocalName));
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        foreach (XmlNode item8 in item7.ChildNodes)
                                        {
                                            if (item8.LocalName == "Object1")
                                            {
                                                foreach (XmlNode item9 in item8.ChildNodes)
                                                {
                                                    foreach (XmlNode item10 in item9.Attributes)
                                                    {
                                                        //Console.WriteLine(string.Format("{0}:{1}", item8.LocalName, item8.InnerText));
                                                        if (item10.Name == "Ref") referenceModel.Object1 = item10.Value;
                                                    }
                                                }

                                            }
                                            else if (item8.LocalName == "Object2")
                                            {
                                                foreach (XmlNode item9 in item8.ChildNodes)
                                                {
                                                    foreach (XmlNode item10 in item9.Attributes)
                                                    {
                                                        //Console.WriteLine(string.Format("{0}:{1}", item8.LocalName, item8.InnerText));
                                                        if (item10.Name == "Ref") referenceModel.Object2 = item10.Value;
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    //if (item6.LocalName != "CreationDate" && item6.LocalName != "Creator" && item6.LocalName != "ModificationDate" && item6.LocalName != "Modifier" && item6.LocalName != "TotalSavingCurrency" && item6.LocalName != "Cardinality" && item6.LocalName != "UpdateConstraint" && item6.LocalName != "DeleteConstraint")
                                    //{
                                    //    Console.WriteLine(string.Format("{0}:{1}", item6.LocalName, item6.InnerText));
                                    //}
                                    if (item6.LocalName == "Name") referenceModel.Name = item6.InnerText;
                                    else if (item6.LocalName == "Code") referenceModel.Code = item6.InnerText;
                                    else if (item6.LocalName == "ObjectID") referenceModel.ObjectID = item6.InnerText;
                                    else if (item6.LocalName == "Comment")
                                    {
                                        referenceModel.Comment = item6.InnerText;
                                        if (item6.InnerText != null && item6.InnerText.Trim() == "1")
                                            referenceModel.One = true;
                                    }
                                }
                            }
                            reference.Add(referenceModel);
                        }
                    }
                    else if (item4.LocalName == "Tables")
                    {
                        foreach (XmlNode item5 in item4.ChildNodes)
                        {
                            TableModel tabModel = new TableModel();
                            foreach (XmlNode r3 in item5.Attributes)
                            {
                                //Console.WriteLine(string.Format("{0},{1}", r3.Name, r3.Value));
                                if (r3.Name == "Id") tabModel.Id = r3.Value;
                            }
                            //Console.WriteLine(string.Format("名称：{0}:内容{1}", item5.LocalName, item5.InnerText));
                            foreach (XmlNode item6 in item5.ChildNodes)
                            {
                                if (item6.LocalName == "Columns")
                                {
                                    List<ColumnsModel> columns = new List<ColumnsModel>();
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        ColumnsModel columnsModel = new ColumnsModel();
                                        foreach (XmlNode r3 in item7.Attributes)
                                        {
                                            //Console.WriteLine(string.Format("{0},{1}", r3.Name, r3.Value));
                                            if (r3.Name == "Id") columnsModel.Id = r3.Value;
                                        }
                                        foreach (XmlNode item8 in item7.ChildNodes)
                                        {
                                            //if (item8.LocalName != "CreationDate" && item8.LocalName != "Creator" && item8.LocalName != "ModificationDate" && item8.LocalName != "Modifier" && item8.LocalName != "TotalSavingCurrency")
                                            //Console.WriteLine(string.Format("{0}:{1}", item8.LocalName, item8.InnerText));
                                            if (item8.LocalName == "Name") columnsModel.Name = item8.InnerText;
                                            if (item8.LocalName == "Code") columnsModel.Code = item8.InnerText;
                                            if (item8.LocalName == "ObjectID") columnsModel.ObjectID = item8.InnerText;
                                            if (item8.LocalName == "Comment")
                                            {
                                                columnsModel.Comment = item8.InnerText;
                                                if (item8.InnerText.Trim() != "")
                                                {
                                                    List<EnumValueModel> model = new List<EnumValueModel>();
                                                    string[] arr = item8.InnerText.Replace(" ", "").Split(new char[] { ',', '，' });
                                                    Array.ForEach(arr, t =>
                                                    {
                                                        string[] a = t.Split(new char[] { ':', '：' });
                                                        if (a.Length == 2)
                                                        {
                                                            var startStr = a[0];
                                                            int attribute;
                                                            var result = a[1];
                                                            if (int.TryParse(startStr, out attribute) && result != "")
                                                            {
                                                                EnumValueModel mo = new EnumValueModel
                                                                {
                                                                    Attribute = attribute
                                                                };
                                                                var charstr = result.Substring(0, 1);//判断枚举字符串第一个字母是否为数字
                                                                int beginNumber;
                                                                if (int.TryParse(charstr, out beginNumber))
                                                                    mo.Description = "_" + result.Replace("-", "_");
                                                                else
                                                                    mo.Description = result;
                                                                //去除重复的项目
                                                                if (model.All(r => r.Attribute != mo.Attribute) && model.All(r => r.Description != mo.Description))
                                                                    model.Add(mo);
                                                            }
                                                        }
                                                    });
                                                    if (model.Any())
                                                    {
                                                        columnsModel.EM = true;
                                                        columnsModel.EmodelList = model;
                                                    }
                                                }
                                            }

                                            if (item8.LocalName == "DataType")
                                            {
                                                var text = item8.InnerText.ToLower();
                                                string DataType = text.Replace("[", "(").Replace("]", ")");
                                                columnsModel.IsNull = DataType.IndexOf("?") != -1;
                                                columnsModel.DataType = DataType;

                                                columnsModel.Search = Helper.Helper.GetSearchType(DataType);
                                                columnsModel.CodeType = Helper.Helper.GetCodeType(DataType);

                                                if (columnsModel.IsNull)
                                                {
                                                    if (columnsModel.CodeType != "string") columnsModel.C_CodeType = columnsModel.CodeType + "?";
                                                    else columnsModel.C_CodeType = columnsModel.CodeType;
                                                }
                                                else
                                                    columnsModel.C_CodeType = columnsModel.CodeType;

                                                if (columnsModel.CodeType == "DateTime" || columnsModel.CodeType == "decimal"
                                                    || columnsModel.CodeType == "int" || columnsModel.CodeType == "long" || columnsModel.CodeType == "float")
                                                {
                                                    columnsModel.OrderBy = true;
                                                }
                                            }
                                            if (item8.LocalName == "Length") columnsModel.Length = Convert.ToInt32(item8.InnerText.Trim());
                                        }
                                        if (columnsModel.IsXML)
                                        {
                                            if (columnsModel.Comment != null && columnsModel.Comment.Trim() != "")
                                            {
                                                if (columnsModel.Comment.StartsWith("1"))
                                                    columnsModel.XMLMany = false;
                                                else if (columnsModel.Comment.StartsWith("n"))
                                                    columnsModel.XMLMany = true;
                                                string con = columnsModel.Comment.Substring(1);
                                                List<XmlModel> mo = JsonConvert.DeserializeObject<List<XmlModel>>(con);
                                                mo.ForEach(r =>
                                                {
                                                    var text = r.DataType.ToLower();
                                                    r.DataType = text.Replace("[", "(").Replace("]", ")");
                                                    r.CodeType = Helper.Helper.GetCodeType(r.DataType);
                                                });
                                                columnsModel.XModel = mo;
                                            }
                                        }
                                        columns.Add(columnsModel);
                                    }
                                    tabModel.ColumnsList = columns;
                                }
                                else if (item6.LocalName == "Keys")
                                {
                                    List<KeysModel> keys = new List<KeysModel>();
                                    //Console.WriteLine(string.Format("{0}:{1}", item6.LocalName, item6.InnerText));
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        KeysModel keysModel = new KeysModel();
                                        foreach (XmlNode r3 in item7.Attributes)
                                        {
                                            //Console.WriteLine(string.Format("{0},{1}", r3.Name, r3.Value));
                                            if (r3.Name == "Id") keysModel.Id = r3.Value;
                                        }
                                        foreach (XmlNode item8 in item7.ChildNodes)
                                        {
                                            //if (item8.LocalName != "CreationDate" && item8.LocalName != "Creator" && item8.LocalName != "ModificationDate" && item8.LocalName != "Modifier" && item8.LocalName != "TotalSavingCurrency")
                                            //    Console.WriteLine(string.Format("{0}:{1}", item8.LocalName, item8.InnerText));

                                            if (item8.HasChildNodes)
                                            {
                                                foreach (XmlNode item9 in item8.ChildNodes)
                                                {
                                                    //if (item9.LocalName != "CreationDate" && item9.LocalName != "Creator" && item9.LocalName != "ModificationDate" && item9.LocalName != "Modifier" && item9.LocalName != "TotalSavingCurrency" && item9.LocalName != "#text")
                                                    //    Console.WriteLine(string.Format("{0}:{1}", item9.LocalName, item9.InnerText));
                                                    if (item9.Attributes != null)
                                                    {
                                                        List<RefModel> listRefModel = new List<RefModel>();
                                                        foreach (XmlNode r3 in item9.Attributes)
                                                        {
                                                            RefModel refModel = new RefModel();
                                                            //Console.WriteLine(string.Format("{0},{1}", r3.Name, r3.Value));
                                                            if (r3.Name == "Ref") refModel.Ref = r3.Value;
                                                            listRefModel.Add(refModel);
                                                        }
                                                        keysModel.ColumnKey = listRefModel;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (item8.LocalName == "Name") keysModel.Name = item8.InnerText;
                                                if (item8.LocalName == "ObjectID") keysModel.ObjectID = item8.InnerText;
                                                if (item8.LocalName == "Code") keysModel.Code = item8.InnerText;
                                            }

                                        }
                                        keys.Add(keysModel);
                                    }
                                    //tabModel.KeysModelList = Keys;
                                    keysModelList.AddRange(keys);
                                }
                                else if (item6.LocalName == "PrimaryKey")
                                {
                                    List<PrimaryKeyModel> primaryKeyModelList = new List<PrimaryKeyModel>();
                                    //Console.WriteLine(string.Format("{0}:{1}", item6.LocalName, item6.InnerText));
                                    foreach (XmlNode item7 in item6.ChildNodes)
                                    {
                                        foreach (XmlNode r3 in item7.Attributes)
                                        {
                                            PrimaryKeyModel primaryKeyModel = new PrimaryKeyModel();
                                            //Console.WriteLine(string.Format("{0},{1}", r3.Name, r3.Value));
                                            if (r3.Name == "Ref") primaryKeyModel.Ref = r3.Value;
                                            primaryKeyModelList.Add(primaryKeyModel);
                                        }
                                    }
                                    //tabModel.PrimaryKey = PrimaryKeyModelList;
                                    primaryKeyList.AddRange(primaryKeyModelList);
                                }
                                else
                                {
                                    //if (item6.LocalName != "CreationDate" && item6.LocalName != "Creator" && item6.LocalName != "ModificationDate" && item6.LocalName != "Modifier" && item6.LocalName != "TotalSavingCurrency")
                                    //{
                                    //    Console.WriteLine(string.Format("{0}:{1}", item6.LocalName, item6.InnerText));
                                    //}
                                    if (item6.LocalName == "Name") tabModel.Name = item6.InnerText;
                                    if (item6.LocalName == "Code") tabModel.Code = item6.InnerText;
                                    if (item6.LocalName == "ObjectID") tabModel.ObjectID = item6.InnerText;
                                    if (item6.LocalName == "Comment") tabModel.Comment = item6.InnerText;
                                }
                                //foreach (var r3 in item5.Attributes)
                                //{
                                //    Console.WriteLine(string.Format("{0},{1}", r3, item5.Attributes[r3.ToString()].Value));
                                //}

                            }
                            table.Add(tabModel);
                        }
                    }
                }
            }

            table = table.Where(t => t.ColumnsList != null && t.ColumnsList.Any()).ToList();
            primaryKeyList.ForEach(item =>
            {
                var id = item.Ref;
                var key = keysModelList.SingleOrDefault(t => t.Id == id);
                if (key != null && key.ColumnKey != null)
                {
                    var firstOrDefault = key?.ColumnKey.FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        var col = firstOrDefault.Ref;
                        var tab = table.SingleOrDefault(t => t.ColumnsList != null && t.ColumnsList.Any(r => r.Id == col));

                        var colons = tab?.ColumnsList.SingleOrDefault(t => t.Id == col);
                        if (colons != null)
                        {
                            colons.PK = true;
                            colons.OrderBy = true;
                            colons.Search = EnumSearchType.In;
                        }
                    }
                }
            });
            Dictionary<int, List<string>> str = new Dictionary<int, List<string>>();
            int mm = 0;
            reference.ForEach(item =>
            {
                var parent = item.ParentTable;//TableID
                var child = item.ChildTable;//TableID
                var object1 = item.Object1;
                var object2 = item.Object2;
                var one = item.One;
                if (object1 == null || object2 == null) return;
                var parentTable = table.SingleOrDefault(t => t.Id == parent);
                var childTable = table.SingleOrDefault(t => t.Id == child);
                int P = -1;
                if (parentTable != null && childTable != null)
                {
                    if (str.Any())
                    {
                        int c = -1;
                        foreach (int i in str.Keys)
                        {
                            var data = str[i];
                            if (data.Contains(parentTable.Code)) P = i;
                            if (data.Contains(childTable.Code)) c = i;
                            if (P != -1 && c != -1) break;
                        }
                        if (P == -1 && c == -1)
                            str.Add(mm++, new List<string> { parentTable.Code, childTable.Code });
                        else if (P != -1 && c != -1)
                        {
                            if (P != c)
                            {
                                str[c].AddRange(str[P]);
                                str.Remove(P);
                            }
                        }
                        else if (P != -1)
                            str[P].Add(childTable.Code);
                        else
                            str[c].Add(parentTable.Code);
                    }
                    else
                        str.Add(mm++, new List<string> { parentTable.Code, childTable.Code });
                }
                if (childTable == null) return;
                {
                    var childCon = childTable.ColumnsList.SingleOrDefault(t => t.Id == object2);
                    var parentCon = parentTable.ColumnsList.SingleOrDefault(t => t.Id == object1);
                    if (childCon != null)
                    {
                        childCon.FKCode = parentCon.Code;
                        parentCon.FKCode = childCon.Code;
                        childCon.FK = true;
                        childCon.One = one;
                        childCon.Search = EnumSearchType.In;
                        if (parentTable != null)
                        {
                            childCon.FKTable = parentTable.Code + "Entity";
                            //parentCon.FKTable= childTable.Code + "Entity";
                            childCon.OrderBy = true;
                            if (childCon.PK)
                            {
                                childCon.OrderBy = true;
                                childTable.ColumnsList.Add(new ColumnsModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Virtual = true,
                                    IsNull = false,
                                    DataType = parentTable.Code,
                                    CodeType = parentTable.Code + "Entity",
                                    Code = childCon.Code + "_" + parentTable.Code,
                                    Name = childTable.Comment + "关联" + parentTable.Comment,
                                    FKCode = parentCon.Code,
                                    FKTable= parentTable.Code + "Entity",
                                    PK =true,
                                    FK = true
                                });
                                parentTable.ColumnsList.Add(new ColumnsModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Virtual = true,
                                    IsNull = false,
                                    DataType = childTable.Code,
                                    CodeType = childTable.Code + "Entity",
                                    Code = parentCon.Code + "_" + childTable.Code,
                                    Name = parentTable.Comment + "关联" + childTable.Comment,
                                    FKCode = childCon.Code,
                                    FKTable = childTable.Code + "Entity",
                                    PK = true,
                                    FK = true
                                });
                            }
                            else
                            {
                                childTable.ColumnsList.Add(new ColumnsModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Virtual = true,
                                    IsNull = true,
                                    DataType = parentTable.Code,
                                    CodeType = parentTable.Code + "Entity",
                                    Code = childCon.Code + "_" + parentTable.Code,
                                    Name = childTable.Comment + "关联" + parentTable.Comment,
                                    FKCode = parentCon.Code,
                                    FKTable= parentTable.Code + "Entity"
                                });
                                parentTable.ColumnsList.Add(new ColumnsModel
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Virtual = true,
                                    IsNull = true,
                                    DataType = "IList<" + childTable.Code + "Entity" + ">",
                                    Code = childCon.Code + "_" + childTable.Code + "List",
                                    Name = parentTable.Comment + "关联" + childTable.Comment + "List",
                                    CodeType = "IList<" + childTable.Code + "Entity" + ">",
                                    FKCode = parentCon.Code,
                                    FKTable= childTable.Code + "Entity"
                                });
                            }
                        }
                    }
                }
            });
            int p = 0;
            foreach (int i in str.Keys)
            {
                p++;
                str[i].ForEach(r =>
                {
                    var m = table.SingleOrDefault(t => t.Code == r);
                    if (m != null) m.DataBaseName = "" + p;
                });
            }
            if (AddField != null)
            {
                //增加四个字段
                //1：添加时间,AddTime，2、更新时间UpTime，3.添加用户AddUser，4、更新用户UpUser
                var List = new List<ColumnsModel>();
                if (AddField.Contains("AddTime"))
                {
                    List.Add(new ColumnsModel
                    {
                        Code = "AddTime",
                        CodeType = "DateTime",
                        Comment = "添加时间",
                        C_CodeType = "DateTime",
                        DataType = "datetime",
                        EM = false,
                        FK = false,
                        Id = Guid.NewGuid().ToString(),
                        IsNull = false,
                        Name = "添加时间",
                        OrderBy = true,
                        Search = EnumSearchType.Range
                    });
                }
                if (AddField.Contains("UpTime"))
                {
                    List.Add(new ColumnsModel
                    {
                        Code = "UpTime",
                        CodeType = "DateTime",
                        Comment = "更新时间",
                        C_CodeType = "DateTime",
                        DataType = "datetime",
                        EM = false,
                        FK = false,
                        Id = Guid.NewGuid().ToString(),
                        IsNull = false,
                        Name = "更新时间",
                        OrderBy = true,
                        Search = EnumSearchType.Range
                    });
                }
                if (AddField.Contains("AddUser"))
                {
                    List.Add(new ColumnsModel
                    {
                        Code = "AddUser",
                        CodeType = "int",
                        Comment = "添加用户",
                        C_CodeType = "int?",
                        DataType = "int",
                        EM = false,
                        FK = false,
                        Id = Guid.NewGuid().ToString(),
                        IsNull = true,
                        Name = "添加用户",
                        OrderBy = true,
                        Search = EnumSearchType.Equal
                    });
                }
                if (AddField.Contains("UpUser"))
                {
                    List.Add(new ColumnsModel
                    {
                        Code = "UpUser",
                        CodeType = "int",
                        Comment = "更新用户",
                        C_CodeType = "int?",
                        DataType = "int",
                        EM = false,
                        FK = false,
                        Id = Guid.NewGuid().ToString(),
                        IsNull = true,
                        Name = "更新用户",
                        OrderBy = true,
                        Search = EnumSearchType.Equal
                    });
                }
                if (AddField.Contains("LogID"))
                {
                    List.Add(new ColumnsModel
                    {
                        Code = "LogID",
                        CodeType = "int",
                        Comment = "日志",
                        C_CodeType = "int?",
                        DataType = "int?",
                        EM = false,
                        FK = false,
                        Id = Guid.NewGuid().ToString(),
                        IsNull = true,
                        Name = "日志",
                        OrderBy = true,
                        Search = EnumSearchType.Equal
                    });
                }
                if (List.Any())
                {
                    table.ForEach(item =>
                    {
                        foreach (var child in List)
                        {
                            if (!item.ColumnsList.Any(t => t.Code == child.Code))
                                item.ColumnsList.Add(child);
                        }
                    });
                }
            };
            return table.OrderBy(t => t.Code).ToList();
        }
        public static string FindTop(TableModel model, List<TableModel> tablist)
        {
            if (model.DataBaseName != null) return model.DataBaseName;
            else
            {
                var fkTable = model.ColumnsList.Where(t => t.FK).Select(t => new { t.FKTable, t.Code }).FirstOrDefault();
                if (fkTable == null)
                    return model.Code;
                else
                {
                    TableModel mo = tablist.FirstOrDefault(t => t.Code == fkTable.FKTable.Replace("Entity", ""));
                    if (mo != null && mo.Code != model.Code)
                        return FindTop(mo, tablist);
                    else if (mo != null) return mo.Code;
                    else
                        return "";
                }
            }
        }

        public static bool CreateCodeFiles(CodePara code, UI.UpdateUi update, UI myUi)
        {
            var fi = new NewFileFactory(code, update, myUi);
            fi.WriteFile(code);
            return true;
        }
    }
}
