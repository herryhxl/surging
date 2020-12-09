namespace FileLoder
{
    partial class Modify
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
            this.TableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TableCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TableDescription = new System.Windows.Forms.RichTextBox();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称:";
            // 
            // TableName
            // 
            this.TableName.Location = new System.Drawing.Point(53, 6);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(270, 21);
            this.TableName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "表名:";
            // 
            // TableCode
            // 
            this.TableCode.Location = new System.Drawing.Point(53, 33);
            this.TableCode.Name = "TableCode";
            this.TableCode.Size = new System.Drawing.Size(270, 21);
            this.TableCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "描述:";
            // 
            // TableDescription
            // 
            this.TableDescription.Location = new System.Drawing.Point(53, 67);
            this.TableDescription.Name = "TableDescription";
            this.TableDescription.Size = new System.Drawing.Size(267, 139);
            this.TableDescription.TabIndex = 5;
            this.TableDescription.Text = "";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(53, 212);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 242);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.TableDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TableCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TableName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Modify";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改表信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Modify_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TableCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TableDescription;
        private System.Windows.Forms.Button Save;
    }
}