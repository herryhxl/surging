namespace FileLoder
{
    partial class Link_DataBase
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.MySql = new System.Windows.Forms.RadioButton();
            this.MsSql = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PassWord = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Port_Tips = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Data_Source = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.com_DataBaseName = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Port);
            this.groupBox1.Controls.Add(this.MySql);
            this.groupBox1.Controls.Add(this.MsSql);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库类型";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(218, 19);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(80, 21);
            this.Port.TabIndex = 2;
            this.Port.Text = "3306";
            this.Port_Tips.SetToolTip(this.Port, "MySql数据库链接的端口号");
            this.Port.Visible = false;
            // 
            // MySql
            // 
            this.MySql.AutoSize = true;
            this.MySql.Location = new System.Drawing.Point(123, 20);
            this.MySql.Name = "MySql";
            this.MySql.Size = new System.Drawing.Size(89, 16);
            this.MySql.TabIndex = 1;
            this.MySql.Text = "MySql数据库";
            this.MySql.UseVisualStyleBackColor = true;
            this.MySql.CheckedChanged += new System.EventHandler(this.My_Sql_ChangeEvent);
            // 
            // MsSql
            // 
            this.MsSql.AutoSize = true;
            this.MsSql.Checked = true;
            this.MsSql.Location = new System.Drawing.Point(28, 20);
            this.MsSql.Name = "MsSql";
            this.MsSql.Size = new System.Drawing.Size(89, 16);
            this.MsSql.TabIndex = 0;
            this.MsSql.TabStop = true;
            this.MsSql.Text = "MSSQL数据库";
            this.MsSql.UseVisualStyleBackColor = true;
            this.MsSql.CheckedChanged += new System.EventHandler(this.MSSql_Change);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(85, 108);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(192, 21);
            this.UserName.TabIndex = 2;
            this.UserName.Text = "sa";
            this.Port_Tips.SetToolTip(this.UserName, "连接数据库的账号");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码";
            // 
            // PassWord
            // 
            this.PassWord.Location = new System.Drawing.Point(85, 142);
            this.PassWord.Name = "PassWord";
            this.PassWord.PasswordChar = '*';
            this.PassWord.Size = new System.Drawing.Size(192, 21);
            this.PassWord.TabIndex = 4;
            this.Port_Tips.SetToolTip(this.PassWord, "连接数据库对应账号的密码");
            this.PassWord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Key_UP);
            this.PassWord.Leave += new System.EventHandler(this.Pass_LeaveEvent);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Sure_Click);
            // 
            // Port_Tips
            // 
            this.Port_Tips.ToolTipTitle = "MySql端口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据源";
            // 
            // Data_Source
            // 
            this.Data_Source.FormattingEnabled = true;
            this.Data_Source.Location = new System.Drawing.Point(85, 78);
            this.Data_Source.Name = "Data_Source";
            this.Data_Source.Size = new System.Drawing.Size(192, 20);
            this.Data_Source.TabIndex = 9;
            this.Data_Source.Text = ".";
            this.Data_Source.SelectedIndexChanged += new System.EventHandler(this.Data_Source_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "数据库";
            // 
            // com_DataBaseName
            // 
            this.com_DataBaseName.FormattingEnabled = true;
            this.com_DataBaseName.Location = new System.Drawing.Point(85, 172);
            this.com_DataBaseName.Name = "com_DataBaseName";
            this.com_DataBaseName.Size = new System.Drawing.Size(192, 20);
            this.com_DataBaseName.TabIndex = 11;
            // 
            // Link_DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 234);
            this.Controls.Add(this.com_DataBaseName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Data_Source);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Link_DataBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接数据库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Link_DataBase_FormClosing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton MySql;
        private System.Windows.Forms.RadioButton MsSql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PassWord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.ToolTip Port_Tips;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Data_Source;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox com_DataBaseName;
    }
}