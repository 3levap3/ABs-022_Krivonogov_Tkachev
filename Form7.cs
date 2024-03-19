using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Курсовая_работа
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Invisible();
            
            
        }

        Bitmap map = new Bitmap(500, 500);
        Graphics graphics;

        
        private void Invisible()                            //Настройка прозрачности элементов
        {
            label1.Parent = pictureBox1;                label6.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;       label6.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;                label7.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;       label7.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;                label8.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;       label8.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;                label9.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;       label9.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;                label10.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;       label10.BackColor = Color.Transparent;

            label11.Parent = pictureBox1;
            label11.BackColor = Color.Transparent;
            label12.Parent = pictureBox1;
            label12.BackColor = Color.Transparent;
            label13.Parent = pictureBox1;
            label13.BackColor = Color.Transparent;
            label14.Parent = pictureBox1;
            label14.BackColor = Color.Transparent;
            label15.Parent = pictureBox1;
            label15.BackColor = Color.Transparent;

            pictureBox2.Parent = pictureBox3;
            pictureBox2.BackColor = Color.Transparent;

            graphics = Graphics.FromImage(map);
        }


        private Point[] Squares(int x, int y)               //Создание точек для отрисовки квадрата
        {
            Point[] Square = new Point[5];


            int x1 = (x + 20);
            int x2 = (x - 20);
            int y1 = (y + 20);
            int y2 = (y - 20);

            Square[0] = new Point(x1, y1);
            Square[1] = new Point(x2, y1);
            Square[2] = new Point(x2, y2);
            Square[3] = new Point(x1, y2);
            Square[4] = new Point(x1, y1);

            return Square;
        }

        private void DrawSquare(int x, int y, Color color)  //Отрисовка квадрата
        {
            
            Pen pens = new Pen(color, 2f);

            Point[] Square = new Point[4];
            Square = Squares(x, y);

            graphics.DrawLines(pens, Square);
                                                            //Отрисовка креста посередине
            graphics.DrawLine(pens, x, y, x + 5, y - 5);
            graphics.DrawLine(pens, x, y, x - 5, y + 5);
            graphics.DrawLine(pens, x, y, x + 5, y + 5);
            graphics.DrawLine(pens, x, y, x - 5, y - 5);

            pictureBox2.Image = map;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {                                                   //Обработка нажатия на PictureBox (сохранение координат)
            if (label4.Text == "null" && label5.Text == "null")
            {

                label4.Text = Convert.ToString(e.X);
                label5.Text = Convert.ToString(e.Y);

                DrawSquare(e.X, e.Y, Color.Red);

            }
            else if (label9.Text == "null" && label10.Text == "null")
            {

                label9.Text = Convert.ToString(e.X);
                label10.Text = Convert.ToString(e.Y);

                DrawSquare(e.X, e.Y, Color.Orange);

            }
            else if (label14.Text == "null" && label15.Text == "null")
            {

                label14.Text = Convert.ToString(e.X);
                label15.Text = Convert.ToString(e.Y);

                DrawSquare(e.X, e.Y, Color.Blue);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                                                   // Обработка нажатия на кнопку "Изменить" для первой точки
            DrawSquare(Convert.ToInt32(label4.Text), Convert.ToInt32(label5.Text), Color.White);
            label4.Text = "null";
            label5.Text = "null";
        }

        private void button2_Click(object sender, EventArgs e)
        {                                                   // Обработка нажатия на кнопку "Изменить" для второй точки
            DrawSquare(Convert.ToInt32(label9.Text), Convert.ToInt32(label10.Text), Color.White);
            label9.Text = "null";
            label10.Text = "null";
        }

        private void button3_Click(object sender, EventArgs e)
        {                                                   // Обработка нажатия на кнопку "Изменить" для третьей точки
            DrawSquare(Convert.ToInt32(label14.Text), Convert.ToInt32(label15.Text), Color.White);
            label14.Text = "null";
            label15.Text = "null";
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {                                                   // Обработка нажатия на кнопку "Подтвердить" (сохранение координат)


            DateBank.X_position_1 = Convert.ToInt32(label4.Text);
            DateBank.Y_position_1 = Convert.ToInt32(label5.Text);

            DateBank.X_position_2 = Convert.ToInt32(label9.Text);
            DateBank.Y_position_2 = Convert.ToInt32(label10.Text);

            DateBank.X_position_3 = Convert.ToInt32(label14.Text);
            DateBank.Y_position_3 = Convert.ToInt32(label15.Text);


            StreamWriter wr = new StreamWriter(DateBank.fileName, false, System.Text.Encoding.Default);

            wr.WriteLine(Convert.ToInt32(label4.Text));
            wr.WriteLine(Convert.ToInt32(label5.Text));

            wr.WriteLine(Convert.ToInt32(label9.Text));
            wr.WriteLine(Convert.ToInt32(label10.Text));

            wr.WriteLine(Convert.ToInt32(label14.Text));
            wr.WriteLine(Convert.ToInt32(label15.Text));



            wr.Close();

            this.Close();
        }

        
    }
}
