using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;
using Microsoft.DirectX.AudioVideoPlayback;

namespace MV_Media_Player
{
    public partial class Form1 : Form
    {
        public Video video;
        public string PlayingPosition, Duration;
        public Size formSize;
        public Size videoSize;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            formSize = new Size(this.Width, this.Height);
            videoSize = new Size(axWindowsMediaPlayer1.Width, axWindowsMediaPlayer1.Height);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Close();
        }

        private void openFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video File (*.mp4,*.mpg,*.avi,*.wma,*.mov,*.wav)|*.mp4|Audio File (*.mp3)|*.mp3| All Files ( * )|*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.Text = ofd.FileName;
                axWindowsMediaPlayer1.URL = this.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                muteToolStripMenuItem.Enabled = true;
                increaseVolumeToolStripMenuItem.Enabled = true;
                decreaseVolumeToolStripMenuItem.Enabled = true;
                playToolStripMenuItem.Enabled = true;
                pauseToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                fullScreenToolStripMenuItem.Enabled = true;
                playpauseBtn.Enabled = true;
                trackBar1.Enabled = true;
                pictureBox1.Enabled = true;
                playpauseBtn.Text = "⏸️";
                stopBtn.Enabled = true;
                trackBar2.Enabled = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (playpauseBtn.Text == "⏸️")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                playpauseBtn.Text = "▶️";
            }
            else if (playpauseBtn.Text == "▶️")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playpauseBtn.Text = "⏸️";
            }
            
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = true;
        }

        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
         
        }

              

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            stopBtn.Enabled = false;
            playpauseBtn.Text = "▶️";
            playpauseBtn.Enabled = false;
            muteToolStripMenuItem.Enabled = false;
            increaseVolumeToolStripMenuItem.Enabled = false;
            decreaseVolumeToolStripMenuItem.Enabled = false;
            playToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            fullScreenToolStripMenuItem.Enabled = false;
            this.Text = "MV Media Player";
            trackBar2.Value = 0;
            trackBar1.Value = 50;
            label1.Text = trackBar1.Value.ToString() + "%";
            trackBar2.Enabled = false;
            trackBar1.Enabled = false;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            stopBtn.Enabled = false;
            playpauseBtn.Text = "▶️";
            playpauseBtn.Enabled = false;
            muteToolStripMenuItem.Enabled = false;
            increaseVolumeToolStripMenuItem.Enabled = false;
            decreaseVolumeToolStripMenuItem.Enabled = false;
            playToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            trackBar1.Enabled = false;
            fullScreenToolStripMenuItem.Enabled = false;
            this.Text = "MV Media Player";
            trackBar2.Value = 0;
            trackBar1.Value = 50;
            label1.Text = trackBar1.Value.ToString()+"%";
            trackBar2.Enabled = false;
            trackBar1.Enabled = false;
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (muteToolStripMenuItem.Text == "Mute")
            {
                muteToolStripMenuItem.Image = Image.FromFile(@"C:\Users\user\Desktop\MV media player\images\unmuteIcon.png");
                muteToolStripMenuItem.Text = "Unmute";
                axWindowsMediaPlayer1.settings.volume = 0;
                trackBar1.Value = 0;
                label1.Text = trackBar1.Value.ToString()+"%";
            }
            else if (muteToolStripMenuItem.Text == "Unmute")
            {
                muteToolStripMenuItem.Image = Image.FromFile(@"C:\Users\user\Desktop\MV media player\images\muteIcon.png");
                muteToolStripMenuItem.Text = "Mute";
                trackBar1.Value = 50;
                axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
                label1.Text = trackBar1.Value.ToString() + "%";
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                
            }
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString()+"%";
            axWindowsMediaPlayer1.settings.volume= trackBar1.Value;

            if(trackBar1.Value == 0)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_2(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerVideo_Tick(object sender, EventArgs e)
        {
            int currentTime = Convert.ToInt32(video.CurrentPosition);
            int maxTime = Convert.ToInt32(video.Duration);

            videoPosition.Text = string.Format("{0:00},{1:00},{2:00}",currentTime / 3600,(currentTime/60) % 60,currentTime % 60)
                            + "/"+
                          string.Format("{0:00},{1:00},{2:00}", maxTime / 3600, (maxTime / 60) % 60, maxTime % 60);

            trackBar2.Value = currentTime;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void increaseVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume += 10 ;
            trackBar1.Value += 10;
            label1.Text = trackBar1.Value.ToString() + "%";
            if(trackBar1.Value >= 100)
            {
                trackBar1.Value = 100;
                axWindowsMediaPlayer1.settings.volume = 100;
            }
        }

        private void decreaseVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume -= 10;
            trackBar1.Value -= 10;
            label1.Text = trackBar1.Value.ToString() + "%";
            if (trackBar1.Value <= 0)
            {
                trackBar1.Value = 0;
                axWindowsMediaPlayer1.settings.volume = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if(pictureBox1.Image == Image.FromFile(@"C:\Users\user\Desktop\MV media player\images\volumeIcon.png")) {
            //    pictureBox1.Image = Image.FromFile(@"C:\Users\user\Desktop\MV media player\images\muteIcon.png");
            //}
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (video != null)
            {
                video.CurrentPosition = trackBar2.Value;
            }
        }
    }
    
}
