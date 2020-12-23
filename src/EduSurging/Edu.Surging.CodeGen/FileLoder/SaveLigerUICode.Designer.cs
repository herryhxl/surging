namespace FileLoder
{
    partial class SaveLigerUICode
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ViewModel = new System.Windows.Forms.CheckBox();
            this.NameSpace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.API = new System.Windows.Forms.TextBox();
            this.Controller = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ViewModel);
            this.groupBox2.Location = new System.Drawing.Point(14, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 47);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基类";
            // 
            // ViewModel
            // 
            this.ViewModel.AutoSize = true;
            this.ViewModel.Location = new System.Drawing.Point(15, 20);
            this.ViewModel.Name = "ViewModel";
            this.ViewModel.Size = new System.Drawing.Size(174, 16);
            this.ViewModel.TabIndex = 4;
            this.ViewModel.Text = "视图（列表View和编辑View)";
            this.ViewModel.UseVisualStyleBackColor = true;
            // 
            // NameSpace
            // 
            this.NameSpace.Location = new System.Drawing.Point(116, 35);
            this.NameSpace.Name = "NameSpace";
            this.NameSpace.Size = new System.Drawing.Size(241, 21);
            this.NameSpace.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "类库项目名称:";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(358, 4);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(75, 23);
            this.Path.TabIndex = 20;
            this.Path.Text = "浏览..";
            this.Path.UseVisualStyleBackColor = true;
            this.Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "保存路径:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(66, 377);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 17;
            this.Save.Text = "确定";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.API);
            this.groupBox1.Controls.Add(this.Controller);
            this.groupBox1.Location = new System.Drawing.Point(14, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 68);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制器";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "控制器命名空间:";
            // 
            // API
            // 
            this.API.Location = new System.Drawing.Point(114, 39);
            this.API.Name = "API";
            this.API.Size = new System.Drawing.Size(241, 21);
            this.API.TabIndex = 14;
            // 
            // Controller
            // 
            this.Controller.AutoSize = true;
            this.Controller.Location = new System.Drawing.Point(15, 20);
            this.Controller.Name = "Controller";
            this.Controller.Size = new System.Drawing.Size(132, 16);
            this.Controller.TabIndex = 3;
            this.Controller.Text = "控制器(Controller)";
            this.Controller.UseVisualStyleBackColor = true;
            // 
            // SaveLigerUICode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.NameSpace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaveLigerUICode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成LigerUI代码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveLigerUICode_FormClosing);
            this.Load += new System.EventHandler(this.SaveLigerUICode_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ViewModel;
        private System.Windows.Forms.TextBox NameSpace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.FolderBrowserDialog folder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox API;
        private System.Windows.Forms.CheckBox Controller;
    }
}