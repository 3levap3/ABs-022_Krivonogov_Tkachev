using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace Курсовая_работа
{
    public partial class Form4 : Form
    {

        private string fileName = @"C:\Users\pavelkrivonogov\source\repos\Курсовая работа\Курсовая работа\bin\Debug\GameDate"; //путь к файлу 

        private string name;

        private bool test = false;

        public Form4()
        {
            InitializeComponent();
           
            label1.Text = "Добро пожаловать, admin! \n Начните настройку игры, но не забывайте про правила!";
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {                       //Обработка нажатия на кнопку "Настроить игру" (открытие OpenFileDialog)
            openFileDialog1.InitialDirectory = fileName;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = fileName;
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name, System.Text.Encoding.Default);

            }

            tableLayoutPanel1.Visible = true;
            
            label1.Visible = false;
            panel1.Visible = false;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {                           //Обработка нажатия на кнопку "Настроить игру" (открытие OpenFileDialog)

            openFileDialog1.InitialDirectory = fileName;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = fileName;
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name, System.Text.Encoding.Default);

            }
            test = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {                           //Обработка нажатия на кнопку "Сохранить"
            if (test)
            {
                File.WriteAllText(name, textBox1.Text, System.Text.Encoding.Default);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {                           //Обработка нажатия на кнопку "Закрыть"
            test = false;
            textBox1.Clear();
            textBox1.Text = "Выбирите файл!";
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {                           //Обработка нажатия на кнопку "Изменить пароль"
            Form form7 = new Form7();
            form7.ShowDialog();
        }

      
   
    }
}
