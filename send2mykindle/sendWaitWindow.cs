using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace send2mykindle
{
    public partial class sendWaitWindow : Form
    {
        static sendWaitWindow instance = null;
        static double startTimeInMs = 0;//开始毫秒数
        const int maxMs = 10000;//10秒一轮
        public sendWaitWindow()
        {
            InitializeComponent();
            startTimeInMs = DateTime.Now.Ticks;
        }


        public static sendWaitWindow getInstance()
        {
            if (null == instance)
            {
                instance = new sendWaitWindow();
            }
            return instance;
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form_send2mykindle.getInstance().sendCancel();
            this.Close();
        }

        private void sendWaitWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form_send2mykindle.getInstance().sendCancel();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value > 95)
            {
                progressBar1.Value -= 95;
            }
            progressBar1.Value += 5;


            progressBar1.Refresh();
        }
    }
}
