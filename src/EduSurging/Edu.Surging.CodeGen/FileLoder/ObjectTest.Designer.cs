namespace FileLoder
{
    partial class ObjectTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SendEmail = new System.Windows.Forms.Button();
            this.DeleteBucket = new System.Windows.Forms.Button();
            this.DeleteFile = new System.Windows.Forms.Button();
            this.getUrl = new System.Windows.Forms.Button();
            this.FindBucket = new System.Windows.Forms.Button();
            this.DownFile = new System.Windows.Forms.Button();
            this.Upload = new System.Windows.Forms.Button();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowObjects = new System.Windows.Forms.Button();
            this.Bucket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerUrl = new System.Windows.Forms.TextBox();
            this.showList = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.RichTextBox();
            this.uploadFile = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.SendEmail);
            this.splitContainer1.Panel1.Controls.Add(this.DeleteBucket);
            this.splitContainer1.Panel1.Controls.Add(this.DeleteFile);
            this.splitContainer1.Panel1.Controls.Add(this.getUrl);
            this.splitContainer1.Panel1.Controls.Add(this.FindBucket);
            this.splitContainer1.Panel1.Controls.Add(this.DownFile);
            this.splitContainer1.Panel1.Controls.Add(this.Upload);
            this.splitContainer1.Panel1.Controls.Add(this.ChooseFile);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.Key);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.ShowObjects);
            this.splitContainer1.Panel1.Controls.Add(this.Bucket);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ServerUrl);
            this.splitContainer1.Panel1.Controls.Add(this.showList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.result);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // SendEmail
            // 
            this.SendEmail.Location = new System.Drawing.Point(23, 320);
            this.SendEmail.Name = "SendEmail";
            this.SendEmail.Size = new System.Drawing.Size(75, 23);
            this.SendEmail.TabIndex = 17;
            this.SendEmail.Text = "发送邮件测试";
            this.SendEmail.UseVisualStyleBackColor = true;
            this.SendEmail.Click += new System.EventHandler(this.SendEmail_Click);
            // 
            // DeleteBucket
            // 
            this.DeleteBucket.Location = new System.Drawing.Point(12, 252);
            this.DeleteBucket.Name = "DeleteBucket";
            this.DeleteBucket.Size = new System.Drawing.Size(135, 23);
            this.DeleteBucket.TabIndex = 16;
            this.DeleteBucket.Text = "删除桶";
            this.DeleteBucket.UseVisualStyleBackColor = true;
            this.DeleteBucket.Click += new System.EventHandler(this.DeleteBucket_Click);
            // 
            // DeleteFile
            // 
            this.DeleteFile.Location = new System.Drawing.Point(174, 223);
            this.DeleteFile.Name = "DeleteFile";
            this.DeleteFile.Size = new System.Drawing.Size(134, 23);
            this.DeleteFile.TabIndex = 15;
            this.DeleteFile.Text = "删除文件";
            this.DeleteFile.UseVisualStyleBackColor = true;
            this.DeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // getUrl
            // 
            this.getUrl.Location = new System.Drawing.Point(11, 223);
            this.getUrl.Name = "getUrl";
            this.getUrl.Size = new System.Drawing.Size(134, 23);
            this.getUrl.TabIndex = 14;
            this.getUrl.Text = "获取公共Url";
            this.getUrl.UseVisualStyleBackColor = true;
            this.getUrl.Click += new System.EventHandler(this.getUrl_Click);
            // 
            // FindBucket
            // 
            this.FindBucket.Location = new System.Drawing.Point(174, 136);
            this.FindBucket.Name = "FindBucket";
            this.FindBucket.Size = new System.Drawing.Size(135, 23);
            this.FindBucket.TabIndex = 13;
            this.FindBucket.Text = "查找桶所在数据中心";
            this.FindBucket.UseVisualStyleBackColor = true;
            this.FindBucket.Click += new System.EventHandler(this.FindBucket_ClickAsync);
            // 
            // DownFile
            // 
            this.DownFile.Location = new System.Drawing.Point(175, 194);
            this.DownFile.Name = "DownFile";
            this.DownFile.Size = new System.Drawing.Size(135, 23);
            this.DownFile.TabIndex = 12;
            this.DownFile.Text = "下载文件";
            this.DownFile.UseVisualStyleBackColor = true;
            this.DownFile.Click += new System.EventHandler(this.DownFile_ClickAsync);
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(11, 194);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(135, 23);
            this.Upload.TabIndex = 11;
            this.Upload.Text = "上传文件";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_ClickAsync);
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(75, 76);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(89, 23);
            this.ChooseFile.TabIndex = 10;
            this.ChooseFile.Text = "选择文件";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "文件路径:";
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(74, 109);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(234, 21);
            this.Key.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文件Key:";
            // 
            // ShowObjects
            // 
            this.ShowObjects.Location = new System.Drawing.Point(175, 165);
            this.ShowObjects.Name = "ShowObjects";
            this.ShowObjects.Size = new System.Drawing.Size(134, 23);
            this.ShowObjects.TabIndex = 6;
            this.ShowObjects.Text = "列举桶内所有对象";
            this.ShowObjects.UseVisualStyleBackColor = true;
            this.ShowObjects.Click += new System.EventHandler(this.ShowObjects_ClickAsync);
            // 
            // Bucket
            // 
            this.Bucket.Location = new System.Drawing.Point(74, 48);
            this.Bucket.Name = "Bucket";
            this.Bucket.Size = new System.Drawing.Size(234, 21);
            this.Bucket.TabIndex = 5;
            this.Bucket.Text = "testBucket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "桶名称:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "创建桶";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ServerUrl:";
            // 
            // ServerUrl
            // 
            this.ServerUrl.Location = new System.Drawing.Point(74, 20);
            this.ServerUrl.Name = "ServerUrl";
            this.ServerUrl.Size = new System.Drawing.Size(234, 21);
            this.ServerUrl.TabIndex = 1;
            this.ServerUrl.Text = "http://eos-yunnan-1.cmecloud.cn";
            // 
            // showList
            // 
            this.showList.Location = new System.Drawing.Point(11, 136);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(135, 23);
            this.showList.TabIndex = 0;
            this.showList.Text = "列举所有桶";
            this.showList.UseVisualStyleBackColor = true;
            this.showList.Click += new System.EventHandler(this.showList_ClickAsync);
            // 
            // result
            // 
            this.result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.result.Location = new System.Drawing.Point(0, 0);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(473, 450);
            this.result.TabIndex = 0;
            this.result.Text = "";
            // 
            // uploadFile
            // 
            this.uploadFile.FileName = "上传文件";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "查询测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Query_Click);
            // 
            // ObjectTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ObjectTest";
            this.Text = "ObjectTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerUrl;
        private System.Windows.Forms.Button showList;
        private System.Windows.Forms.RichTextBox result;
        private System.Windows.Forms.TextBox Bucket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ShowObjects;
        private System.Windows.Forms.Button DownFile;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FindBucket;
        private System.Windows.Forms.OpenFileDialog uploadFile;
        private System.Windows.Forms.Button getUrl;
        private System.Windows.Forms.Button DeleteBucket;
        private System.Windows.Forms.Button DeleteFile;
        private System.Windows.Forms.Button SendEmail;
        private System.Windows.Forms.Button button2;
    }
}