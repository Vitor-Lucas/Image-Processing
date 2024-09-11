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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(@"C:\Images\Foto_Unida.jpg");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap show_image;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    show_image = new Bitmap(@"C:\Images\Foto_Unida.jpg");
                    break;
                case 1:
                    show_image = new Bitmap(@"C:\Images\GrayScale.jpg");
                    break;
                case 2:
                    show_image = new Bitmap(@"C:\Images\Brilho.jpg");
                    break;
                case 3:
                    show_image = new Bitmap(@"C:\Images\Binária.jpg");
                    break;
                case 4:
                    show_image = new Bitmap(@"C:\Images\Rotacionada.jpg");
                    break;
                default:
                    show_image = new Bitmap(@"C:\Images\Foto_Unida.jpg");
                    break;
            }

            pictureBox1.Image = show_image;
        }

    }
}
