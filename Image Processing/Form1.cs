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
    public partial class Form1 : Form
    {
        Bitmap image1;
        Bitmap image2;
        Bitmap image3;
        Bitmap image4;
        Bitmap new_image;
        public Form1()
        {
            InitializeComponent();
        }

        private int clamp(int current, int min, int max)
        {
            return Math.Min(Math.Max(current, min), max);
        }

        private void brightness(Bitmap image, int b)
        {
            for(int i = 0; i < image.Width; i++)
            {
                for(int j  = 0; j < image.Height; j++)
                {
                    int R = image.GetPixel(i, j).R;
                    int G = image.GetPixel(i, j).G;
                    int B = image.GetPixel(i, j).B;

                    R = clamp(R + b, 0, 255);
                    G = clamp(G + b, 0, 255);
                    B = clamp(B + b, 0,255);

                    image.SetPixel(i,j,Color.FromArgb(R, G, B));
                }
            }
        }


        private void GrayLevel(Bitmap image,int r, int g, int b)
        {
            
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image1 = new Bitmap("C:\\Images\\Balao.jpg");
            image2 = new Bitmap(@"C:\Images\Im.jpg");
            image3 = new Bitmap(@"C:\Images\Aviao2.jpg");
            image4 = new Bitmap(@"C:\Images\homem.jpg");


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
