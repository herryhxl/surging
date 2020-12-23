using FileLoder.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoder
{
    public partial class Link_DataBase : Form
    {
        private DataSourceInfo _info;
        public Link_DataBase(DataSourceInfo info)
        {
            InitializeComponent();
            _info = info;
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            if (Data_Source.Text.Trim() == "")
                MessageBox.Show(@"请填写数据源！");
            else if (!MySql.Checked && !MsSql.Checked)
                MessageBox.Show(@"请选择数据库！");
            else if (UserName.Text.Trim() == "")
                MessageBox.Show(@"请填写用户名！");
            else if (PassWord.Text.Trim() == "")
                MessageBox.Show(@"请填写密码！");
            else
            {
                if (MySql.Checked)
                {
                    int myPort;
                    int.TryParse(Port.Text.Trim(), out myPort);
                    _info.Port = myPort;
                    _info.SqlType = DataBaseType.MySql;
                }
                else
                    _info.SqlType = DataBaseType.MSSQL;
                _info.DataSourceName = Data_Source.Text.Trim();
                _info.UserName = UserName.Text.Trim();
                _info.PassWord = PassWord.Text.Trim();
                if (com_DataBaseName.SelectedIndex != 0)
                    _info.DataBaseName = com_DataBaseName.Text.Trim();
                else
                    _info.DataBaseName = null;
                new XmlLoder().Process(_info);
                Dispose();
            }
        }

        private void My_Sql_ChangeEvent(object sender, EventArgs e)
        {
            Port.Visible = MySql.Checked;
            Data_Source.Text = @"127.0.0.1";
            UserName.Text = @"root";//MySql
            PassWord.Text = @"";
            com_DataBaseName.DataSource = null;
            Data_Source.DataSource = new XmlLoder().Info.Where(t => t.SqlType == DataBaseType.MySql).ToList();
        }

        private void MSSql_Change(object sender, EventArgs e)
        {
            Port.Visible = MySql.Checked;
            Data_Source.Text = @".";
            UserName.Text = @"sa";
            PassWord.Text = @"";
            com_DataBaseName.DataSource = null;
            Data_Source.DataSource = new XmlLoder().Info.Where(t => t.SqlType == DataBaseType.MSSQL).ToList();
        }

        private void Key_UP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sure_Click(null, null);
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _info.IsCancel = false;
            Data_Source.DataSource = new XmlLoder().Info.Where(t => t.SqlType == DataBaseType.MSSQL).ToList();
        }

        private void Data_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            var minfo = (DataSourceInfo)Data_Source.SelectedItem;
            PassWord.Text = minfo.PassWord;
            UserName.Text = minfo.UserName;
            Port.Text = minfo.Port + "";
            try
            {
                var data = DataHelper.GetDataBaseNameList(minfo);
                data.Insert(0, "全部");
                com_DataBaseName.DataSource = data;
                if (!string.IsNullOrWhiteSpace(minfo.DataBaseName))
                    com_DataBaseName.SelectedItem = minfo.DataBaseName;
            }
            catch (Exception de)
            {
                MessageBox.Show(de.Message);
            }
        }

        private void Link_DataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                _info.IsCancel = true;
        }

        private void Pass_LeaveEvent(object sender, EventArgs e)
        {
            if (PassWord.Text.Trim() == "")
                return;
            if (Data_Source.Text.Trim() == "")
                MessageBox.Show(@"请填写数据源！");
            else if (!MySql.Checked && !MsSql.Checked)
                MessageBox.Show(@"请选择数据库！");
            else if (UserName.Text.Trim() == "")
                MessageBox.Show(@"请填写用户名！");
            else if (PassWord.Text.Trim() == "")
                MessageBox.Show(@"请填写密码！");
            else
            {
                if (MySql.Checked)
                {
                    int myPort;
                    int.TryParse(Port.Text.Trim(), out myPort);
                    _info.Port = myPort;
                    _info.SqlType = DataBaseType.MySql;
                }
                else
                    _info.SqlType = DataBaseType.MSSQL;
                _info.DataSourceName = Data_Source.Text.Trim();
                _info.UserName = UserName.Text.Trim();
                _info.PassWord = PassWord.Text.Trim();
                try
                {
                    var data = DataHelper.GetDataBaseNameList(_info);
                    data.Insert(0, "全部");
                    com_DataBaseName.DataSource = data;
                }
                catch (Exception de)
                {
                    MessageBox.Show(de.Message);
                }
            }
        }
    }
}
