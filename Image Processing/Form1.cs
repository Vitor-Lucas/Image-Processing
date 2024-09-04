using System;
using System.Drawing;
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

        private Bitmap SetBrightness(Bitmap image, int b)
        {
            Bitmap new_image = image;
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

                    new_image.SetPixel(i,j,Color.FromArgb(R, G, B));
                }
            }
            return new_image;
        }


        private Bitmap GrayScale(Bitmap image)
        {
            Bitmap new_image = image;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int R = image.GetPixel(i, j).R;
                    int G = image.GetPixel(i, j).G;
                    int B = image.GetPixel(i, j).B;

                    int gray = (int)((R * 0.3) + (G * 0.59) + (B * 0.11));
                     
                    //R = gray;
                    //G = gray;
                    //B = gray;
                    
                    new_image.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return new_image;
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image1 = new Bitmap(@"C:\Images\Balao.jpg");
            image2 = new Bitmap(@"C:\Images\Im.jpg");
            image3 = new Bitmap(@"C:\Images\Aviao2.jpg");
            image4 = new Bitmap(@"C:\Images\homem.jpg");

            pictureBox2.Image = image1;
            pictureBox6.Image = GrayScale(image2);
            pictureBox7.Image = image3;
            pictureBox8.Image = image4;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(@"C:\Images\Im.jpg");
            form.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(@"C:\Images\homem.jpg");
            form.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(@"C:\Images\Aviao2.jpg");
            form.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(@"C:\Images\Balao.jpg");
            form.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Form2 form = new Form2(@"C:\Images\Balao.jpg");
            //form.ShowDialog();
        }
    }
}
