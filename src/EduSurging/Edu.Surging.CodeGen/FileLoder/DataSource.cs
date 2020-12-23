using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileLoder.Helper;

namespace FileLoder
{
    public partial class DataSource : Form
    {
        SaveOptions _model = null;
        public DataSource(ref SaveOptions model)
        {
            InitializeComponent();
            this._model = model;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string filePath = folder.SelectedPath;
                Path.Text = filePath;
                string projectName = filePath.Substring(filePath.LastIndexOf("\\", StringComparison.Ordinal) + 1, filePath.Length - 1 - filePath.LastIndexOf("\\", StringComparison.Ordinal));
                Project.Text = projectName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Path.Text.Trim() == "") MessageBox.Show(@"请选择代码输出路径。");
            else if (Project.Text.Trim() == "") MessageBox.Show(@"请填写代码生成的项目名称。");
            else
            {
                _model.OutPath = Path.Text.Trim();
                _model.NameSpace = Project.Text;
                _model.Entity = Entity.Checked;
                _model.Base = Base.Checked;
                _model.Service = Service.Checked;
                _model.ViewModels = ViewModel.Checked;
                new XmlLoder().ProcessOptions(_model);
                Dispose();
            }
        }

        private void DataSource_Load(object sender, EventArgs e)
        {
            if (_model.CreateCodeType == CreateCodeType.AdoNet代码)
            {
                ViewModel.Text = @"BLL业务逻辑";
                Base.Text = @"接口文件";
                Service.Text = @"接口实现文件";
            }
            var old=new XmlLoder().OptionsInfo.FirstOrDefault(t => t.CreateCodeType == _model.CreateCodeType);
            if (old != null)
            {
                string filePath=old.OutPath;
                Path.Text = filePath;
                Project.Text = old.NameSpace;
                Base.Checked = old.Base;
                Entity.Checked = old.Entity;
                ViewModel.Checked = old.ViewModels;
                Service.Checked = old.Service;
            } 
        }

        private void DataSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                _model.IsCancel = true;
        }
    }
}
