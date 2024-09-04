using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class Form2 : Form
    {
        Bitmap image;
        String image_path;
        public Form2(String img_path)
        {
            InitializeComponent();
            image = new Bitmap(img_path);
            image_path = img_path;
        }
        private int clamp(int current, int min, int max)
        {
            return Math.Min(Math.Max(current, min), max);
        }

        Bitmap brightness(Bitmap image, int b)
        {
            Bitmap new_image = new Bitmap(image, image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int R = image.GetPixel(i, j).R;
                    int G = image.GetPixel(i, j).G;
                    int B = image.GetPixel(i, j).B;

                    R = clamp(R + b, 0, 255);
                    G = clamp(G + b, 0, 255);
                    B = clamp(B + b, 0, 255);

                    new_image.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return new_image;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int b = trackBar1.Value;
            pictureBox1.Image = brightness(image, b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image.Save(image_path);
        }
    }
}
