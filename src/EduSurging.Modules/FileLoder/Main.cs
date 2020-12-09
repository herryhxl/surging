using FileLoder.DataAccess;
using FileLoder.Helper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace FileLoder
{
    public partial class Main : Form
    {
        List<TableModel> _tableList;
        DataSourceInfo _info;
        private static bool _isDataBase;
        public delegate void UpdateUi(ReportInfo info, string exception = null);
        private string _treeNodeSelect = "";
        private string _excelFilePath;
        private List<FileInfoMessage> _infoMessage;
        public Main()
        {
            InitializeComponent();
        }
        private void PowerDesignerFile_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            openFile.Filter = @"Dpm(.pdm)|*.pdm";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                if (filePath == null) throw new ArgumentNullException(nameof(filePath));
                try
                {
                    _tableList = PdmReader.Load(filePath, new string[] { "AddTime", "UpTime", "AddUser", "UpUser" });
                    _isDataBase = false;
                    LoadData(_tableList);
                    _info.SqlType = DataBaseType.MSSQL;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void XmlFile_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            openFile.Filter = @"Xml(.xml)|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                if (filePath == null) MessageBox.Show("文件路径为空");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                var membersNode = xmlDoc.SelectSingleNode("/doc/members");
                var listTableModel = new List<TableModel>();
                TableModel tableModel = null;
                foreach (XmlNode memberNode in membersNode.ChildNodes)
                {
                    if (memberNode.Attributes == null) continue;
                    var nameAttr = memberNode.Attributes["name"].Value;
                    if (nameAttr.StartsWith("T:"))
                    {
                        if (tableModel != null)
                        {
                            listTableModel.Add(tableModel);
                            tableModel = null;
                        }
                        var tableCode = nameAttr.Substring(nameAttr.LastIndexOf(".") + 1);
                        tableModel = new TableModel { Code = tableCode, ColumnsList = new List<ColumnsModel>() };
                        var summaryNodes = memberNode.SelectNodes("summary");
                        if (summaryNodes.Count >= 1)
                        {
                            tableModel.Name = summaryNodes[0].InnerText.Trim().Replace("\r\n", "");
                        }
                    }
                    else if (nameAttr.StartsWith("P:"))
                    {
                        var colCode = nameAttr.Substring(nameAttr.LastIndexOf(".") + 1);
                        if (tableModel != null)
                        {
                            var colModel = new ColumnsModel
                            {
                                Code = colCode
                            };
                            var summaryNodes = memberNode.SelectNodes("summary");
                            if (summaryNodes.Count >= 1)
                            {
                                colModel.Name = summaryNodes[0].InnerText.Trim().Replace("\r\n", "");
                            }
                            tableModel.ColumnsList.Add(colModel);
                        }
                    }
                }
                _tableList = listTableModel;
                _isDataBase = false;
                LoadData(_tableList);
            }
        }

        private void SaveExcel_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (_tableList == null)
            {
                MessageBox.Show(@"请先连接数据库或打开PowerDesiger设计文件");
                return;
            }
            saveFileDialog1.Filter = @"Excel(.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filePath = saveFileDialog1.FileName;
                var tag = SearchSelected();
                if (!tag.Any())
                {
                    MessageBox.Show(@"请选择需要生成的表");
                }
                else
                {
                    var excelCode = new CodePara
                    {
                        Type = ExcelType.数据库结构,
                        TableList = _tableList,
                        Tag = tag,
                        Option = new SaveOptions { OutPath = filePath }
                    };
                    Excel_Worker.RunWorkerAsync(excelCode);
                }
            }
        }
        //只搜索第二级
        private List<string> SearchSelected()
        {
            var str = new List<string>();
            foreach (TreeNode r in dpm_TreeView.Nodes)
            {
                //if (r.Checked && r.Tag.ToString() != "-1")
                //{
                //    str.Add(r.Tag.ToString());
                //}
                FindBySelected(r, str);
            }
            return str;
        }
        private void FindBySelected(TreeNode t, List<string> str)
        {
            foreach (TreeNode r in t.Nodes)
            {
                if (r.Checked && r.Tag.ToString() != "-1")
                {
                    str.Add(r.Tag.ToString());
                }
                //FindBySelected(r, str);
            }
        }


        private TreeNode Search(string tag)
        {
            TreeNode result = null;
            foreach (TreeNode r in dpm_TreeView.Nodes)
            {
                result = FindByTag(r, tag);
                if (result != null) break;
            }
            return result;
        }

        private TreeNode FindByTag(TreeNode t, string tag)
        {
            TreeNode result = null;
            foreach (TreeNode r in t.Nodes)
            {
                if (r.Tag != null && r.Tag.ToString() == tag)
                {
                    result = r;
                    break;
                }
                else
                {
                    result = FindByTag(r, tag);
                    if (result != null) break;
                }
            }
            return result;
        }

        private void LoadData(List<TableModel> mdata)
        {
            dpm_TreeView.Nodes.Clear();
            var r = mdata.GroupBy(t => t.DataBaseName).Select(x => new
            {
                Top = x.Key,
                Table = x.ToList(),
                Count = x.Count()
            });
            r.ToList().ForEach(tab =>
            {
                string topstr = tab.Top;
                if (!_isDataBase)
                {
                    var top = tab.Table.Where(c => (c.ColumnsList.All(g => g.FK != true)) || (c.ColumnsList.Count(t => t.FK && (t.FKTable.Replace("Entity", "")) == c.Code) == c.ColumnsList.Count(b => b.FK) && c.ColumnsList.Any(b => b.FK))).Select(t => new { Count = t.ColumnsList.Count(l => l.Virtual), t.Code }).OrderByDescending(m => m.Count).FirstOrDefault();
                    if (top != null) topstr = top.Code;
                }
                TreeNode node1 = dpm_TreeView.Nodes.Add(topstr + "[" + tab.Count + "张表]");
                node1.ToolTipText = tab.Top + "的数据表";
                tab.Table.ForEach(item =>
                {
                    var node2 =
                        new TreeNode(item.Code + "[" + item.Comment + "][" + item.ColumnsList.Count() + "个字段]")
                        {
                            Tag = item.Id,
                            ToolTipText = item.Comment
                        };
                    item.ColumnsList.ForEach(col =>
                    {
                        var node3 = new TreeNode { Tag = col.Id };
                        var text = col.Code + "[" + col.Name + "]";
                        if (col.PK)
                        {
                            node3.ForeColor = Color.Red;
                            text = "[PK]" + col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                            node3.ToolTipText = col.Name + "主键" + (col.IsAutoAdd ? "[自增]" : "");
                            //node3.ContextMenu = TreecontextMenu.ContextMenu;
                        }
                        else if (col.FK)
                        {
                            node3.ForeColor = Color.Green;
                            text = "[FK]" + col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                            node3.ToolTipText = col.Name + "外键" + (col.IsAutoAdd ? "[自增]" : "");
                            //node3.ContextMenu = TreecontextMenu.ContextMenu;
                        }
                        else if (col.Virtual)
                        {
                            node3.ForeColor = Color.Blue;
                            text = "[VI]" + col.Code + "[" + col.Name + "]";
                            node3.ToolTipText = "虚拟关系";
                        }
                        else
                        {
                            node3.ToolTipText = col.Name;
                            //node3.ContextMenu = TreecontextMenu.ContextMenu;
                        }
                        node3.Text = text;
                        node3.Tag = col.Id;
                        TreeNode node5 = new TreeNode
                        {
                            Text = col.DataType,
                            ToolTipText = "数据类型"
                        };
                        node3.Nodes.Add(node5);
                        if (col.Length != 0)
                        {
                            TreeNode node4 = new TreeNode { Text = @"长度" + col.Length };
                            node3.Nodes.Add(node4);
                        }
                        node2.Nodes.Add(node3);
                    });
                    node1.Nodes.Add(node2);
                });
                //treeView1.ExpandAll();
                if (!_isDataBase)
                {
                    AllButton.Text = @"清除";
                    node1.Checked = true;
                    Selected(node1, true);
                }
            });
        }

        private void SearchTextChange_Change(object sender, EventArgs e)
        {
            if (_tableList == null)
            {
                MessageBox.Show(@"请先连接数据库或打开PowerDesiger设计文件");
                return;
            }
            var text = SearchText.Text.Trim();
            if (text != "" && text != "表名")
            {
                text = text.ToLower();
                var tab = _tableList.Where(t => t.Code.ToLower().Contains(text) || (t.Comment != null && t.Comment.ToLower().Contains(text))).ToList();
                LoadData(tab);
            }
            else
                LoadData(_tableList);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                Selected(e.Node, e.Node.Checked);
            }
        }
        private void Selected(TreeNode node, bool check)
        {
            node.Checked = check;
            foreach (TreeNode e in node.Nodes)
            {
                e.Checked = check;
                Selected(e, check);
            }
        }

        /// <summary>
        /// 生成Ado.net代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCodeAdo_Click(object sender, EventArgs e)
        {
            Create(CreateCodeType.AdoNet代码);
        }
        /// <summary>
        /// 生成EFCodeFirst代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCodeEF_Click(object sender, EventArgs e)
        {
            Create(CreateCodeType.CodeFirst代码);
        }


        private void Create(CreateCodeType type)
        {
            richTextBox1.Text = "";
            if (_tableList == null)
            {
                MessageBox.Show(@"请先连接数据库或打开PowerDesiger设计文件");
                return;
            }
            var tag = SearchSelected();
            if (!tag.Any())
            {
                MessageBox.Show(@"请选择需要生成的表");
            }
            else
            {
                SaveOptions option = new SaveOptions { CreateCodeType = type, IsCancel = false };
                if (type == CreateCodeType.AdoNet代码 || type == CreateCodeType.Android代码)
                {
                    option.DataBaseType = _info.SqlType;
                    DataSource save = new DataSource(ref option);
                    save.ShowDialog();
                }
                else if (type == CreateCodeType.CodeFirst代码)
                {
                    SaveCode save = new SaveCode(ref option);
                    save.ShowDialog();
                }
                else if (type == CreateCodeType.EFCore代码)
                {
                    SaveCode save = new SaveCode(ref option);
                    save.ShowDialog();
                }
                else if (type == CreateCodeType.LigerUI代码)
                {
                    option.DataBaseType = _info.SqlType;
                    SaveLigerUICode save = new SaveLigerUICode(ref option);
                    save.ShowDialog();
                }
                if (option.OutPath != null && option.OutPath.Trim() != "" && !option.IsCancel)
                {
                    var TrueData = _tableList.Where(t => tag.Contains(t.Id)).ToList();
                    //Tablelist.ForEach(item =>
                    //{
                    //    item.ColumnsList = item.ColumnsList.Where(t => tag.Contains(t.Id)).ToList();
                    //});
                    CodePara para = new CodePara
                    {
                        Option = option,
                        TableList = TrueData,
                        AllTableList = _tableList
                    };
                    CodeWorker.RunWorkerAsync(para);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void DataBase_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var ba = new Link_DataBase(_info);
            ba.ShowDialog();
            if (_info.IsValied())
            {
                Data_LoadingWorker.RunWorkerAsync(_info);
            }
        }
        private void UI_Load(object sender, EventArgs e)
        {
            _info = new DataSourceInfo();
            LoadingProgressBar.Width = toolStrip1.Width - time.Width - 38 - AllButton.Width;
        }

        private void Loading(object sender, DoWorkEventArgs e)
        {
            UpdateUi dlegate = UpDate;
            DataSourceInfo minfo = (DataSourceInfo)e.Argument;
            try
            {
                e.Result = DataHelper.GetData(dlegate, this, minfo);
            }
            catch (Exception ee)
            {
                Invoke(dlegate, null, ee.Message);
            }
        }
        private void UpDate(ReportInfo minfo, string exception = null)
        {
            if (exception != null)
            {
                richTextBox1.SelectionColor = Color.Red;
                var start = richTextBox1.Text.Length;
                var str = DateTime.Now.ToString("HH:mm:ss:ffff") + " 错误【  " + exception + "】\r\n";
                richTextBox1.AppendText(str);
                richTextBox1.SelectionStart = start;//yyyy-MM-dd 
                richTextBox1.SelectionLength = str.Length;
                //richTextBox1.SelectionFont = new Font("宋体 ", 9F,
                //    FontStyle.Bold, GraphicsUnit.Point,
                //    ((Byte)(0)));
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                LoadingProgressBar.Value = (int)minfo.Percent;
                if (minfo.Message != null)
                {
                    richTextBox1.SelectionColor = Color.Green;
                    var start = richTextBox1.Text.Length;
                    richTextBox1.SelectionStart = start;
                    richTextBox1.AppendText(DateTime.Now.ToString("HH:mm:ss:ffff") + "   " + minfo.Message + "\r\n");
                    richTextBox1.SelectionLength = richTextBox1.Text.Length - start;
                    //richTextBox1.SelectionFont = new Font("宋体 ", 8.5F,
                    //    FontStyle.Bold, GraphicsUnit.Point,
                    //    ((Byte)(0)));
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                }
            }
        }

        private void Loading_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (List<TableModel>)e.Result;
            if (result != null)
            {
                _tableList = result;
                dpm_TreeView.Visible = true;
                _isDataBase = true;
                LoadData(_tableList);
            }
        }

        private void Code_Work(object sender, DoWorkEventArgs e)
        {
            CodePara code = (CodePara)e.Argument;
            var dlegate = new UpdateUi(UpDate);
            e.Result = PdmReader.CreateCodeFiles(code, dlegate, this);
        }

        private void Text_Change(object sender, EventArgs e)
        {
            var box = sender as RichTextBox;
            if (box == null) return;
            box.SelectionStart = box.Text.Length;
            box.ScrollToCaret();
        }

        private void Code_Complated(object sender, RunWorkerCompletedEventArgs e)
        {
            var success = (bool)e.Result;
            if (success)
                MessageBox.Show(@"代码生成成功！");
        }

        private void UI_SizeChanged(object sender, EventArgs e)
        {
            LoadingProgressBar.Width = toolStrip1.Width - time.Width - 15 - AllButton.Width;
        }

        private void Excel_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CodePara para = (CodePara)e.Argument;
            UpdateUi dlegate = UpDate;
            var result = new ExcelResult { Success = true, ExcelPath = para.Option.OutPath };
            try
            {
                switch (para.Type)
                {
                    case ExcelType.数据库结构:
                        PdmReader.WriteToExcel(para.Option.OutPath, para.TableList.Where(t => para.Tag.Contains(t.Id)).ToList(), dlegate, this);
                        break;
                    case ExcelType.数据:
                        Excel.ToExcelFile(para.Table, para.Option.OutPath, new string[] { }, new string[] { }, dlegate, this);
                        break;
                }
            }
            catch (Exception e2)
            {
                result.Success = false;
                Invoke(dlegate, null, e2.Message);
            }
            e.Result = result;
        }
        private void Excel_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ExcelResult result = e.Result as ExcelResult;
            if (result == null) return;
            if (result.Success)
            {
                DialogResult dr = MessageBox.Show(@"Excel文件生成成功，要查看该文件吗?", @"提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(result.ExcelPath);
                }
            }
            else
                MessageBox.Show(@"文件保存失败，错误信息请查看文本框日志。");
        }

        private void All_ChooseEvent(object sender, EventArgs e)
        {
            if (_tableList == null)
            {
                MessageBox.Show(@"请先连接数据库或打开PowerDesiger设计文件");
                return;
            }
            if (AllButton.Text == @"全选")
            {
                AllButton.Text = @"清除";
                foreach (TreeNode r in dpm_TreeView.Nodes)
                    Selected(r, true);
            }
            else
            {
                AllButton.Text = @"全选";
                foreach (TreeNode r in dpm_TreeView.Nodes)
                    Selected(r, false);
            }
        }

        private void Create_AndroidCode(object sender, EventArgs e)
        {
            Create(CreateCodeType.Android代码);
        }

        private void ServiceCode_Click(object sender, EventArgs e)
        {
            var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
            try
            {
                richTextBox1.Text = NewFileFactory.WriteDALText(table, DataBaseType.MSSQL); // NewFileFactory.WrieServiceText(table);
            }
            catch (Exception eee)
            {
                richTextBox1.Text = eee.Message;
            }
        }

        private void dpm_TreeView_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode selectNode = dpm_TreeView.GetNodeAt(e.X, e.Y);

            dpm_TreeView.SelectedNode = selectNode;
            if (e.Button == MouseButtons.Right)// && e.Clicks == 1
            {
                dpm_TreeView.ContextMenuStrip = null;
                if (selectNode.Level == 1 && e.X >= 35 + selectNode.Level * 19)
                {
                    dpm_TreeView.ContextMenuStrip = TreecontextMenu;
                }
                else if (selectNode.Level == 2 && e.X >= 35 + selectNode.Level * 19)
                {
                    dpm_TreeView.ContextMenuStrip = PKcontextMenuStrip;
                }
                if (selectNode.Tag != null)
                    _treeNodeSelect = selectNode.Tag.ToString();
                //richTextBox1.Text = _treeNodeSelect;
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && (e.X >= 35 + selectNode.Level * 19))
            {
                var view = sender as TreeView;
                if (view?.SelectedNode == null || view?.SelectedNode.Tag == null) return;
                var id = view.SelectedNode.Tag.ToString();
                var table = _tableList.FirstOrDefault(t => t.Id == id);
                if (table != null)
                {
                    var isCancel = false;
                    Modify modify = new Modify(ref table, ref isCancel);
                    modify.ShowDialog();
                    if (!isCancel)
                    {
                        var node = Search(table.Id);
                        if (node != null)
                        {
                            node.Text = table.Code + @"[" + table.Comment + @"][" + table.ColumnsList.Count() + @"个字段";
                            node.ToolTipText = table.Comment;
                        }
                    }
                }
                else
                {
                    var parent = _tableList.FirstOrDefault(t => t.ColumnsList.Any(r => r.Id == id));
                    if (parent != null)
                    {
                        var col = parent.ColumnsList.SingleOrDefault(t => t.Id == id);
                        var isCancel = false;
                        if (col == null) throw new ArgumentNullException(nameof(col));
                        ModifyCol modifyCol = new ModifyCol(ref col, ref isCancel);
                        modifyCol.ShowDialog();
                        if (isCancel) return;
                        var node3 = Search(id);
                        var node5 = new TreeNode();
                        if (node3 != null)
                        {
                            node3.Nodes.Clear();
                            var text = col.Code + "[" + col.Name + "]";
                            if (col.PK)
                            {
                                node3.ForeColor = Color.Red;
                                text = "[PK]" + col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                                node3.ToolTipText = col.Name + "主键";
                            }
                            else if (col.FK)
                            {
                                node3.ForeColor = Color.Green;
                                text = "[FK]" + col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                                node3.ToolTipText = col.Name + "外键";
                            }
                            else if (col.Virtual)
                            {
                                node3.ForeColor = Color.Blue;
                                text = "[VI]" + col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                                node3.ToolTipText = "虚拟关系";
                            }
                            else
                            {
                                node3.ToolTipText = col.Name;
                            }
                            node3.Text = text;
                            node3.Tag = col.Id;
                            node5.Text = col.DataType;
                            node5.ToolTipText = "数据类型";
                            node3.Nodes.Add(node5);
                            if (col.Length != 0)
                            {
                                var node4 = new TreeNode { Text = @"长度" + col.Length };
                                node3.Nodes.Add(node4);
                            }
                        }
                    }
                }
            }
        }

        private void OneModel_Click(object sender, EventArgs e)
        {
            var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
            try
            {
                richTextBox1.Text = NewFileFactory.WriteModelText(table, DataBaseType.MSSQL); // NewFileFactory.WrieServiceText(table);
            }
            catch (Exception eee)
            {
                richTextBox1.Text = eee.Message;
            }
        }

        private void OneDLL_Click(object sender, EventArgs e)
        {
            var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
            try
            {
                richTextBox1.Text = NewFileFactory.WriteBLLText(table, DataBaseType.MSSQL); // NewFileFactory.WrieServiceText(table);
            }
            catch (Exception eee)
            {
                richTextBox1.Text = eee.Message;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var col = _tableList.FirstOrDefault(t => t.ColumnsList.Any(r => r.Id == _treeNodeSelect)).ColumnsList.Where(r => r.Id == _treeNodeSelect).FirstOrDefault();

            col.PK = !col.PK;
            var node3 = dpm_TreeView.SelectedNode;//Search(col.Id);
            if (col.PK)
            {
                node3.ForeColor = Color.Red;
                node3.Text = "[PK]" + col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                node3.ToolTipText = col.Name + "主键";
            }
            else
            {
                node3.ForeColor = Color.Black;
                node3.Text = col.Code + "[" + col.Name + "]" + (col.IsAutoAdd ? "[自增]" : "");
                node3.ToolTipText = col.Name;
            }
        }
        private void PKcontextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var table = _tableList.Where(t => t.ColumnsList.Any(r => r.Id == _treeNodeSelect)).FirstOrDefault().ColumnsList.FirstOrDefault(r => r.Id == _treeNodeSelect);

            if (table.PK)
                toolStripMenuItem1.Text = @"取消主键";
            else
                toolStripMenuItem1.Text = @"设为主键";
        }

        private void StorePro_Click(object sender, EventArgs e)
        {
            var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
            var store = Helper.Helper.GetStoredPro(table);
            richTextBox1.Text = "----------------------------------存储过程----------------------------------\r\n " + store[0].Replace("\t", "\n") + " \r\n ----------------------------------数据库方法----------------------------------- \r\n " + store[1].Replace("\t", "\n");
        }

        private void CreateLigerUICode_Click(object sender, EventArgs e)
        {
            Create(CreateCodeType.LigerUI代码);
        }

        private void ExcelInPut_Click(object sender, EventArgs e)
        {
            ExcelFrom form = new ExcelFrom();
            form.Show();
        }

        private void findData_Click(object sender, EventArgs e)
        {
            if (_tableList != null)
            {
                mytabControl.SelectedIndex = 0;
                var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
                if (table != null && table.DataBaseName != null && table.DataBaseName.Trim() != "")
                {
                    _info.DataBaseName = table.DataBaseName;
                    string Sql = string.Format("select top {0} {1} from [{2}]", 10, string.Join(",", table.ColumnsList.Select(t => "[" + t.Code + "]")), table.Code);
                    SqlText.Text = Sql;
                    SetData(Sql);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
            if (table != null && table.DataBaseName != null && table.DataBaseName.Trim() != "")
            {
                _info.DataBaseName = table.DataBaseName;
                SetData(SqlText.Text);
            }
        }
        private void SetData(string Sql)
        {
            try
            {
                var Data = DataHelper.GetTableData(_info, Sql);
                if (Data != null)
                {
                    var TData = Data.Tables[0];
                    statusLabel.Text = string.Format("共{0}条数据。", TData.Rows.Count);
                    tableData.DataSource = TData;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = @"Excel(.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var Data = (DataTable)tableData.DataSource;
                var excelCode = new CodePara
                {
                    Type = ExcelType.数据,
                    Table = Data,
                    Option = new SaveOptions { OutPath = saveFileDialog1.FileName }
                };
                Excel_Worker.RunWorkerAsync(excelCode);
            }
        }

        private void inputData_Click(object sender, EventArgs e)
        {
            if (_tableList != null)
            {
                mytabControl.SelectedIndex = 1;
                var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
                if (table != null && table.DataBaseName != null && table.DataBaseName.Trim() != "")
                {
                    DataTable Data = new DataTable();
                    DataColumn FrontValue = new DataColumn("数据前缀");//显示Name
                    DataColumn DataField = new DataColumn("数据库字段");//显示Name
                    DataColumn ExField = new DataColumn("Excel字段");//绑定的Value
                    DataColumn DeValue = new DataColumn("默认值");
                    DataColumn LastValue = new DataColumn("数据后缀");//显示Name
                    Data.Columns.Add(FrontValue);
                    Data.Columns.Add(DataField);
                    Data.Columns.Add(ExField);
                    Data.Columns.Add(DeValue);
                    Data.Columns.Add(LastValue);
                    table.ColumnsList.Where(t => t.Virtual == false).ToList().ForEach(item =>
                    {
                        Data.Rows.Add("", item.Code, "", "", "");
                    });
                    inDataGridView.DataSource = Data;
                }
            }
        }

        private void openFileEx_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Excel(.xls)|*.xls|Excel(.xlsx)|*.xlsx";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _excelFilePath = openFile.FileName;
                var Con = Helper.Helper.GetConnect(openFile.FileName);
                DataTable schemaTable = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                Con.Dispose();
                Con.Close();
                excelTable.Items.Clear();
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    excelTable.Items.Add(schemaTable.Rows[i]["TABLE_NAME"]);
                }
                if (schemaTable.Rows.Count > 0)
                    excelTable.SelectedIndex = 0;
            }
        }

        private void excel_tableChange(object sender, EventArgs e)
        {
            var com = sender as ToolStripComboBox;
            Change(com.SelectedItem.ToString());
        }
        private void Change(string TableName)
        {
            if (TableName != null && TableName.Trim() != "")
            {
                Text = TableName.Replace("$", "-详细数据");
                string strExcel = "Select top 1 * From [" + TableName + "]";
                var conn = Helper.Helper.GetConnect(_excelFilePath);
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "dt");
                conn.Dispose();
                conn.Close();
                DataTable Table = new DataTable();
                DataColumn Name = new DataColumn("名称");//显示Name
                DataColumn Value = new DataColumn("内容");//绑定的Value
                Table.Columns.Add(Value);
                Table.Columns.Add(Name);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Columns.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        var ColName = ds.Tables[0].Columns[i].ToString();
                        Table.Rows.Add(ColName, ColName);
                    }
                    if (((DataGridViewComboBoxColumn)inDataGridView.Columns["Excel字段"]).DataSource == null)
                    {
                        ((DataGridViewComboBoxColumn)inDataGridView.Columns["Excel字段"]).DisplayMember = "名称";
                        ((DataGridViewComboBoxColumn)inDataGridView.Columns["Excel字段"]).ValueMember = "内容";
                    }
                    ((DataGridViewComboBoxColumn)inDataGridView.Columns["Excel字段"]).DataSource = Table;
                }
            }
        }

        private void SeeData_Click(object sender, EventArgs e)
        {
            ExcelFrom from = new ExcelFrom(_excelFilePath);
            from.Show();
        }

        private void endEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    int rows = e.RowIndex;
            //    DataTable tab= (DataTable)inDataGridView.DataSource;
            //    MessageBox.Show(tab.Rows[rows][e.ColumnIndex].ToString());
            //}
        }

        private void beginInputData_Click(object sender, EventArgs e)
        {
            var selecttable = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
            var TableName = excelTable.SelectedItem;
            if (TableName != null && TableName.ToString().Trim() != "" && selecttable != null)
            {
                DataTable tab = (DataTable)inDataGridView.DataSource;
                StringBuilder bulider = new StringBuilder();
                StringBuilder Key = new StringBuilder();
                StringBuilder Value = new StringBuilder();

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    var Data = tab.Rows[i];
                    if (Data["Excel字段"].ToString().Trim() != "" || Data["默认值"].ToString().Trim() != "")
                    {
                        if (Data["Excel字段"].ToString().Trim() != "")
                            bulider.Append(Data["数据库字段"].ToString() + "=>" + Data["Excel字段"].ToString() + "\r\n");
                        else if (Data["默认值"].ToString().Trim() != "")
                            bulider.Append(Data["数据库字段"].ToString() + "=>" + Data["默认值"].ToString() + "[默认值]\r\n");
                        Key.Append("," + Data["数据库字段"].ToString());
                        Value.Append(",@" + Data["数据库字段"].ToString());
                    }
                }

                string Sql = string.Format("insert into {0} ({1}) values ({2})", selecttable.Code, Key.ToString().Substring(1), Value.ToString().Substring(1));
                //MessageBox.Show(Sql);
                MessageBoxButtons mes = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("插入语句：" + Sql + "\r\n键值对数据匹配如下：\r\n" + bulider.ToString(), "确定导入数据", mes);
                if (dr == DialogResult.OK)
                {
                    string strExcel = "Select * From [" + TableName + "]";
                    var conn = Helper.Helper.GetConnect(_excelFilePath);
                    OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "dt");
                    conn.Dispose();
                    conn.Close();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (_info.SqlType == DataBaseType.MySql)
                        {
                            var DataHelper = new MySqlDbHelper(_info.Connect);
                            List<MySqlParameter> pa = new List<MySqlParameter>();
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                pa.Clear();
                                var Row = ds.Tables[0].Rows[i];
                                for (int r = 0; r < tab.Rows.Count; r++)
                                {
                                    var tableRow = tab.Rows[r];
                                    if (tableRow["Excel字段"].ToString().Trim() != "" || tableRow["默认值"].ToString().Trim() != "")
                                    {
                                        var DataColName = tableRow["数据库字段"].ToString();
                                        if (tableRow["Excel字段"].ToString().Trim() != "")
                                        {
                                            var ColName = tableRow["Excel字段"].ToString();
                                            //添加数据前缀和后缀
                                            pa.Add(new MySqlParameter("@" + DataColName, tableRow["数据前缀"].ToString() + Row[ColName].ToString() + tableRow["数据后缀"].ToString()));
                                        }
                                        else if (tableRow["默认值"].ToString().Trim() != "")
                                        {
                                            pa.Add(new MySqlParameter("@" + DataColName, tableRow["数据前缀"].ToString() + tableRow["默认值"].ToString() + tableRow["数据后缀"].ToString()));
                                        }
                                    }
                                }
                                var DataSet = DataHelper.Query(Sql, pa.ToArray());
                            }
                            MessageBox.Show("执行成功");
                        }

                        else if (_info.SqlType == DataBaseType.MSSQL)
                        {
                            var DataHelper = new MsSqlDbHelper(_info.Connect);
                            List<SqlParameter> pa = new List<SqlParameter>();
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                pa.Clear();
                                var Row = ds.Tables[0].Rows[i];
                                for (int r = 0; r < tab.Rows.Count; r++)
                                {
                                    var tableRow = tab.Rows[r];
                                    if (tableRow["Excel字段"].ToString().Trim() != "" || tableRow["默认值"].ToString().Trim() != "")
                                    {
                                        var DataColName = tableRow["数据库字段"].ToString();
                                        if (tableRow["Excel字段"].ToString().Trim() != "")
                                        {
                                            var ColName = tableRow["Excel字段"].ToString();
                                            //添加数据前缀和后缀
                                            pa.Add(new SqlParameter("@" + DataColName, tableRow["数据前缀"].ToString() + Row[ColName].ToString() + tableRow["数据后缀"].ToString()));
                                        }
                                        else if (tableRow["默认值"].ToString().Trim() != "")
                                        {
                                            pa.Add(new SqlParameter("@" + DataColName, tableRow["数据前缀"].ToString() + tableRow["默认值"].ToString() + tableRow["数据后缀"].ToString()));
                                        }
                                    }
                                }
                                var DataSet = DataHelper.Query(Sql, pa.ToArray());
                            }
                            MessageBox.Show("执行成功");
                        }
                        else
                            MessageBox.Show("未实现该功能。");
                    }
                    else
                        MessageBox.Show("暂无数据可导入。");
                }
                else
                    MessageBox.Show("你选择了取消。");
            }
            else
                MessageBox.Show("请打开需要导入数据的Excel文件。");
        }

        private void Derectoryopen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            //按下确定选择的按钮  
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                var path = folderBrowserDialog1.SelectedPath;
                var Fileinfos = Helper.Helper.GetFilesInfo(path);
                _infoMessage = Fileinfos;
                BindFileInfo();
            }
        }
        private void BindFileInfo()
        {
            DataTable Table = new DataTable();
            DataColumn FileName = new DataColumn("文件名");
            DataColumn Length = new DataColumn("大小");
            DataColumn Code = new DataColumn("编号");
            DataColumn Path = new DataColumn("路径");
            DataColumn Type = new DataColumn("类型");
            DataColumn FilePath = new DataColumn("文件路径");
            DataColumn Suffix = new DataColumn("后缀");







            Table.Columns.Add(FileName);
            Table.Columns.Add(Length);
            Table.Columns.Add(Code);
            Table.Columns.Add(Path);
            Table.Columns.Add(Type);
            Table.Columns.Add(FilePath);
            Table.Columns.Add(Suffix);




            _infoMessage.ForEach(item =>
            {
                Table.Rows.Add(item.FileName, item.Length, item.Code, item.Path, item.Type, item.FilePath, item.Suffix);
            });
            FileInfoGridView.DataSource = Table;
        }

        private void Save_fileExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = @"Excel(.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var Data = (DataTable)FileInfoGridView.DataSource;
                var excelCode = new CodePara
                {
                    Type = ExcelType.数据,
                    Table = Data,
                    Option = new SaveOptions { OutPath = saveFileDialog1.FileName }
                };
                Excel_Worker.RunWorkerAsync(excelCode);
            }
        }

        private void SaveGroupExcel_Click(object sender, EventArgs e)
        {
            if (_infoMessage != null)
            {
                openFile.Filter = "Excel(.xls)|*.xls|Excel(.xlsx)|*.xlsx";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    var FilePath = openFile.FileName;
                    var conn = Helper.Helper.GetConnect(FilePath);
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    var TableName = schemaTable.Rows[0]["TABLE_NAME"];
                    string strExcel = "Select * From [" + TableName + "]";
                    OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "dt");
                    conn.Dispose();
                    conn.Close();
                    var DataTable = ds.Tables[0];
                    //dataGridView.DataSource = ds.Tables[0];
                    var Rata = _infoMessage.GroupBy(t => new { t.Code, t.Path }).Select(t => new
                    {
                        Code = t.Key.Code,
                        Path = t.Key.Path,
                        IsHave = t.Any(x => x.Suffix == ".123dx" || x.Suffix == ".stl") == true ? "是" : "否",
                        DocList = t.Where(x => x.Suffix == ".doc" || x.Suffix == ".docx").Select(r => r.FilePath).ToList(),
                        IsDoc = t.Any(x => x.Suffix == ".doc" || x.Suffix == ".docx")
                    }).ToList();

                    //DataColumn T_WorkName = new DataColumn("作品名1");
                    //DataColumn T_StuName = new DataColumn("学生姓名1");
                    //DataColumn T_StuPhone = new DataColumn("学生电话1");
                    //DataColumn T_TeName = new DataColumn("教师姓名1");
                    //DataColumn T_TePhone = new DataColumn("教师电话1");
                    //DataColumn T_SchoolName = new DataColumn("学校名称1");
                    //DataColumn T_Email = new DataColumn("Email/QQ1");
                    //DataTable.Columns.Add(T_WorkName);
                    //DataTable.Columns.Add(T_StuName);
                    //DataTable.Columns.Add(T_StuPhone);
                    //DataTable.Columns.Add(T_TeName);
                    //DataTable.Columns.Add(T_TePhone);
                    //DataTable.Columns.Add(T_SchoolName);
                    //DataTable.Columns.Add(T_Email);
                    foreach (DataRow item in DataTable.Rows)
                    {
                        var Code = item["F7"].ToString().Trim();
                        if (Code == "") continue;
                        var DInfo = Rata.Where(t => t.Code == Code).FirstOrDefault();
                        string WorkName = "", StuName = "", StuPhone = "", TeName = "", TePhone = "", SchoolName = "", Email = "";
                        if (DInfo != null && DInfo.IsDoc)
                        {
                            DInfo.DocList.ForEach(doc =>
                            {
                                var re = Helper.Helper.getDocText(doc);
                                //UTF8Encoding utf8 = new UTF8Encoding();
                                //Byte[] encodedBytes = utf8.GetBytes(Text);
                                //string re = utf8.GetString(encodedBytes);

                                var p = re.IndexOf("作品名称");
                                if (p != -1)
                                {
                                    re = re.Substring(p + 4);
                                    p = re.IndexOf("作品电子文件大小");
                                    if (p != -1)
                                    {
                                        WorkName = re.Substring(1, p - 2);
                                    }
                                }
                                p = re.IndexOf("学校名称");
                                if (p != -1)
                                {
                                    re = re.Substring(p + 4);
                                    p = re.IndexOf("教师");
                                    if (p != -1)
                                    {
                                        SchoolName = re.Substring(1, p - 3);
                                        re = re.Substring(p + 2);
                                        p = re.IndexOf("电话");
                                        if (p != -1)
                                        {
                                            TeName = re.Substring(1, p - 2);
                                            re = re.Substring(p + 2);
                                            p = re.IndexOf("学生");
                                            if (p != -1)
                                            {
                                                TePhone = re.Substring(1, p - 3);
                                                re = re.Substring(p + 2);
                                                p = re.IndexOf("电话");
                                                if (p != -1)
                                                {
                                                    StuName = re.Substring(1, p - 2);
                                                    re = re.Substring(p + 2);
                                                    p = re.IndexOf("邮  箱/QQ");
                                                    if (p != -1)
                                                    {
                                                        StuPhone = re.Substring(1, p - 3);
                                                        re = re.Substring(p + 7);
                                                        p = re.IndexOf("学校类型");
                                                        if (p != -1)
                                                        {
                                                            Email = re.Substring(1, p - 3);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            });
                        }
                        //item["作品名1"] = WorkName;
                        if (SchoolName != "")
                        {
                            item["F5"] = SchoolName.Replace("云南省", "");
                        }
                        else
                        {
                            item["F5"] = item["F5"].ToString().Replace("云南省", "");
                        }
                        //item["学生姓名1"] = StuName;
                        //item["学生电话1"] = StuPhone;
                        //item["教师姓名1"] = TeName;
                        //item["教师电话1"] = TePhone;
                        //item["学校名称1"] = SchoolName;
                        //item["Email/QQ1"] = Email;
                        //Table.Rows.Add(item.Code, item.Path, item.IsHave, WorkName, StuName, StuPhone, TeName, TePhone, SchoolName, Email);
                    }
                    FileInfoGridView.DataSource = DataTable;
                }
            }
            else
            {
                MessageBox.Show("请先选择打开目录");
            }
        }

        private void script_Click(object sender, EventArgs e)
        {
            var tag = SearchSelected();
            var Tablelist = _tableList.Where(t => tag.Contains(t.Id)).ToList();
            if (!tag.Any())
                MessageBox.Show(@"请选择需要生成的表");
            else
            {
                Dictionary<string, TableModel> Data = new Dictionary<string, TableModel>();
                Tablelist.ForEach(item =>
                {
                    Data.Add(item.Code, item);
                });
                var Script = JsonConvert.SerializeObject(Data);
                richTextBox1.Text = Script;
            }
        }

        private void ObjectTest_Click(object sender, EventArgs e)
        {
            ObjectTest test = new ObjectTest();
            test.Show();
        }

        private void 目录文件信息统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void powerDesignData_Click(object sender, EventArgs e)
        {
            if (_tableList != null)
            {
                //mytabControl.SelectedIndex = 0;
                //var table = _tableList.FirstOrDefault(t => t.Id == _treeNodeSelect);
                //if (table == null) MessageBox.Show("选择的数据不存在");
                //var cols = table.ColumnsList;

                //DataTable colTableData = new DataTable();
                //DataColumn Name = new DataColumn("Name");
                //DataColumn Code = new DataColumn("Code");
                //DataColumn Comment = new DataColumn("Comment");
                //DataColumn Type = new DataColumn("Data Type");
                //DataColumn Length = new DataColumn("Length");
                //DataColumn Precision = new DataColumn("Precision");
                //DataColumn Identity = new DataColumn("Identity");
                //DataColumn Primary = new DataColumn("Primary");
                //DataColumn Foreign = new DataColumn("Foreign Key");
                //DataColumn Mandatory = new DataColumn("Mandatory");
                //colTableData.Columns.Add(Name);
                //colTableData.Columns.Add(Code);
                //colTableData.Columns.Add(Comment);
                //colTableData.Columns.Add(Type);
                //colTableData.Columns.Add(Length);
                //colTableData.Columns.Add(Precision);
                //colTableData.Columns.Add(Identity);
                //colTableData.Columns.Add(Primary);
                //colTableData.Columns.Add(Foreign);
                //colTableData.Columns.Add(Mandatory);
                //table.ColumnsList.ForEach(item =>
                //{
                //    colTableData.Rows.Add(item.Name, item.Code, item.Comment, item.DataType,
                //        item.Length, 0, item.PK ? "TRUE" : "FALSE", item.PK ? "TRUE" : "FALSE", "FALSE", item.IsNull ? "FALSE" : "TRUE");
                //});
                //tableData.DataSource = colTableData;

                //var dpmfilepath = "C:\\Users\\JR\\Desktop\\数据库整理\\jcxd_sys_target - 副本.pdm";
                //var dpmfilepathOut = "C:\\Users\\JR\\Desktop\\数据库整理\\jcxd_sys_target_change.pdm";
                var dpmfilepath = "C:\\Users\\JR\\Desktop\\数据库整理\\jcxd_sys_out - 副本.pdm";
                var dpmfilepathOut = "C:\\Users\\JR\\Desktop\\数据库整理\\jcxd_sys_out - 副本——代码.pdm";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(dpmfilepath);
                XmlNode models = xmlDoc.SelectSingleNode("Model");
                if (models != null)
                {
                    var data = models.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes;
                    foreach (XmlNode item4 in data)
                    {
                        if (item4.LocalName == "Tables")
                        {
                            foreach (XmlNode item5 in item4.ChildNodes)
                            {
                                //先找出TableCode
                                //XmlNode tableCommontNode = null;
                                XmlNode tableNameNode = null;
                                var tableCode = string.Empty;
                                var colsNode = new Dictionary<string, XmlNode>();
                                foreach (XmlNode item6 in item5.ChildNodes)
                                {
                                    if (item6.LocalName == "Name")
                                    {
                                        tableNameNode = item6;
                                    }
                                    if (item6.LocalName == "Code")
                                    {
                                        tableCode = item6.InnerText;
                                    }
                                    if (item6.LocalName == "Columns")
                                    {
                                        foreach (XmlNode item7 in item6.ChildNodes)
                                        {
                                            var colCode = string.Empty;
                                            XmlNode columnNode = null;
                                            foreach (XmlNode item8 in item7.ChildNodes)
                                            {
                                                if (item8.LocalName == "Code")
                                                {
                                                    colCode = item8.InnerText;
                                                }
                                                if (item8.LocalName == "Name")
                                                {
                                                    columnNode = item8;
                                                }
                                            }
                                            colsNode.Add(colCode, columnNode);
                                        }
                                    }
                                }
                                if (tableNameNode != null && tableCode != string.Empty)
                                {
                                    var tabData = _tableList.Where(t => t.Code == tableCode).FirstOrDefault();
                                    if (tabData != null)
                                    {
                                        if (!string.IsNullOrWhiteSpace(tabData.Name) || !string.IsNullOrWhiteSpace(tabData.Comment))
                                            tableNameNode.InnerText = tabData.Name ?? tabData.Comment;
                                        var columnsList = tabData.ColumnsList;
                                        foreach (var col in colsNode)
                                        {
                                            var colData = columnsList.Where(t => t.Code == col.Key).FirstOrDefault();
                                            if (colData != null && (
                                                 !string.IsNullOrWhiteSpace(colData.Name) || !string.IsNullOrWhiteSpace(colData.Comment)))
                                            {
                                                col.Value.InnerText = colData.Name ?? colData.Comment;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    xmlDoc.Save(dpmfilepathOut);
                }
            }
        }

        private void DotnetCoreCode_Click(object sender, EventArgs e)
        {
            Create(CreateCodeType.EFCore代码);
        }
        public class XD_RFundPlan
        {
            public decimal CapitalAmount { set; get; }
            public int OrderID { set; get; }
            public bool IsEnd { set; get; }
            public bool IsAbate { set; get; }
            public DateTime RepayDate { set; get; }
            public decimal InterestAmount { set; get; }
            public decimal OAmount { set; get; }
            public int Days { set; get; }
            public override string ToString()
            {
                return $"{OrderID}  {Days}  {RepayDate.ToString("yyyy-MM-dd")}  {InterestAmount.ToString("N2")} {OAmount.ToString("N2")}";
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            var sqje = 1000000;
            var dt = new DateTime(2020, 1, 22);
            dt = dt.AddDays(-1);
            var loanRate = 0.098m;
            var sqqx = 12;
            var dayLoanRate = loanRate / 360;
            var returnBackDays = 20;
            if (dt.Day != returnBackDays)
            {
                sqqx = sqqx + 1;
            }
            var plans = new List<XD_RFundPlan>();
            //上一期还款日期
            for (int i = 0; i < sqqx; i++)
            {
                //dt = ldt_dt.AddMonths(i+1);
                var plan2 = new XD_RFundPlan
                {
                    CapitalAmount = 0,
                    OrderID = i + 1,
                    IsEnd = false,
                    IsAbate = true
                };
                DateTime currentDate, repayDate;
                //小于20日 首次还款计划应为计算的当前日到20号之间间隔的天数计算还款利息
                if (dt.Day < returnBackDays)
                {
                    //本期日期
                    currentDate = dt.AddMonths(i);
                    repayDate = dt.AddMonths(i);
                    if (i == 0)
                    {
                        plan2.CapitalAmount = 0;
                        repayDate = new DateTime(currentDate.Year, currentDate.Month, 20);
                    }
                    //最后一期
                    else
                    {
                        var dtDay = dt.AddMonths(i - 1);
                        //上个月20号
                        currentDate = new DateTime(dtDay.Year, dtDay.Month, 20);
                        if (i == sqqx - 1)
                        {
                            plan2.CapitalAmount = sqje;
                            //repayDate = repayDate;
                        }
                        else
                        {
                            repayDate = new DateTime(repayDate.Year, repayDate.Month, 20);
                        }
                    }
                }
                else
                {
                    //本期日期
                    currentDate = dt.AddMonths(i + 1);
                    repayDate = dt.AddMonths(i);
                    if (i == 0)
                    {
                        plan2.CapitalAmount = 0;
                        repayDate = new DateTime(currentDate.Year, currentDate.Month, 20);
                        currentDate = dt;
                    }
                    //最后一期
                    else
                    {
                        currentDate = new DateTime(repayDate.Year, repayDate.Month, 20);
                        repayDate = currentDate.AddMonths(1);
                        if (i == sqqx - 1)
                        {
                            plan2.CapitalAmount = sqje;
                            if (dt.Day != returnBackDays)
                            {
                                repayDate = dt.AddMonths(i);
                            }
                        }
                    }
                }
                //计算利息的天数
                var days = (int)(repayDate - currentDate).TotalDays;
                //还款利息
                var interest = dayLoanRate * days * sqje;
                plan2.Days = days;
                plan2.InterestAmount = interest;
                plan2.OAmount = plan2.CapitalAmount + plan2.InterestAmount;
                plan2.RepayDate = repayDate;
                plans.Add(plan2);
            }
            var result = string.Join("\r\n", plans);
            MessageBox.Show(result);
        }
    }
}
