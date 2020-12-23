using Amazon.Runtime;
using FileLoder.AWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoder
{
    public partial class ObjectTest : Form
    {
        public ObjectTest()
        {
            InitializeComponent();
        }

        private async void showList_ClickAsync(object sender, EventArgs e)
        {
            var response = await AmazonUpload.GetBuckets();
            response.Buckets.ForEach(item =>
            {
                result.Text += string.Format("BucketName:{0}-CreationDate{1}\r\n", item.BucketName, item.CreationDate);
            });
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var response =  AmazonUpload.CreateBucket(Bucket.Text);
            }
            catch (AmazonClientException e1)
            {

            }
        }

        private async void FindBucket_ClickAsync(object sender, EventArgs e)
        {
            var response = await AmazonUpload.GetLocation(Bucket.Text);
            result.Text += Bucket.Text + "所在数据中心为：" + response.Location.ToString() + "\r\n";
        }

        private async void ShowObjects_ClickAsync(object sender, EventArgs e)
        {
            var response = await AmazonUpload.GetObjects(Bucket.Text);
            result.Text += Bucket.Text + "文件如下：\n";
            response.S3Objects.ForEach(item =>
            {
                result.Text += "Key:" + item.Key + ",大小" + item.Size + "\r\n";
            });
        }

        private async void Upload_ClickAsync(object sender, EventArgs e)
        {
            var up = await AmazonUpload.UpLoadFile(Bucket.Text, Key.Text, Key.Text);
            if (up.HttpStatusCode == HttpStatusCode.OK)
            {
                var Url = AmazonUpload.GetUrlUpload(Bucket.Text, Key.Text);
                MessageBox.Show(Url);
            }
        }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            //uploadFile.Filter = @"Dpm(.pdm)|*.pdm";
            if (uploadFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = uploadFile.FileName;
                Key.Text = filePath;
            }
        }


        private async void DownFile_ClickAsync(object sender, EventArgs e)
        {
            using (var Response = await AmazonUpload.Down(Bucket.Text, Key.Text))
            {
                var Path = Response.Key.Split('.');
                var FilePath = Path[0] + "new." + Path[1];
                Response.WriteResponseStreamToFile(FilePath);
            }
        }

        private void getUrl_Click(object sender, EventArgs e)
        {
            var Url = AmazonUpload.GetUrlUpload(Bucket.Text, Key.Text);
            result.Text += "Url:" + Url + "\r\n";
        }

        private async void DeleteFile_Click(object sender, EventArgs e)
        {
            var response = await AmazonUpload.DeleteObject(Bucket.Text, Key.Text);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("删除Key:[" + Key.Text + "]成功！");
            }
        }

        private async void DeleteBucket_Click(object sender, EventArgs e)
        {
            var response = await AmazonUpload.DeleteBucket(Bucket.Text);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("删除Bucket:[" + Bucket.Text + "]成功！");
            }
        }

        private void SendEmail_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.qq.com";

            //smtpClient.Port = "";//qq邮箱可以不用端口

            //构建发件地址和收件地址

            MailAddress sendAddress = new MailAddress("361652124@qq.com", "SP的我");

            MailAddress receiverAddress = new MailAddress("15287188543@163.com");

            //构造一个Email的Message对象 内容信息

            MailMessage message = new MailMessage(sendAddress, receiverAddress);

            message.Subject = "邮件主题";

            message.SubjectEncoding = Encoding.UTF8;

            message.Body = "测试";

            message.BodyEncoding = Encoding.UTF8;

            //设置邮件的信息 如登陆密码 账号

            //邮件发送方式  通过网络发送到smtp服务器

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            //如果服务器支持安全连接，则将安全连接设为true

            smtpClient.EnableSsl = true;

            try

            {

                smtpClient.UseDefaultCredentials = false;

                //发件用户登陆信息

                NetworkCredential senderCredential = new NetworkCredential("361652124@qq.com", "kpcpchvxrbavbibb");

                smtpClient.Credentials = senderCredential;

                //发送邮件

                smtpClient.Send(message);

                MessageBox.Show("发送成功!");

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }


        }

        private void Query_Click(object sender, EventArgs e)
        {
            var DateTime = new DateTime(2019, 1, 10);
            var DateNow = DateTime.Today;
            var Days = (DateNow - DateTime).Days;
            MessageBox.Show(string.Format("共计：{0}天",Days));
        }
    }
}
