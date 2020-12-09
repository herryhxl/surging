using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoder
{
    public class Excel
    {
        public static void ToExcelFile(DataTable dt, string filepath, string[] RightText, string[] LeftText, Main.UpdateUi Update, Main MyUI)
        {
            ReportInfo minfo = new ReportInfo
            {
                Percent = 5,
                Message = "构建Excel样式，准备相关数据"
            };
            MyUI.Invoke(Update, minfo, null);

            var workbook = new Workbook();
            Cells cells = null;
            //为标题设置样式     
            Style styleTitle = workbook.Styles[workbook.Styles.Add()];//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 15;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 


            //为标题设置样式     
            Style styleTitle2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            styleTitle2.HorizontalAlignment = TextAlignmentType.Right;
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 12;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 14;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 10;//文字大小 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式4 
            Style rstyle = workbook.Styles[workbook.Styles.Add()];//新增样式 
            rstyle.HorizontalAlignment = TextAlignmentType.Right;
            rstyle.Font.Name = "宋体";//文字字体 
            rstyle.Font.Size = 10;//文字大小
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = false;//单元格内容自动换行
            rstyle.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            rstyle.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            rstyle.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            rstyle.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Style lstyle = workbook.Styles[workbook.Styles.Add()];//新增样式 
            lstyle.HorizontalAlignment = TextAlignmentType.Left;//文字居左 
            lstyle.Font.Name = "宋体";//文字字体 
            lstyle.Font.Size = 10;//文字大小 
            lstyle.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            lstyle.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            lstyle.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            lstyle.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int colnum = dt.Columns.Count;//表格列数 
            int rownum = dt.Rows.Count;//表格行数 
            int sheetIndex = 0;
            int offset = 0;
            Worksheet sheet = null; //工作表
            minfo.Message = "构建完成，准备生成......";
            minfo.Percent += 5;
            MyUI.Invoke(Update, minfo, null);

            double p = 90.00 / dt.Rows.Count;

            //int excelCOunt = 1;
            var flag = true;

            for (int i = 0; i < rownum; i++)
            {
                minfo.Message = null;
                minfo.Percent += p;
                MyUI.Invoke(Update, minfo, null);

                DataRow row = dt.Rows[i];
                if (dt.Columns.Contains("flag"))
                {
                    if (row["flag"].ToString() == "0")//Title
                    {
                        var title = row["flagData"].ToString();
                        if (sheetIndex == 0)
                        {
                            sheet = workbook.Worksheets[sheetIndex]; //工作表
                            minfo.Message = "开始构建【" + title + "】的sheetbook";
                            MyUI.Invoke(Update, minfo, null);
                        }
                        else
                        {
                            sheet = workbook.Worksheets.Add(sheetIndex + "");// +"_"+ i 
                            minfo.Message = "开始构建【" + title + "】的sheetbook";
                            MyUI.Invoke(Update, minfo, null);
                        }
                        offset = i;
                        sheet.AutoFitColumns();//自适应列宽
                                               //sheet.Name = Title;
                        cells = sheet.Cells;//单元格 
                                            //生成行1 标题行    
                        cells.Merge(i - offset, 0, 1, colnum - 2);//合并单元格 
                        cells[i - offset, 0].PutValue(title);//填写内容 
                        cells[i - offset, 0].SetStyle(styleTitle);
                        cells.SetRowHeight(0, 38);
                        sheetIndex++;
                    }
                    else if (row["flag"].ToString() == "4")//Title
                    {
                        //sheet.Name = sheetIndex + i + "";//row["flagData"].ToString().Length>7? row["flagData"].ToString().Substring(0,7)+ sheetIndex+i : row["flagData"].ToString();
                    }
                    else if (row["flag"].ToString() == "-1")//Title
                    {
                        //生成行1 标题行    
                        cells.Merge(i - offset, 0, 1, colnum - 2);//合并单元格 
                        cells[i - offset, 0].PutValue(row["flagData"]);//填写内容 
                        cells[i - offset, 0].SetStyle(styleTitle2);
                        cells.SetRowHeight(0, 30);
                    }
                    else if (row["flag"].ToString() == "-2")//Title
                    {
                        string[] str = row["flagData"].ToString().Split(new char[] { '#' });
                        //生成行1 标题行    
                        cells.Merge(i - offset, 0, 1, (colnum - 2) / 2);//合并单元格
                        cells.Merge(i - offset, (colnum - 2) / 2, 1, (colnum - 2) / 2 + 1);//合并单元格
                        cells[i - offset, 0].PutValue(str[0]);//填写内容 
                        cells[i - offset, 0].SetStyle(styleTitle);
                        cells.SetRowHeight(0, 30);
                        cells[i - offset, (colnum - 2) / 2].PutValue(str[1]);//填写内容 
                        cells[i - offset, (colnum - 2) / 2].SetStyle(styleTitle);
                        cells.SetRowHeight(0, 30);
                    }
                    else if (row["flag"].ToString() == "1")
                    {
                        for (int j = 2; j < colnum; j++)
                        {
                            if (row[j] != null && row[j].ToString() != "")
                            {
                                try
                                {
                                    cells.SetColumnWidth(j - 2, Convert.ToInt32(row[j]));
                                }
                                catch { cells.SetColumnWidth(j - 2, 30); }
                            }
                            else cells.SetColumnWidth(j - 2, 30);
                            cells[i - offset, j - 2].PutValue(dt.Columns[j].ColumnName);
                            cells[i - offset, j - 2].SetStyle(style3);
                            cells.SetRowHeight(1, 25);
                        }
                    }
                    else if (row["flag"].ToString() == "3")
                    {
                        for (int j = 2; j < colnum; j++)
                        {
                            if (j == 2) cells[i, j - 2].PutValue(row["flagData"]);//填写内容
                            else
                            {
                                cells[i - offset, j - 2].PutValue(row[j]);
                                if (RightText.Contains(dt.Columns[j].ColumnName))
                                    cells[i - offset, j - 2].SetStyle(rstyle);
                                else cells[i - offset, j - 2].SetStyle(style3);
                            }
                        }
                    }
                    else
                    {
                        for (int j = 2; j < colnum; j++)
                        {
                            cells[i - offset, j - 2].PutValue(row[j]);
                            if (RightText.Contains(dt.Columns[j].ColumnName))
                                cells[i - offset, j - 2].SetStyle(rstyle);
                            else if (LeftText.Contains(dt.Columns[j].ColumnName))
                                cells[i - offset, j - 2].SetStyle(lstyle);
                            else cells[i - offset, j - 2].SetStyle(style3);
                        }
                    }
                }
                else
                {
                    if (flag)
                    {
                        sheet = workbook.Worksheets[sheetIndex];
                        sheet.AutoFitColumns();//自适应列宽
                        cells = sheet.Cells;//单元格 
                        cells.SetRowHeight(0, 38);
                        for (int r = 0; r < colnum; r++)
                        {
                            cells[0, r].PutValue(dt.Columns[r].ColumnName);
                        }
                        offset = -1;
                        flag = false;
                    }
                    for (int j = 0; j < colnum; j++)
                    {
                        if (row[j] != null)
                        {
                            cells[i - offset, j].PutValue(row[j]);
                            if (RightText.Contains(dt.Columns[j].ColumnName))
                                cells[i - offset, j].SetStyle(rstyle);
                            else if (LeftText.Contains(dt.Columns[j].ColumnName))
                                cells[i - offset, j].SetStyle(lstyle);
                            else cells[i - offset, j].SetStyle(style3);
                        }
                    }
                }
            }
            //string path = Path.GetFullPath("./" + filepath + "/");//
            //if (!System.IO.Directory.Exists(path))
            //{
            //    System.IO.Directory.CreateDirectory(path);
            //}
            //string fileName = Guid.NewGuid() + ".xls";
            //string newpath = path + fileName;
            FileInfo fi = new FileInfo(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            workbook.Save(filepath);
            //return filepath + fileName;
        }
    }
}
