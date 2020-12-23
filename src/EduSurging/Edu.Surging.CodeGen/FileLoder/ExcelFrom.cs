using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FileLoder
{
    public partial class ExcelFrom : Form
    {
        private string FilePath, FilePath2;
        public ExcelFrom(string path = null)
        {
            InitializeComponent();
            FilePath = path;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel(.xls)|*.xls|Excel(.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog1.FileName;
                var schemaTable = LodingData(FilePath);
                tableComboBox.Items.Clear();
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    tableComboBox.Items.Add(schemaTable.Rows[i]["TABLE_NAME"]);
                }
                if (schemaTable.Rows.Count > 0)
                    tableComboBox.SelectedIndex = 0;
            }
        }

        private DataTable LodingData(string filepath)
        {
            var Con = Helper.Helper.GetConnect(filepath);
            DataTable schemaTable = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            Con.Dispose();
            Con.Close();
            return schemaTable;

        }

        private void tabChange(object sender, EventArgs e)
        {
            var com = sender as ToolStripComboBox;
            Change(FilePath, com.SelectedItem.ToString(), dataGridView, FieldName);
        }
        private void Change(string filePath, string TableName, DataGridView view, ToolStripComboBox com)
        {
            if (TableName != null && TableName.Trim() != "")
            {
                Text = TableName.Replace("$", "-详细数据");
                string strExcel = "Select * From [" + TableName + "]";
                var conn = Helper.Helper.GetConnect(filePath);
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "dt");
                conn.Dispose();
                conn.Close();
                //if (view.DataSource == null)
                //{
                view.DataSource = ds.Tables[0];
                view1.Text = "有" + ds.Tables[0].Rows.Count + "条";
                com.Items.Clear();
                foreach (DataColumn item in ds.Tables[0].Columns)
                {
                    com.Items.Add(item.ColumnName);
                }
                //}
                //else
                //{
                //    View2.DataSource = ds.Tables[0];
                //    v2.Text = "有" + ds.Tables[0].Rows.Count + "条";
                //}
            }
        }

        private void begin_Click(object sender, EventArgs e)
        {
            var str = tableComboBox.SelectedItem.ToString();
            if (str != null && str.Trim() != "")
            {
                string strExcel = "Select * From [" + str + "]";
                var count = 0;
                var conn = Helper.Helper.GetConnect(FilePath);
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, conn);
                DataSet ds = new DataSet();
                conn.Dispose();
                conn.Close();
                if (ds != null && ds.Tables.Count > 0)
                {
                    myCommand.Fill(ds, "dt");
                    var Table = ds.Tables[0];
                    dataGridView.DataSource = Table;
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < Table.Rows.Count; i++)//
                    {
                        var Model = new OPApp();
                        for (int j = 0; j < Table.Columns.Count; j++)
                        {
                            var col = Table.Columns[j].ToString();
                            var data = Table.Rows[i][j].ToString();
                            switch (col)
                            {
                                case "APP_ID":
                                    Model.app_id = data;
                                    break;
                                case "APP_NAME":
                                    Model.app_name = data;
                                    break;
                                case "DESCRIPTION":
                                    Model.app_description = data;
                                    break;
                                case "CREATE_TIME":
                                    Model.create_time = Convert.ToDateTime(data);
                                    break;
                                case "LOGO_URL":
                                    Model.logo_url = data;
                                    break;
                                case "APP_PIC":
                                    Model.app_pic = data;
                                    break;
                                case "TYPE":
                                    Model.type = Convert.ToInt32(data);
                                    break;
                                case "LIFECYCLE":
                                    Model.lifecycle = Convert.ToInt32(data);
                                    break;
                                case "IS_RECOMMEND":
                                    Model.is_recommend = Convert.ToInt32(data);
                                    break;
                                case "DISPLAY_ORDER":
                                    Model.display_order = data;
                                    break;
                            }
                        }
                        Model.op_type = 1;
                        string postdata = string.Format("data={0}", HttpUtility.UrlEncode(Newtonsoft.Json.JsonConvert.SerializeObject(Model)));
                        var result = Helper.Helper.Post(postdata, "http://localhost:85/ynmobile/appsync");
                        var YNResult = Newtonsoft.Json.JsonConvert.DeserializeObject<YNResult>(result);
                        if (YNResult.ERROR_CODE != "0")
                        {
                            MessageBox.Show(YNResult.ERROR_CODE);
                        }
                        else
                            count++;
                    }
                    MessageBox.Show(string.Format("已成功同步{0}条应用数据", count));
                }
            }
        }

        private void ExcelFrom_Load(object sender, EventArgs e)
        {
            if (FilePath != null)
            {
                LodingData(FilePath);
            }
        }

        private void Contrast_Click(object sender, EventArgs e)
        {
            if (FieldName.Text.Trim() == "")
                MessageBox.Show("字段名称不能为空。");
            else if (FieldName2.Text.Trim() == "")
                MessageBox.Show("字段名称2不能为空。");
            else
            {
                DataTable Table1 = (DataTable)dataGridView.DataSource;
                DataTable Table2 = (DataTable)dataGridView2.DataSource;

                var Keys2 = new List<string>();
                for (int j = 0; j < Table2.Rows.Count; j++)//
                {
                    var key = Table2.Rows[j][FieldName2.Text].ToString();
                    if (key != "")
                        Keys2.Add(key);
                }

                //var Keys = new List<string>();
                //for (int j = 0; j < Table1.Rows.Count; j++)//
                //{
                //    var key = Table1.Rows[j][FieldName.Text].ToString();
                //    if(key!="")
                //        Keys.Add(key);
                //}

                //Keys =Keys.Distinct().ToList();
                Keys2 = Keys2.Distinct().ToList();

                //if (Keys.Count == Keys2.Count) MessageBox.Show("作品数相同");


                DataTable Table13 = new DataTable();
                foreach (DataColumn item in Table1.Columns)
                {
                    Table13.Columns.Add(new DataColumn(item.ColumnName));
                }

                if (Table1 == null)
                    MessageBox.Show("数据源1不能为空。");
                if (Table2 == null)
                    MessageBox.Show("数据源2不能为空。");

                for (int i = 0; i < Table1.Rows.Count; i++)//
                {
                    var Key = Table1.Rows[i][FieldName.Text].ToString();
                    if (!Keys2.Contains(Key) && Key != "")
                    {
                        var DataRow = Table13.NewRow();
                        foreach (DataColumn item in Table1.Columns)
                        {
                            DataRow[item.ColumnName] = Table1.Rows[i][item.ColumnName];
                        }
                        Table13.Rows.Add(DataRow);
                    }
                }

                dataGridView3.DataSource = Table13;
            }

        }
        public class YNResult
        {
            public string ERROR_CODE { set; get; }
        }
        public class OPApp
        {
            public string app_id { set; get; }
            public string app_name { set; get; }
            public string app_description { set; get; }
            public DateTime? create_time { set; get; }
            public string logo_url { set; get; }
            public string app_pic { set; get; }
            public int type { set; get; }
            public int? lifecycle { set; get; }
            public int? is_recommend { set; get; }
            public string display_order { set; get; }
            public int op_type { set; get; }
        }

        private void SaveExcel_Click(object sender, EventArgs e)
        {

        }

        private void cf_Click(object sender, EventArgs e)
        {
            DataTable Table = (DataTable)dataGridView.DataSource;
            if (FieldName.Text.Trim() == "")
                MessageBox.Show("字段名称不能为空。");
            else
            {
                DataTable Table13 = new DataTable();
                foreach (DataColumn item in Table.Columns)
                {
                    Table13.Columns.Add(new DataColumn(item.ColumnName));
                }
                var DKeys = new Dictionary<string, int>();
                var D2Keys = new Dictionary<int, int>();
                for (int j = 0; j < Table.Rows.Count; j++)//
                {
                    var key = Table.Rows[j][FieldName.Text].ToString().Trim();
                    if (DKeys.Keys.Contains(key))
                    {
                        if (!D2Keys.Keys.Contains(DKeys[key]))
                        {
                            D2Keys.Add(DKeys[key], 0);
                            var DataRow2 = Table13.NewRow();
                            foreach (DataColumn col in Table.Columns)
                            {
                                DataRow2[col.ColumnName] = Table.Rows[DKeys[key]][col.ColumnName];
                            }
                            Table13.Rows.Add(DataRow2);
                        }
                        var DataRow = Table13.NewRow();
                        foreach (DataColumn col in Table.Columns)
                        {
                            DataRow[col.ColumnName] = Table.Rows[j][col.ColumnName];
                        }
                        Table13.Rows.Add(DataRow);
                    }
                    else
                    {
                        DKeys.Add(key, j);
                    }
                }

                dataGridView3.DataSource = Table13;
                v2.Text = Table13.Rows.Count + "条数据。";
            }
        }

        private void tableComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var com = sender as ToolStripComboBox;
            Change(FilePath2, com.SelectedItem.ToString(), dataGridView2, FieldName2);
        }

        private void Merge_Click(object sender, EventArgs e)
        {
            DataTable Table13 = new DataTable();
            DataTable Table = (DataTable)dataGridView.DataSource;
            DataTable Table2 = (DataTable)dataGridView2.DataSource;
            foreach (DataColumn item in Table.Columns)
                Table13.Columns.Add(new DataColumn(item.ColumnName));
            var DataR = new Dictionary<string, DataRow>();
            foreach (DataColumn item in Table2.Columns)
            {
                if (item.ColumnName != FieldName2.Text)
                    Table13.Columns.Add(new DataColumn(item.ColumnName + "2"));
            }
            for (int j = 0; j < Table2.Rows.Count; j++)
            {
                var Row = Table2.Rows[j];
                if (!DataR.ContainsKey(Row[FieldName2.Text].ToString().Trim()))
                    DataR.Add(Row[FieldName2.Text].ToString().Trim(), Row);
            }
            for (int j = 0; j < Table.Rows.Count; j++)
            {
                var key = Table.Rows[j][FieldName.Text].ToString().Trim();
                var DataRow = Table13.NewRow();
                foreach (DataColumn col in Table.Columns)
                    DataRow[col.ColumnName] = Table.Rows[j][col.ColumnName];
                if (DataR.ContainsKey(key))
                {
                    var Row = DataR[key];
                    foreach (DataColumn col in Table2.Columns)
                    {
                        if (col.ColumnName != FieldName2.Text)
                            DataRow[col.ColumnName + "2"] = Row[col.ColumnName];
                    }
                }
                Table13.Rows.Add(DataRow);
            }
            dataGridView3.DataSource = Table13;
        }

        private void OpenFile2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Excel(.xls)|*.xls|Excel(.xlsx)|*.xlsx";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                FilePath2 = openFileDialog2.FileName;
                var schemaTable = LodingData(FilePath2);
                tableComboBox2.Items.Clear();
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    tableComboBox2.Items.Add(schemaTable.Rows[i]["TABLE_NAME"]);
                }
                if (schemaTable.Rows.Count > 0)
                    tableComboBox2.SelectedIndex = 0;
            }
        }
    }
}
