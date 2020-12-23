using System;
using System.Linq;
using System.Windows.Forms;
using FileLoder.Helper;

namespace FileLoder
{
    public partial class SaveCode : Form
    {
        private SaveOptions _model;
        private System.Collections.Generic.List<SaveOptions> _old;
        public SaveCode(ref SaveOptions model)
        {
            InitializeComponent();
            _model = model;
            Entity.Checked = true;
            Mappings.Checked = true;
            Base.Checked = true;
            Service.Checked = true;
            ViewModel.Checked = true;
            Function.Checked = true;
            MS.Checked = true;
            Function.Visible = true;
        }
        private void Path_Click(object sender, EventArgs e)
        {
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string filePath = folder.SelectedPath;
                string projectName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.Length - 1 - filePath.LastIndexOf("\\"));
                var str = projectName.Split(new char[] { '.' })[0];
                NameSpace.Text = str;
                label2.Text = filePath;
                API.Text = str;
                MapText.Text = @"I" + str + @"Mapping";
                Repository.Text = @"I" + str + @"Repository";
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() == "") MessageBox.Show(@"请选择代码输出路径。");
            else if (NameSpace.Text.Trim() == "") MessageBox.Show(@"请填写代码生成的项目名称。");
            else if (!MS.Checked && !MySql.Checked && !Oracle.Checked) MessageBox.Show(@"请选择目标数据库。");
            else if (Oracle.Checked && Schmal_Text.Text.Trim() == "")
            {
                MessageBox.Show(@"请填写Oracle数据库的用户名[Schmal]。");
            }
            else
            {
                if (Controller.Checked)
                {
                    if (API.Text.Trim() == "")
                    {
                        MessageBox.Show(@"请填写API所在项目名称。");
                        return;
                    }
                }
                if (Mappings.Checked)
                {
                    if (Map.Text.Trim() == "")
                    {
                        MessageBox.Show(@"请填写映射基类名称。");
                        return;
                    }
                }
                if (Change.Checked)
                {
                    if (Repository.Text.Trim() == "")
                    {
                        MessageBox.Show(@"请填写数据基类名称。");
                        return;
                    }
                }
                if (Service.Checked)
                {
                    if (Repository.Text.Trim() == "")
                    {
                        MessageBox.Show(@"请填写数据基类名称。");
                        return;
                    }
                }
                if (Entity.Checked || Mappings.Checked || Controller.Checked || Service.Checked || ViewModel.Checked || Base.Checked || baseService.Checked)
                {
                    _model.OutPath = label2.Text.Trim();
                    _model.NameSpace = NameSpace.Text;
                    _model.Entity = Entity.Checked;
                    _model.Mappings = Mappings.Checked;
                    _model.Controller = Controller.Checked;
                    _model.Service = Service.Checked;
                    _model.ChangeService = Change.Checked;
                    _model.ViewModels = ViewModel.Checked;
                    _model.Base = Base.Checked;
                    _model.ApiNameSpace = API.Text;
                    _model.MapText = MapText.Text;
                    _model.BaseService = baseService.Checked;
                    _model.RepositoryText = Repository.Text;
                    if (MS.Checked)
                        _model.DataBaseType = DataBaseType.MSSQL;
                    else if (MySql.Checked)
                        _model.DataBaseType = DataBaseType.MySql;
                    else if (Oracle.Checked)
                    {
                        _model.DataBaseType = DataBaseType.Oracle;
                        _model.Schmal = Schmal_Text.Text.Trim();
                    }
                    _model.Procedures = Function.Checked;
                    new XmlLoder().ProcessOptions(_model);
                    Dispose();
                }
                else
                {
                    MessageBox.Show(@"请选择代码生成类型。");
                }
            }
        }

        private void SaveCode_Load(object sender, EventArgs e)
        {
            _old = new XmlLoder().OptionsInfo.Where(t => t.CreateCodeType == _model.CreateCodeType).ToList();
            _old.ForEach(item =>
            {
                comboBox1.Items.Add(item.OutPath);
            });
        }

        private void SaveCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                _model.IsCancel = true;
        }
        private void MS_CheckedChanged(object sender, EventArgs e)
        {
            var check = sender as RadioButton;
            if (check.Name == "MS")
            {
                Function.Visible = true;
                Schmal.Visible = false;
                Schmal_Text.Visible = false;
            }
            else if (check.Name == "MySql")
            {
                Function.Visible = false;
                Schmal.Visible = false;
                Schmal_Text.Visible = false;
            }
            else if (check.Name == "Oracle")
            {
                Function.Visible = false;
                Schmal.Visible = true;
                Schmal_Text.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var old = _old[comboBox1.SelectedIndex];
            if (old != null)
            {
                string filePath = old.OutPath;
                Entity.Checked = old.Entity;
                Mappings.Checked = old.Mappings;
                Controller.Checked = old.Controller;
                Service.Checked = old.Service;
                Change.Checked = old.ChangeService;
                ViewModel.Checked = old.ViewModels;
                Function.Checked = old.Procedures;
                if (old.DataBaseType == DataBaseType.MSSQL)
                    MS.Checked = true;
                else if (old.DataBaseType == DataBaseType.MySql)
                    MySql.Checked = true;
                else if (old.DataBaseType == DataBaseType.Oracle)
                    Oracle.Checked = true;
                Base.Checked = old.Base;
                baseService.Checked = old.BaseService;
                NameSpace.Text = old.NameSpace;
                label2.Text = filePath;
                API.Text = old.ApiNameSpace;
                MapText.Text = old.MapText;
                Repository.Text = old.RepositoryText;
            }
        }
    }
}
