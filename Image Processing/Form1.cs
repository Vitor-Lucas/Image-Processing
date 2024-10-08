﻿/*
 * Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 09 / 09 / 2024
 * Autores do Projeto: Vitor Lucas Kohls Correa
 *                     Isabelly Pacheco Marinho
 *
 * Turma: 3F
 * 
 * 
 * ******************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap baloon_image;
        Bitmap main_image;
        Bitmap plane_image;
        Bitmap man_image;

        public Form1()
        {
            InitializeComponent();
        }

        private int Clamp(int current, int min, int max)
        {
            return Math.Min(Math.Max(current, min), max);
        }

        private int ConvertGrayScale(int R, int G, int B)
        {
            return (int)((R * 0.3) + (G * 0.59) + (B * 0.11));
        }

        private Color CriarCor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

        private bool InRange(Color cur_color, Color other_color, int tolerance)
        {
            int cur_R = cur_color.R;
            int cur_G = cur_color.G;
            int cur_B = cur_color.B;

            int dist_R = Math.Abs(cur_R - other_color.R);
            int dist_G = Math.Abs(cur_G - other_color.G);
            int dist_B = Math.Abs(cur_B - other_color.B);

            return (dist_R <= tolerance && dist_B <= tolerance && dist_G <= tolerance);
        }

        private Bitmap SetBrightness(Bitmap image, int b)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap new_image = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for(int j  = 0; j < height; j++)
                {
                    int R = image.GetPixel(i, j).R;
                    int G = image.GetPixel(i, j).G;
                    int B = image.GetPixel(i, j).B;

                    R = Clamp(R + b, 0, 255);
                    G = Clamp(G + b, 0, 255);
                    B = Clamp(B + b, 0,255);

                    new_image.SetPixel(i, j, CriarCor(R,G,B));
                }
            }
            return new_image;
        }

        private Bitmap GrayScale(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap new_image = new Bitmap(width,height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int R = image.GetPixel(i, j).R;
                    int G = image.GetPixel(i, j).G;
                    int B = image.GetPixel(i, j).B;

                    int gray = ConvertGrayScale(R, G, B);

                    new_image.SetPixel(i, j, CriarCor(gray, gray, gray));
                }
            }
            return new_image;
        }

        private Bitmap PlaceImage(Bitmap bigger_img, Bitmap smaller_img, Color background, int x, int y, int background_tolerance)
        {
            int width = bigger_img.Width;
            int height = bigger_img.Height;

            Bitmap result = new Bitmap(bigger_img, width, height);
            for (int i = 0; i < smaller_img.Width; i++)
            {
                for (int j = 0; j < smaller_img.Height; j++)
                {
                    Color pixel = smaller_img.GetPixel(i, j);
                    if (!InRange(pixel, background, background_tolerance))
                        result.SetPixel(i+x, j+y, pixel);
                }
            }
            return result;
        }

        private Bitmap Rotate(Bitmap image)
        {
            Bitmap new_image = new Bitmap(width: image.Height, height: image.Width);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);

                    new_image.SetPixel(j, i, pixel);
                }
            }
            return new_image;
        }

        private Bitmap Threshold(Bitmap image, int t)
        {
            int width = image.Width;
            int height = image.Height;

            image = GrayScale(image);

            Bitmap new_image = new Bitmap(width, height);
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int I = image.GetPixel(i, j).R;

                    if (I <= t)
                        I = 0;
                    else
                        I = 255;
                    
                    new_image.SetPixel(i, j, CriarCor(I,I,I));
                }
            }
            return new_image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baloon_image = new Bitmap(@"C:\Images\Balao.jpg");
            main_image = new Bitmap(@"C:\Images\Im.jpg");
            plane_image = new Bitmap(@"C:\Images\Aviao2.jpg");
            man_image = new Bitmap(@"C:\Images\homem.jpg");

            pictureBox1.Image = baloon_image;
            pictureBox6.Image = main_image;
            pictureBox3.Image = plane_image;
            pictureBox8.Image = man_image;
        }

        private void Gerar_button_Click(object sender, EventArgs e)
        {
            // Junta as imagens
            Bitmap joined_image = main_image;
            joined_image = PlaceImage(joined_image, man_image, CriarCor(166, 144, 107), 700, 600, 20);
            joined_image = PlaceImage(joined_image, baloon_image, CriarCor(82, 141, 201), 700, 45, 20);
            joined_image = PlaceImage(joined_image, plane_image, CriarCor(63, 146, 214), 60, 100, 20);
            
            pictureBox5.Image = joined_image;

            //Salva as imagens
            joined_image.Save(@"C:\Images\Foto_Unida.jpg");
            GrayScale(joined_image).Save(@"C:\Images\GrayScale.jpg");
            Threshold(joined_image, 126).Save(@"C:\Images\Binária.jpg");
            SetBrightness(joined_image, trackBar1.Value).Save(@"C:\Images\Brilho.jpg");
            Rotate(joined_image).Save(@"C:\Images\Rotacionada.jpg");

            button1.Enabled = true;
            Gerar_button.Enabled = false;
            MessageBox.Show("Imagens Geradas com sucesso!\n verifique no diretório: C:\\Images\\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            trackBar1.Value = int.Parse(textBox1.Text);
        }
    }
}
