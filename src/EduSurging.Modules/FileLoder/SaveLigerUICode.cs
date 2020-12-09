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
    public partial class SaveLigerUICode : Form
    {
        private SaveOptions _model;
        public SaveLigerUICode(ref SaveOptions model)
        {
            InitializeComponent();
            _model = model;
            Controller.Checked = true;
            ViewModel.Checked = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() == "") MessageBox.Show(@"请选择代码输出路径。");
            else if (NameSpace.Text.Trim() == "") MessageBox.Show(@"请填写代码生成的项目名称。");
            else
            {
                if (Controller.Checked)
                {
                    if (API.Text.Trim() == "")
                    {
                        MessageBox.Show(@"请填写项目命名空间。");
                        return;
                    }
                }
                if ( Controller.Checked ||  ViewModel.Checked )
                {
                    _model.OutPath = label2.Text.Trim();
                    _model.NameSpace = NameSpace.Text;
                    _model.Controller = Controller.Checked;
                    _model.ViewModels = ViewModel.Checked;
                    _model.ApiNameSpace = API.Text;
                    new XmlLoder().ProcessOptions(_model);
                    Dispose();
                }
                else
                {
                    MessageBox.Show(@"请选择代码生成类型。");
                }
            }
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
            }
        }

        private void SaveLigerUICode_Load(object sender, EventArgs e)
        {
            var old = new XmlLoder().OptionsInfo.FirstOrDefault(t => t.CreateCodeType == _model.CreateCodeType);
            if (old != null)
            {
                string filePath = old.OutPath;
                Controller.Checked = old.Controller;
                ViewModel.Checked = old.ViewModels;
                NameSpace.Text = old.NameSpace;
                label2.Text = filePath;
                API.Text = old.ApiNameSpace;
            }
        }

        private void SaveLigerUICode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                _model.IsCancel = true;
        }
    }
}
