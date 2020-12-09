namespace FileLoder
{
    partial class DataSource
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
            this.Path = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lable = new System.Windows.Forms.Label();
            this.Project = new System.Windows.Forms.TextBox();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Entity = new System.Windows.Forms.CheckBox();
            this.ViewModel = new System.Windows.Forms.CheckBox();
            this.Base = new System.Windows.Forms.CheckBox();
            this.Service = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存路径:";
            // 
            // Path
            // 
            this.Path.AutoSize = true;
            this.Path.Location = new System.Drawing.Point(72, 9);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(0, 12);
            this.Path.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(14, 36);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(59, 12);
            this.lable.TabIndex = 4;
            this.lable.Text = "项目名称:";
            // 
            // Project
            // 
            this.Project.Location = new System.Drawing.Point(79, 33);
            this.Project.Name = "Project";
            this.Project.Size = new System.Drawing.Size(183, 21);
            this.Project.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Service);
            this.groupBox2.Controls.Add(this.Entity);
            this.groupBox2.Controls.Add(this.ViewModel);
            this.groupBox2.Controls.Add(this.Base);
            this.groupBox2.Location = new System.Drawing.Point(14, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 77);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基类";
            // 
            // Entity
            // 
            this.Entity.AutoSize = true;
            this.Entity.Location = new System.Drawing.Point(19, 20);
            this.Entity.Name = "Entity";
            this.Entity.Size = new System.Drawing.Size(102, 16);
            this.Entity.TabIndex = 0;
            this.Entity.Text = "模型（Model）";
            this.Entity.UseVisualStyleBackColor = true;
            // 
            // ViewModel
            // 
            this.ViewModel.AutoSize = true;
            this.ViewModel.Location = new System.Drawing.Point(19, 42);
            this.ViewModel.Name = "ViewModel";
            this.ViewModel.Size = new System.Drawing.Size(150, 16);
            this.ViewModel.TabIndex = 4;
            this.ViewModel.Text = "视图模型（ViewModels)";
            this.ViewModel.UseVisualStyleBackColor = true;
            // 
            // Base
            // 
            this.Base.AutoSize = true;
            this.Base.Location = new System.Drawing.Point(133, 20);
            this.Base.Name = "Base";
            this.Base.Size = new System.Drawing.Size(96, 16);
            this.Base.TabIndex = 7;
            this.Base.Text = "基类（Base）";
            this.Base.UseVisualStyleBackColor = true;
            // 
            // Service
            // 
            this.Service.AutoSize = true;
            this.Service.Location = new System.Drawing.Point(235, 20);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(108, 16);
            this.Service.TabIndex = 8;
            this.Service.Text = "接口及实现方法";
            this.Service.UseVisualStyleBackColor = true;
            // 
            // DataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 174);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Project);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库生成代码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataSource_FormClosing);
            this.Load += new System.EventHandler(this.DataSource_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.TextBox Project;
        private System.Windows.Forms.FolderBrowserDialog folder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Entity;
        private System.Windows.Forms.CheckBox ViewModel;
        private System.Windows.Forms.CheckBox Base;
        private System.Windows.Forms.CheckBox Service;
    }
}