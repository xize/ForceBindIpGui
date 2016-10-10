using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.ForceBindIPGui
{
    public partial class Window : Form
    {
        public Window(bool minimized)
        {
            InitializeComponent();
            this.Text = String.Format("ForceBindIP Configuration Gui v{0}", Application.ProductVersion);
            if(Installation.getInstallation().isInstalled())
            {
                installbtn.Text = "Uninstall";
                adapter.Enabled = true;
                adapterbtn.Enabled = true;
            }

            if(Adapter.getAdapterFactory(this).isAdapterSet())
            {
                progress.Value = 100;
            }

            if(minimized)
            {
                this.Visible = false;
                this.notifyicon.Visible = true;
                notifyicon.BalloonTipTitle = "ForceBindIP has been minimized!";
                notifyicon.BalloonTipText = "you may now are able to right click applications and run them with ForceBindIP ;-)\nif not make sure it does listen to an interface!";
                notifyicon.ShowBalloonTip(600);
            }
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void form1_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
                notifyicon.Visible = true;
                notifyicon.BalloonTipTitle = "ForceBindIP has been minimized!";
                notifyicon.BalloonTipText = "you may now are able to right click applications and run them with ForceBindIP ;-)\nif not make sure it does listen to an interface!";
                notifyicon.ShowBalloonTip(600);
            }
        }

        private void notifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyicon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void installbtn_Click(object sender, EventArgs e)
        {
            if(installbtn.Text.StartsWith("Uninstall"))
            {
                installbtn.Enabled = false;
                Installation.getInstallation().uninstall();
                installbtn.Text = "Install ForceBindIP";
                //disable adapter settings:
                adapter.Enabled = false;
                adapterbtn.Enabled = false;
                installbtn.Enabled = true;
                progress.Value = 0;
                MessageBox.Show("Uninstall successfull");

            } else
            {
                installbtn.Enabled = false;
                Installation.getInstallation().install();
                adapter.Enabled = true;
                adapterbtn.Enabled = true;
                installbtn.Text = "Uninstall";
                installbtn.Enabled = true;
                MessageBox.Show("Installation successfull, you can now change the ip box to the ip address you are using!");
            }
        }

        private void adapterbtn_Click(object sender, EventArgs e)
        {
            Adapter.getAdapterFactory(this).setAdapterContext();
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
