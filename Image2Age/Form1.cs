using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image2Age
{
    public partial class Form1 : Form
    {
        MapManager MapManager = new MapManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileImage.FileName))
                {
                    byte[] rawBytes = System.IO.File.ReadAllBytes(openFileImage.FileName);

                    if (MapManager.CheckAndSaveValidImage(rawBytes))
                    {
                        // bad image (no png)
                        // image cleared   
                        pictureBoxInput.Image = MapManager.inputImage;
                    }
                    // successfully loaded image
                }
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (MapManager.inputImage != null)
            {
                int size = 0;
                if (rb120.Checked)
                {
                    size = 120;
                }
                if (rb144.Checked)
                {
                    size = 144;
                }
                if (rb168.Checked)
                {
                    size = 168;
                }
                if (rb200.Checked)
                {
                    size = 200;
                }
                if (rb220.Checked)
                {
                    size = 220;
                }
                MapManager.Resize(size);

                pictureBoxOutput.Image = MapManager.outputImage;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MapManager.outputImage != null)
            {
                MapManager.SaveMap();
            }
            if (MapManager.newMap != null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(saveFileDialog.FileName))
                    {
                        //Inform the user
                    }
                    string path = saveFileDialog.FileName;
                    FileInfo fi = new FileInfo(path);

                    // Open the stream for writing.
                    using (FileStream fs = fi.OpenWrite())
                    {
                        // Add map information to the file.
                        fs.Write(MapManager.newMap, 0, MapManager.newMap.Length);
                    }
                }
            }

        }
    }
}
