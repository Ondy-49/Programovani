using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;                     //promenne pro praci s inputy od uzivatele
        private Point lastPoint = Point.Empty;
        private Pen pen = new Pen(Color.Black, 2);
        private Bitmap canvas;
        private bool readyToDrawEllipse = false;
        private int ellipseWidth = 0;
        private int ellipseHeight = 0;
        private bool readyToDrawRectangle = false;
        private int rectangleWidth = 0;
        private int rectangleHeight = 0;

        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)  //chatGPT
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


                    float dx = e.X - lastPoint.X;
                    float dy = e.Y - lastPoint.Y;
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);


                    if (distance > 0)
                    {
                        for (float i = 0; i <= 1; i += 1 / distance)
                        {
                            float x = lastPoint.X + (dx * i);
                            float y = lastPoint.Y + (dy * i);
                            g.FillEllipse(new SolidBrush(pen.Color), x - pen.Width / 2, y - pen.Width / 2, pen.Width, pen.Width);
                        }
                    }
                }
                pictureBox1.Invalidate();
                lastPoint = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            lastPoint = Point.Empty;
        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
            }
        }

        private void sizeButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(sizeInput.Text, out int newSize) && newSize > 0)
            {
                pen.Width = newSize;
            }
            else
            {
                MessageBox.Show("Please enter a valid number greater than 0.");
            }
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxHeight.Text, out int height) && height > 0 && int.TryParse(textBoxWidth.Text, out int width) && width > 0)
            {
                ellipseWidth = width;
                ellipseHeight = height;
                readyToDrawEllipse = true;
                MessageBox.Show("Click where you want the center to be.");
            }
            else
            {
                MessageBox.Show("Please enter a valid arguments greater than 0.");
            }
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxHeight.Text, out int height) && height > 0 && int.TryParse(textBoxWidth.Text, out int width) && width > 0)
            {
                rectangleWidth = width;
                rectangleHeight = height;
                readyToDrawRectangle = true;
                MessageBox.Show("Click where you want the center to be.");
            }
            else
            {
                MessageBox.Show("Please enter a valid arguments greater than 0.");
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (readyToDrawEllipse)
            {
                if (checkBoxFill.Checked) //s vyplni
                {
                    using (Graphics g = Graphics.FromImage(canvas))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (SolidBrush brush = new SolidBrush(pen.Color))
                            g.FillEllipse(brush, e.X - ellipseWidth / 2, e.Y - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                    }
                }
                else
                    using (Graphics g = Graphics.FromImage(canvas)) //bez vyplne
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawEllipse(pen, e.X - ellipseWidth / 2, e.Y - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                    }

                pictureBox1.Invalidate();
                readyToDrawEllipse = false;
            }
            if (readyToDrawRectangle) 
            {
                if (checkBoxFill.Checked) //s vyplni
                {
                    using (Graphics g = Graphics.FromImage(canvas))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (SolidBrush brush = new SolidBrush(pen.Color))
                            g.FillRectangle(brush, e.X - rectangleWidth / 2, e.Y - rectangleHeight / 2, rectangleWidth, rectangleHeight);
                    }
                }
                using (Graphics g = Graphics.FromImage(canvas)) //bez vyplne
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawRectangle(pen, e.X - rectangleWidth / 2, e.Y - rectangleHeight / 2, rectangleWidth, rectangleHeight);
                }

                pictureBox1.Invalidate();
                readyToDrawRectangle = false;
            }
        }

        private void buttonImage_Click_1(object sender, EventArgs e)
        {
            int width, height;
            if (int.TryParse(textBoxWidth.Text, out width) && int.TryParse(textBoxHeight.Text, out height))
            {
                Image masterOfTheMovement = Properties.Resources.masterOfTheMovement;
                Image resized = new Bitmap(masterOfTheMovement, new Size(width, height));
                canvas = new Bitmap(resized); //tvorba noveho platna ve velikosti obrazku s pozadi obrazku, abych pres to mohl kreslit
                pictureBox1.Image = canvas;
            }
            else
            {
                MessageBox.Show("Please enter valid arguments.");
            }
        }
    }
}



