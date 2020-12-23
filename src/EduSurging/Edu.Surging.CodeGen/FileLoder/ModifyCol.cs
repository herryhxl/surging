using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileLoder.TemplateModel;

namespace FileLoder
{
    public partial class ModifyCol : Form
    {
        ColumnsModel TableModel = null;
        private bool _isCancel;
        public ModifyCol(ref ColumnsModel model,ref bool isCancel)
        {
            InitializeComponent();
            this.TableModel = model;
            this._isCancel = isCancel;
            ColName.Text = model.Name;
            ColCode.Text = model.Code;
            ColDataType.Text = model.DataType;
            if (model.PK) PK.Checked = true;
            if (model.FK)
            {
                FK.Checked = true;
                SearchOrder.Checked = true;
            }
            else if (model.Virtual)
            {
                VK.Checked = true;
            }
            if (model.IsAutoAdd)
                AutoAdd.Checked = true;
            if (model.Code.StartsWith("E.") && model.DataType == "int")
            {
                Em.Checked = true;
                ColRemark.Text = model.Remark;
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

            if (model.FK )    Text = "修改外键关系";
            else if (model.Virtual) Text = "修改虚拟关系";
            else Text = "修改字段信息";

            DataTable dt = new DataTable();//创建一个数据集
            dt.Columns.Add("key", typeof(String));
            dt.Columns.Add("val", typeof(String));

            DataRow dr = dt.NewRow();
            dr[0] = "无";
            dr[1] = (int)SearchType.Null;
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "相等";
            dr1[1] = (int)SearchType.Equal;
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2[0] = "模糊相似";
            dr2[1] = (int)SearchType.Like;
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3[0] = "范围";
            dr3[1] = (int)SearchType.Range;
            dt.Rows.Add(dr3);
            DataRow dr4 = dt.NewRow();
            dr3[0] = "包含";
            dr3[1] = (int)SearchType.In;
            dt.Rows.Add(dr4);

            SearchOrder.Checked = model.OrderBy;

            searchCombox.DataSource = dt;
            searchCombox.DisplayMember = "key";//id这个字段为显示的值
            searchCombox.ValueMember = "val";//val这个字段为后台获取的值

            if (model.Search != SearchType.Null)
            {
                int p = (int) model.Search;
                searchCombox.SelectedValue = p;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = ColName.Text;
            string Code = ColCode.Text;
            string Remark = ColRemark.Text;

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
            if (Em.Checked)
            {
                if (Code.IndexOf("E.")!=-1)
                {
                    if (Remark.Trim() == "")
                    {
                        MessageBox.Show("内容不能为空。");
                        return;
                    }
                    string[] t = Remark.Split(new char[] { ',' });
                    if (t.Count() <= 0)
                    {
                        MessageBox.Show("内容不能为空。");
                        return;
                    }
                    else
                    {
                        t.ToList().ForEach(item =>
                        {
                            string[] r = item.Split(new char[] { ':' });
                            if (r.Count() != 2)
                            {
                                MessageBox.Show("内容格式不正确，应为1:t1,3:t2");
                                return;
                            }
                            else
                            {
                                r.ToList().ForEach(item2 =>
                                {
                                    try
                                    {
                                        int p = Convert.ToInt32(item2[0]);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("内容不能为空。");
                                        return;
                                    }
                                });
                            }

                        });
                    }
                    TableModel.Code = "E." + Code;
                }
                else TableModel.Code = Code;
            }
            else
            {
                TableModel.Code = Code;
            }
            TableModel.Name = Name;
            TableModel.Remark = Remark;
            if (TableModel.FK)
            {
                TableModel.OrderBy = true;
            }
            else if (TableModel.Virtual)
            {
                TableModel.OrderBy = false;
            }
            else
            {
                TableModel.OrderBy = SearchOrder.Checked;
            }
            TableModel.IsAutoAdd = AutoAdd.Checked;
            TableModel.PK = PK.Checked;
            TableModel.FK = FK.Checked;
            TableModel.Virtual = FK.Checked;
            if (searchCombox.SelectedIndex != 0)
            {
                TableModel.Search = (SearchType)Convert.ToInt32(searchCombox.SelectedValue);
            }
            this.Dispose();
        }

        private void PK_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void FK_CheckedChanged(object sender, EventArgs e)
        {
            if (FK.Checked) VK.Checked = false;
        }

        private void VK_CheckedChanged(object sender, EventArgs e)
        {
            if (VK.Checked) FK.Checked = false;
        }

        private void Em_CheckedChanged(object sender, EventArgs e)
        {
            if (ColDataType.Text.Trim().ToLower() == "int")
            {
                Em.Checked = Em.Checked;
                panel1.Visible = Em.Checked;
            }
            else
            {
                Em.Checked = false;
                MessageBox.Show("非int字段不能设置为枚举类型");
            }
        }

        private void ColDataType_TextChanged(object sender, EventArgs e)
        {
            string text = ColDataType.Text.Trim().ToLower();
            if (text != "int")
            {
                if (Em.Checked) Em.Checked = false;
            }
        }

        private void ModifyCol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                _isCancel = true;
        }
    }
}
