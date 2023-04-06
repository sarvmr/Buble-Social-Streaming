using Buble.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Buble.Models;

namespace Buble.Views
{
    /// <summary>
    /// Interaction logic for ScreenRecorderView.xaml
    /// </summary>
    public partial class ScreenRecorderView : UserControl
    {
        public ScreenRecorderView()
        {
            InitializeComponent();
        }


        // Filing variables:
        string outputPath = "";
        bool pathSelected = false;
        string finalVidName = "FinalVideo.mp4";
        private bool isRecording = false;
        private bool shouldRecord = false;

        // Screen recorder object:
        ScreenRecorderModel screenRec = new ScreenRecorderModel(new Rectangle(), "");

        private void button4_Click(object sender, EventArgs e)
        {
            //Create output path:
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowser.Description = "Select an Output Folder";

            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputPath = @folderBrowser.SelectedPath;
                pathSelected = true;

                //Finish screen recorder object:
                System.Drawing.Point point = new System.Drawing.Point(100, 100);
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromPoint(new System.Drawing.Point((int)point.X, (int)point.Y));

                Rectangle bounds = new Rectangle(screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height);
                screenRec = new ScreenRecorderModel(bounds, outputPath);
            }
            else
            {
                System.Windows.MessageBox.Show("Please select an output folder.", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool containsMP4 = finalVidName.Contains(".mp4");

            if (pathSelected && containsMP4)
            {
                screenRec.setVideoName(finalVidName);
                // Set the flag to start recording
                isRecording = true;
                shouldRecord = true;

                // Start recording in a new thread
                Thread recordingThread = new Thread(new ThreadStart(RecordingThread));
                recordingThread.Start();
            }
            else if (!pathSelected && containsMP4)
            {
                System.Windows.Forms.MessageBox.Show("You must select an output path first", "Error");
            }
            else if (pathSelected && !containsMP4)
            {
                System.Windows.Forms.MessageBox.Show("You must select video name that ends in '.mp4'", "Error");
                finalVidName = "FinalVideo.mp4";
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You must select video name that ends in '.mp4' " +
                    "and you must select an output path", "Error");
                finalVidName = "FinalVideo.mp4";
            }

        }

        private void RecordingThread()
        {
            // Start recording video and audio
            while (shouldRecord)
            {
                screenRec.RecordVideo();
                screenRec.RecordAudio();
            }

            // Reset the flags
            isRecording = false;
            shouldRecord = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set the flag to stop recording
            shouldRecord = false;
            screenRec.Stop();
            //System.Windows.Forms.Application.Restart();
        }


        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            screenRec.cleanUp();
        }

    }
}
