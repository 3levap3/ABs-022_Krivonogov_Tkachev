using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Курсовая_работа
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Invisible();
        }

        Thread th;

        public void Invisible()             //Настройка прозрачности элементов
        {
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            labelResult.Parent = pictureBox1;
            labelResult.BackColor = Color.Transparent;
            labelName.Parent = pictureBox1;
            labelName.BackColor = Color.Transparent;
            labelLavel.Parent = pictureBox1;
            labelLavel.BackColor = Color.Transparent;
            labelKol.Parent = pictureBox1;
            labelKol.BackColor = Color.Transparent;
            labelScore.Parent = pictureBox1;
            labelScore.BackColor = Color.Transparent;
            labelWord.Parent = pictureBox1;
            labelWord.BackColor = Color.Transparent;
        }
        public void Reset_open()            //Перенаправление потока на Form1
        {
            Application.Run(new Form1());
        }


        private void Form3_Load(object sender, EventArgs e)
        {                                   //Заполнение результатов игры 

            if (DateBank.Res == true) labelResult.Text = "Поздравляем, Вы выиграли!!!";
            else labelResult.Text = "Сожалеем, Вы проиграли(";

            labelName.Text = DateBank.NameGamer;

            labelLavel.Text = DateBank.Lavel.ToString();

            labelKol.Text = DateBank.Kol.ToString();

            if (DateBank.Res == true) labelScore.Text = DateBank.Score.ToString();
            else
            {
                DateBank.Score = 0;
                labelScore.Text = DateBank.Score.ToString();
            }

            labelWord.Text = DateBank.Game_word;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {                                   //Обработка нажатия на кнопку "Сыграть заново"

            this.Close();
            th = new Thread(Reset_open);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {                                   //Обработка нажатия на кнопку "Выход"
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {                                   ////Обработка нажатия на кнопку "Рейтинг игроков"
            Form form5 = new Form5();
            form5.ShowDialog();
        }

    }
}
