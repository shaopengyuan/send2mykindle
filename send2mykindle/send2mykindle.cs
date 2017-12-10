using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using KindleMailBox;
using System.IO;
using Microsoft.Win32;
using send2mykindle.Utilities;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace send2mykindle
{
    public partial class Form_send2mykindle : Form
    {
        static Mailer mailer = new Mailer();
        RegistryHelper rh = new RegistryHelper();
        static Form_send2mykindle instance = null;
        public Form_send2mykindle()
        {
            InitializeComponent();
            

            //加载邮箱地址
            string mailDest = mailer.readDefaultMailDest();
            if (null != mailDest)
            {
                textBox_username.Text = mailDest;
                mailer.setMailDes(mailDest + textBox_mailExt.Text);
            }
        }

        public void sendCancel()
        {
            mailer.sendCancel();
        }

        static public Form_send2mykindle getInstance()
        {
            if(instance == null)
            {
                instance = new Form_send2mykindle();
            }
            return instance;
        }
       private  void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            if (e.Cancelled)
            {
                MessageBox.Show("用户已取消发送!");
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0}", e.Error.ToString()));
            }
            else
            {
                sendWaitWindow.getInstance().Close();
                sendWaitWindow.getInstance().Dispose();
                MessageBox.Show("发送成功");
                string strResult = "以下文件已经成功推送：";
                List<string> files = mailer.fileAttached;
                foreach (string file in files)
                {
                    strResult = strResult + string.Format("\n{0}", Path.GetFileName(file));
                }
                strResult = strResult + string.Format("\n请拖动文件至该框继续推送");
                label_send.Text = strResult;
            } 
        }
        private void button_send_Click(object sender, EventArgs e)
        {

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string strMailDes = textBox_username.Text + textBox_mailExt.Text;
            mailer.setMailDes(strMailDes);
            foreach(string file in files)
            {
                mailer.addAttachedFile(file);
            }
            mailer.send2kindle(new SendCompletedEventHandler(SendCompletedCallback));
            sendWaitWindow.getInstance().ShowDialog();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_setDefault_Click(object sender, EventArgs e)
        {
            string strMailBoxName = textBox_username.Text;
            mailer.setDefaultMailDest(strMailBoxName);
        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox_username.Text, @"[a-zA-Z0-9_-]+"))
            {
                textBox_username.BackColor = Color.DarkRed;
                MessageBox.Show("邮箱用户名输入错误！");
            }
            else
            {
                textBox_username.BackColor = DefaultBackColor;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.amazon.cn/gp/help/customer/display.html?nodeId=201974240");
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox_mailDestName_Validating(object sender, CancelEventArgs e)
        {
            

        }

        private void comboBox_mailDestName_TextUpdate(object sender, EventArgs e)
        {

        }

        private void button_help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cnblogs.com/spyplus/p/send2mykindle.html");
        }
    }

    public class Mailer
    {
        SmtpClient sc = mailBox.getInstance();
        const string mailDestFile = "KindleMailDest.dat";
        static string[] KindleDocTypes = { ".mobi", ".pdf", ".awz",// 电子书
                                           ".doc",".docx",".rtf",".txt",// 文档
                                           ".html",".htm",// 网页
                                            ".jpeg",".jpg",".gif",".png",".bmp"};//图片;
        string strMailDes;//目标邮箱
        public List<string> fileAttached = new List<string>();
        //取消发送
        public void sendCancel()
        {
            sc.SendAsyncCancel();
        }
        public void setMailDes(string mailDes)
        {
            strMailDes = mailDes;
        }

        public bool addAttachedFile(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            string extName = Path.GetExtension(filePath);
            if (KindleDocTypes.Contains(extName))
            {
                fileAttached.Add(filePath);
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 推送到指定邮箱
        /// </summary>
        /// <returns>true:推送成功;false:推送失败</returns>
        public void send2kindle(SendCompletedEventHandler sceh)
        {

            //MailMessage oMail = new MailMessage("send2mykindle@163.com", strMailDes);
            MailMessage oMail = new MailMessage(mailBox.kindleMail+ "@163.com", strMailDes,"Convert","send2mykindle 推送邮件");
            foreach (string file in fileAttached)
            {
                oMail.Attachments.Add(new Attachment(file));
            }
            sc.SendCompleted += sceh;
            sc.SendMailAsync(oMail);
        }
        /// <summary>
        /// 加载推送邮件地址列表
        /// </summary>
        /// <returns>加载成功则范围地址列表的字符串列表，否则范围null</returns>
        public string readDefaultMailDest()
        {
            if (!File.Exists(mailDestFile)) return null;
            try
            {
                FileStream fs = new FileStream(mailDestFile, FileMode.Open, FileAccess.Read);

                BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
                fs.Position = 0;//重置流位置
                string _ret = (string)binFormat.Deserialize(fs);
                fs.Close();
                return _ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取默认推送邮件地址失败！", ex.Message.ToString());
                return null;
            }

        }

        /// <summary>
        /// 将新的推送邮件地址加入列表
        /// </summary>
        /// <param name="newMail">要加入的邮件地址列表</param>
        /// <returns>加入之后的完整列表</returns>
        public bool setDefaultMailDest(string newMail)
        {
            try
            {
                FileStream fs = new FileStream(mailDestFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                FileInfo fi = new FileInfo(mailDestFile);
                File.SetAttributes(mailDestFile, fi.Attributes | FileAttributes.Hidden);
                BinaryFormatter binFormat = new BinaryFormatter();
                fs.Position = 0;
                binFormat.Serialize(fs, newMail);
                fs.Close();
                return true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            
            
        }
        // 等待实现
        /// <summary>
        /// 将epub文件转化成mobi
        /// </summary>
        /// <param name="epubFilePath">epub文件的完整路径</param>
        /// <returns></returns>
        public bool epub2mobi(string epubFilePath)
        {
            return false;
        }
    }

    namespace Utilities
    {
       
        class RegistryHelper //注册表工具类
        {
            /// <summary>
            /// 读取指定名称的注册表的值
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            
            public string GetRegistryData(RegistryKey root, string subkey, string name)
            {
                string registData = "";
                RegistryKey myKey = root.OpenSubKey(subkey, true);
                if (myKey != null)
                {
                    registData = myKey.GetValue(name).ToString();
                }

                return registData;
            }

            /// <summary>
            /// 向注册表中写数据
            /// </summary>
            /// <param name="name"></param>
            /// <param name="tovalue"></param> 
            
            public void SetRegistryData(RegistryKey root, string subkey, string name, string value)
            {
                RegistryKey aimdir = root.CreateSubKey(subkey);
                aimdir.SetValue(name, value);
            }

            /// <summary>
            /// 删除注册表中指定的注册表项
            /// </summary>
            /// <param name="name"></param>
            public void DeleteRegist(RegistryKey root, string subkey, string name)
            {
                string[] subkeyNames;
                RegistryKey myKey = root.OpenSubKey(subkey, true);
                subkeyNames = myKey.GetSubKeyNames();
                foreach (string aimKey in subkeyNames)
                {
                    if (aimKey == name)
                        myKey.DeleteSubKeyTree(name);
                }
            }

            /// <summary>
            /// 判断指定注册表项是否存在
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
           
            public bool IsRegistryExist(RegistryKey root, string subkey, string name)
            {
                bool _exit = false;
                string[] subkeyNames;
                RegistryKey myKey = root.OpenSubKey(subkey, true);
                subkeyNames = myKey.GetSubKeyNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == name)
                    {
                        _exit = true;
                        return _exit;
                    }
                }

                return _exit;
            }
        }
    }
}
