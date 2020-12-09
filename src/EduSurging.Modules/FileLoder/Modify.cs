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
    public partial class Modify : Form
    {
        TableModel TableModel = null;
        private bool _IsCancel;
        public Modify(ref TableModel model,ref bool IsCancel)
        {
            InitializeComponent();
            this.TableModel = model;
            this._IsCancel = IsCancel;
            TableName.Text = model.Name;
            TableCode.Text = model.Code;
            TableDescription.Text = model.Comment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = TableName.Text;
            string Code = TableCode.Text;
            string Description = TableDescription.Text;

            if (Name.Trim() == "")
            {
                MessageBox.Show("Name不能为空");
                return;
            }
            else if (Code.Trim() == "")
            {
                MessageBox.Show("Code不能为空");
                return;
            }
            else if (Description.Trim() == "")
            {
                MessageBox.Show("Description不能为空");
                return;
            }
            TableModel.Code = Code;
            TableModel.Name = Name;
            TableModel.Comment = Description;
            this.Dispose();
        }

        private void Modify_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                _IsCancel = true;
        }
    }
}
