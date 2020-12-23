namespace FileLoder
{
    partial class ModifyCol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ColName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ColCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ColRemark = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ColDataType = new System.Windows.Forms.TextBox();
            this.SearchOrder = new System.Windows.Forms.CheckBox();
            this.Em = new System.Windows.Forms.CheckBox();
            this.PK = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FK = new System.Windows.Forms.CheckBox();
            this.VK = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchCombox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AutoAdd = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "中文描述:";
            // 
            // ColName
            // 
            this.ColName.Location = new System.Drawing.Point(77, 6);
            this.ColName.Name = "ColName";
            this.ColName.Size = new System.Drawing.Size(288, 21);
            this.ColName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "字段名:";
            // 
            // ColCode
            // 
            this.ColCode.Location = new System.Drawing.Point(77, 58);
            this.ColCode.Name = "ColCode";
            this.ColCode.Size = new System.Drawing.Size(115, 21);
            this.ColCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "枚举内容:";
            // 
            // ColRemark
            // 
            this.ColRemark.Location = new System.Drawing.Point(68, 3);
            this.ColRemark.Name = "ColRemark";
            this.ColRemark.Size = new System.Drawing.Size(291, 72);
            this.ColRemark.TabIndex = 5;
            this.ColRemark.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.Location = new System.Drawing.Point(74, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据类型:";
            // 
            // ColDataType
            // 
            this.ColDataType.Location = new System.Drawing.Point(77, 33);
            this.ColDataType.Name = "ColDataType";
            this.ColDataType.Size = new System.Drawing.Size(180, 21);
            this.ColDataType.TabIndex = 8;
            this.ColDataType.TextChanged += new System.EventHandler(this.ColDataType_TextChanged);
            // 
            // SearchOrder
            // 
            this.SearchOrder.AutoSize = true;
            this.SearchOrder.Location = new System.Drawing.Point(239, 86);
            this.SearchOrder.Name = "SearchOrder";
            this.SearchOrder.Size = new System.Drawing.Size(48, 16);
            this.SearchOrder.TabIndex = 10;
            this.SearchOrder.Text = "排序";
            this.SearchOrder.UseVisualStyleBackColor = true;
            // 
            // Em
            // 
            this.Em.AutoSize = true;
            this.Em.Location = new System.Drawing.Point(185, 86);
            this.Em.Name = "Em";
            this.Em.Size = new System.Drawing.Size(48, 16);
            this.Em.TabIndex = 11;
            this.Em.Text = "枚举";
            this.Em.UseVisualStyleBackColor = true;
            this.Em.CheckedChanged += new System.EventHandler(this.Em_CheckedChanged);
            // 
            // PK
            // 
            this.PK.AutoSize = true;
            this.PK.Location = new System.Drawing.Point(77, 86);
            this.PK.Name = "PK";
            this.PK.Size = new System.Drawing.Size(48, 16);
            this.PK.TabIndex = 12;
            this.PK.Text = "主键";
            this.PK.UseVisualStyleBackColor = true;
            this.PK.CheckedChanged += new System.EventHandler(this.PK_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ColRemark);
            this.panel1.Location = new System.Drawing.Point(6, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 78);
            this.panel1.TabIndex = 13;
            // 
            // FK
            // 
            this.FK.AutoSize = true;
            this.FK.Location = new System.Drawing.Point(131, 86);
            this.FK.Name = "FK";
            this.FK.Size = new System.Drawing.Size(48, 16);
            this.FK.TabIndex = 14;
            this.FK.Text = "外键";
            this.FK.UseVisualStyleBackColor = true;
            this.FK.CheckedChanged += new System.EventHandler(this.FK_CheckedChanged);
            // 
            // VK
            // 
            this.VK.AutoSize = true;
            this.VK.Location = new System.Drawing.Point(293, 86);
            this.VK.Name = "VK";
            this.VK.Size = new System.Drawing.Size(72, 16);
            this.VK.TabIndex = 15;
            this.VK.Text = "虚拟关系";
            this.VK.UseVisualStyleBackColor = true;
            this.VK.CheckedChanged += new System.EventHandler(this.VK_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "搜索类型:";
            // 
            // searchCombox
            // 
            this.searchCombox.FormattingEnabled = true;
            this.searchCombox.Location = new System.Drawing.Point(263, 61);
            this.searchCombox.Name = "searchCombox";
            this.searchCombox.Size = new System.Drawing.Size(102, 20);
            this.searchCombox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "键值:";
            // 
            // AutoAdd
            // 
            this.AutoAdd.AutoSize = true;
            this.AutoAdd.Location = new System.Drawing.Point(272, 35);
            this.AutoAdd.Name = "AutoAdd";
            this.AutoAdd.Size = new System.Drawing.Size(48, 16);
            this.AutoAdd.TabIndex = 19;
            this.AutoAdd.Text = "自增";
            this.AutoAdd.UseVisualStyleBackColor = true;
            // 
            // ModifyCol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 219);
            this.Controls.Add(this.AutoAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchCombox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VK);
            this.Controls.Add(this.FK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PK);
            this.Controls.Add(this.Em);
            this.Controls.Add(this.SearchOrder);
            this.Controls.Add(this.ColDataType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ColCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ModifyCol";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改关系";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModifyCol_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ColName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ColRemark;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ColDataType;
        private System.Windows.Forms.CheckBox SearchOrder;
        private System.Windows.Forms.CheckBox Em;
        private System.Windows.Forms.CheckBox PK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox FK;
        private System.Windows.Forms.CheckBox VK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox searchCombox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox AutoAdd;
    }
}