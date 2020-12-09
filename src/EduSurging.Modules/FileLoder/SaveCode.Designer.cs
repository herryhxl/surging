namespace FileLoder
{
    partial class SaveCode
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
            this.Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NameSpace = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.API = new System.Windows.Forms.TextBox();
            this.Controller = new System.Windows.Forms.CheckBox();
            this.Base = new System.Windows.Forms.CheckBox();
            this.ViewModel = new System.Windows.Forms.CheckBox();
            this.Mappings = new System.Windows.Forms.CheckBox();
            this.Service = new System.Windows.Forms.CheckBox();
            this.Entity = new System.Windows.Forms.CheckBox();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baseService = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Change = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Repository = new System.Windows.Forms.TextBox();
            this.Map = new System.Windows.Forms.GroupBox();
            this.MapText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Schmal = new System.Windows.Forms.Label();
            this.Schmal_Text = new System.Windows.Forms.TextBox();
            this.Function = new System.Windows.Forms.CheckBox();
            this.Oracle = new System.Windows.Forms.RadioButton();
            this.MySql = new System.Windows.Forms.RadioButton();
            this.MS = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Map.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(44, 387);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "确定";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "保存路径:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 8;
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(349, 4);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(75, 23);
            this.Path.TabIndex = 9;
            this.Path.Text = "浏览..";
            this.Path.UseVisualStyleBackColor = true;
            this.Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "类库项目名称:";
            // 
            // NameSpace
            // 
            this.NameSpace.Location = new System.Drawing.Point(107, 35);
            this.NameSpace.Name = "NameSpace";
            this.NameSpace.Size = new System.Drawing.Size(315, 21);
            this.NameSpace.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.API);
            this.groupBox1.Controls.Add(this.Controller);
            this.groupBox1.Location = new System.Drawing.Point(5, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 68);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Api控制器";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "API项目名称:";
            // 
            // API
            // 
            this.API.Location = new System.Drawing.Point(100, 42);
            this.API.Name = "API";
            this.API.Size = new System.Drawing.Size(311, 21);
            this.API.TabIndex = 14;
            // 
            // Controller
            // 
            this.Controller.AutoSize = true;
            this.Controller.Location = new System.Drawing.Point(15, 20);
            this.Controller.Name = "Controller";
            this.Controller.Size = new System.Drawing.Size(150, 16);
            this.Controller.TabIndex = 3;
            this.Controller.Text = "控制器(ApiController)";
            this.Controller.UseVisualStyleBackColor = true;
            // 
            // Base
            // 
            this.Base.AutoSize = true;
            this.Base.Location = new System.Drawing.Point(74, 20);
            this.Base.Name = "Base";
            this.Base.Size = new System.Drawing.Size(72, 16);
            this.Base.TabIndex = 7;
            this.Base.Text = "基础接口";
            this.Base.UseVisualStyleBackColor = true;
            // 
            // ViewModel
            // 
            this.ViewModel.AutoSize = true;
            this.ViewModel.Location = new System.Drawing.Point(153, 20);
            this.ViewModel.Name = "ViewModel";
            this.ViewModel.Size = new System.Drawing.Size(72, 16);
            this.ViewModel.TabIndex = 4;
            this.ViewModel.Text = "视图模型";
            this.ViewModel.UseVisualStyleBackColor = true;
            // 
            // Mappings
            // 
            this.Mappings.AutoSize = true;
            this.Mappings.Location = new System.Drawing.Point(15, 20);
            this.Mappings.Name = "Mappings";
            this.Mappings.Size = new System.Drawing.Size(114, 16);
            this.Mappings.TabIndex = 2;
            this.Mappings.Text = "映射（Mappings)";
            this.Mappings.UseVisualStyleBackColor = true;
            // 
            // Service
            // 
            this.Service.AutoSize = true;
            this.Service.Location = new System.Drawing.Point(15, 15);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(108, 16);
            this.Service.TabIndex = 1;
            this.Service.Text = "接口及实现方法";
            this.Service.UseVisualStyleBackColor = true;
            // 
            // Entity
            // 
            this.Entity.AutoSize = true;
            this.Entity.Location = new System.Drawing.Point(15, 20);
            this.Entity.Name = "Entity";
            this.Entity.Size = new System.Drawing.Size(48, 16);
            this.Entity.TabIndex = 0;
            this.Entity.Text = "模型";
            this.Entity.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baseService);
            this.groupBox2.Controls.Add(this.Entity);
            this.groupBox2.Controls.Add(this.ViewModel);
            this.groupBox2.Controls.Add(this.Base);
            this.groupBox2.Location = new System.Drawing.Point(5, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 50);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基类";
            // 
            // baseService
            // 
            this.baseService.AutoSize = true;
            this.baseService.Location = new System.Drawing.Point(231, 20);
            this.baseService.Name = "baseService";
            this.baseService.Size = new System.Drawing.Size(84, 16);
            this.baseService.TabIndex = 8;
            this.baseService.Text = "基础查询类";
            this.baseService.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Change);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Repository);
            this.groupBox3.Controls.Add(this.Service);
            this.groupBox3.Location = new System.Drawing.Point(5, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 64);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接口";
            // 
            // Change
            // 
            this.Change.AutoSize = true;
            this.Change.Location = new System.Drawing.Point(129, 15);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(96, 16);
            this.Change.TabIndex = 8;
            this.Change.Text = "状态改变方法";
            this.Change.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据基类名:";
            // 
            // Repository
            // 
            this.Repository.Location = new System.Drawing.Point(100, 37);
            this.Repository.Name = "Repository";
            this.Repository.Size = new System.Drawing.Size(311, 21);
            this.Repository.TabIndex = 2;
            // 
            // Map
            // 
            this.Map.Controls.Add(this.MapText);
            this.Map.Controls.Add(this.label5);
            this.Map.Controls.Add(this.Mappings);
            this.Map.Location = new System.Drawing.Point(5, 118);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(417, 64);
            this.Map.TabIndex = 15;
            this.Map.TabStop = false;
            this.Map.Text = "映射";
            // 
            // MapText
            // 
            this.MapText.Location = new System.Drawing.Point(100, 39);
            this.MapText.Name = "MapText";
            this.MapText.Size = new System.Drawing.Size(311, 21);
            this.MapText.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "继承基类名:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Schmal);
            this.groupBox4.Controls.Add(this.Schmal_Text);
            this.groupBox4.Controls.Add(this.Function);
            this.groupBox4.Controls.Add(this.Oracle);
            this.groupBox4.Controls.Add(this.MySql);
            this.groupBox4.Controls.Add(this.MS);
            this.groupBox4.Location = new System.Drawing.Point(5, 332);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(417, 49);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "目标及配置";
            // 
            // Schmal
            // 
            this.Schmal.AutoSize = true;
            this.Schmal.Location = new System.Drawing.Point(202, 23);
            this.Schmal.Name = "Schmal";
            this.Schmal.Size = new System.Drawing.Size(47, 12);
            this.Schmal.TabIndex = 20;
            this.Schmal.Text = "Schmal:";
            // 
            // Schmal_Text
            // 
            this.Schmal_Text.Location = new System.Drawing.Point(250, 20);
            this.Schmal_Text.Name = "Schmal_Text";
            this.Schmal_Text.Size = new System.Drawing.Size(161, 21);
            this.Schmal_Text.TabIndex = 19;
            // 
            // Function
            // 
            this.Function.AutoSize = true;
            this.Function.Location = new System.Drawing.Point(204, 21);
            this.Function.Name = "Function";
            this.Function.Size = new System.Drawing.Size(168, 16);
            this.Function.TabIndex = 18;
            this.Function.Text = "存储过程及数据库Function";
            this.Function.UseVisualStyleBackColor = true;
            this.Function.Visible = false;
            // 
            // Oracle
            // 
            this.Oracle.AutoSize = true;
            this.Oracle.Location = new System.Drawing.Point(133, 21);
            this.Oracle.Name = "Oracle";
            this.Oracle.Size = new System.Drawing.Size(59, 16);
            this.Oracle.TabIndex = 17;
            this.Oracle.Text = "Oracle";
            this.Oracle.UseVisualStyleBackColor = true;
            this.Oracle.CheckedChanged += new System.EventHandler(this.MS_CheckedChanged);
            // 
            // MySql
            // 
            this.MySql.AutoSize = true;
            this.MySql.Location = new System.Drawing.Point(74, 21);
            this.MySql.Name = "MySql";
            this.MySql.Size = new System.Drawing.Size(53, 16);
            this.MySql.TabIndex = 16;
            this.MySql.Text = "MySql";
            this.MySql.UseVisualStyleBackColor = true;
            this.MySql.CheckedChanged += new System.EventHandler(this.MS_CheckedChanged);
            // 
            // MS
            // 
            this.MS.AutoSize = true;
            this.MS.Location = new System.Drawing.Point(19, 21);
            this.MS.Name = "MS";
            this.MS.Size = new System.Drawing.Size(53, 16);
            this.MS.TabIndex = 15;
            this.MS.Text = "MSSQL";
            this.MS.UseVisualStyleBackColor = true;
            this.MS.CheckedChanged += new System.EventHandler(this.MS_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 20);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SaveCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 423);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NameSpace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SaveCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成代码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveCode_FormClosing);
            this.Load += new System.EventHandler(this.SaveCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Map.ResumeLayout(false);
            this.Map.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameSpace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Service;
        private System.Windows.Forms.CheckBox Entity;
        private System.Windows.Forms.CheckBox ViewModel;
        private System.Windows.Forms.CheckBox Controller;
        private System.Windows.Forms.CheckBox Mappings;
        private System.Windows.Forms.FolderBrowserDialog folder;
        private System.Windows.Forms.CheckBox Base;
        private System.Windows.Forms.TextBox API;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Repository;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox Map;
        private System.Windows.Forms.TextBox MapText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox Function;
        private System.Windows.Forms.RadioButton Oracle;
        private System.Windows.Forms.RadioButton MySql;
        private System.Windows.Forms.RadioButton MS;
        private System.Windows.Forms.Label Schmal;
        private System.Windows.Forms.TextBox Schmal_Text;
        private System.Windows.Forms.CheckBox Change;
        private System.Windows.Forms.CheckBox baseService;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}