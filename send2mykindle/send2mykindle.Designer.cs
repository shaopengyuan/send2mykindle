namespace send2mykindle
{
    partial class Form_send2mykindle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_send2mykindle));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_mailExt = new System.Windows.Forms.TextBox();
            this.button_setDefault = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_help = new System.Windows.Forms.Button();
            this.label_send = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "推送到：";
            // 
            // textBox_username
            // 
            this.textBox_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_username.Location = new System.Drawing.Point(66, 5);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(141, 21);
            this.textBox_username.TabIndex = 1;
            this.textBox_username.Text = "请输入推送邮箱用户名";
            this.textBox_username.TextChanged += new System.EventHandler(this.textBox_username_TextChanged);
            // 
            // textBox_mailExt
            // 
            this.textBox_mailExt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_mailExt.Location = new System.Drawing.Point(213, 6);
            this.textBox_mailExt.Name = "textBox_mailExt";
            this.textBox_mailExt.ReadOnly = true;
            this.textBox_mailExt.Size = new System.Drawing.Size(98, 21);
            this.textBox_mailExt.TabIndex = 2;
            this.textBox_mailExt.Text = "@free.kindle.cn";
            // 
            // button_setDefault
            // 
            this.button_setDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_setDefault.Location = new System.Drawing.Point(317, 4);
            this.button_setDefault.Name = "button_setDefault";
            this.button_setDefault.Size = new System.Drawing.Size(61, 23);
            this.button_setDefault.TabIndex = 3;
            this.button_setDefault.Text = "设为默认";
            this.button_setDefault.UseVisualStyleBackColor = true;
            this.button_setDefault.Click += new System.EventHandler(this.button_setDefault_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("KaiTi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "版权所有©SPY Studio ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button_help
            // 
            this.button_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_help.Image = ((System.Drawing.Image)(resources.GetObject("button_help.Image")));
            this.button_help.Location = new System.Drawing.Point(383, 4);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(30, 23);
            this.button_help.TabIndex = 6;
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // label_send
            // 
            this.label_send.AllowDrop = true;
            this.label_send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_send.BackColor = System.Drawing.SystemColors.Highlight;
            this.label_send.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_send.Location = new System.Drawing.Point(15, 30);
            this.label_send.Name = "label_send";
            this.label_send.Size = new System.Drawing.Size(401, 151);
            this.label_send.TabIndex = 7;
            this.label_send.Text = "将文件拖到此框进行推送\r\n";
            this.label_send.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_send.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.label_send.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "使用前需要将send2mykindle@163.com添加到";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(252, 186);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(161, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "已认可的发件人电子邮箱列表";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.linkLabel1_MouseClick);
            // 
            // Form_send2mykindle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(427, 219);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_send);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_setDefault);
            this.Controls.Add(this.textBox_mailExt);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_send2mykindle";
            this.Text = "推送到我的Kindle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_mailExt;
        private System.Windows.Forms.Button button_setDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Label label_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

