using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Paint
{
    public partial class Form1 : Form
    {
        Bitmap sky, plane, cloud;
        Graphics g;
        int dx;
        Rectangle rect, cloud_rect;
        Random rnd;
        Boolean demo = true;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, new Point(0, 0));
            if (rect.X < ClientRectangle.Width)
                rect.X += dx;
            else
            {
                rect.X = -40;
                rect.Y = 20 + rnd.Next(ClientSize.Height - 40 - plane.Height);
                dx = 2 + rnd.Next(5);
            }
            if (cloud_rect.X > 0)
                cloud_rect.X -= dx;
            else
            {
                cloud_rect.X = ClientRectangle.Width + 40;
                cloud_rect.Y = 20 + rnd.Next(ClientSize.Height);
            }
            g.DrawImage(plane, rect.X, rect.Y);
            g.DrawImage(cloud, cloud_rect.X, cloud_rect.Y);
            if (!demo) this.Invalidate(rect);
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                Invalidate(reg);
            }
        }

        


        public Form1()
        {
            InitializeComponent();

            //Panel panel1 = new Panel();
            //panel1.Location = new Point(sky.Width / 2 - 100, sky.Height - 20);
            //panel1.Height = 100;
            //panel1.Width = 400;
            //panel1.BackColor = Color.Gray;
            //panel1.Enabled = true;
            

            rnd = new Random();
            try
            {
                sky = new Bitmap("sky.bmp");
                plane = new Bitmap("plane.bmp");
                cloud = new Bitmap("Cloud.png");
                BackgroundImage = new Bitmap("sky.bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки файлов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            plane.MakeTransparent();
            cloud.MakeTransparent();
            ClientSize = new System.Drawing.Size(new Point(BackgroundImage.Width, BackgroundImage.Height));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            //g = Graphics.FromImage(sky);
            g = Graphics.FromImage(BackgroundImage);
            cloud_rect.X = ClientSize.Width + 40;
            cloud_rect.Y = 20 + rnd.Next(20);
            cloud_rect.Width = cloud.Width;
            cloud_rect.Height = cloud.Height;
            rect.X = -40;
            rect.Y = 20 + rnd.Next(20);
            rect.Width = plane.Width;
            rect.Height = plane.Height;
            dx = 2;
            timer1.Interval = 20;
            timer1.Enabled = true;


            
        }
    }
}
