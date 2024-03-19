using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Invisible();

        }
                                          
        public void Invisible()             //Настройка прозрачности элементов
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            radioButton1.Parent = pictureBox1;
            radioButton1.BackColor = Color.Transparent;
            radioButton2.Parent = pictureBox1;
            radioButton2.BackColor = Color.Transparent;
            radioButton3.Parent = pictureBox1;
            radioButton3.BackColor = Color.Transparent;
        }

        public string name = @"C:\Users\pavelkrivonogov\source\repos\Курсовая работа\Курсовая работа\bin\Debug\GameDate\";

        private void buttonReady_Click(object sender, EventArgs e)
        {                                   //Обработка входных данных игрока

            DateBank.NameGamer = textBox1.Text;
            DateBank.Score = 1000;
            DateBank.File_name += name;
            DateBank.test_form2_1 = true;

            if (radioButton1.Checked)
            {
                DateBank.Lavel = 1;
                DateBank.File_name += "Words1.txt";
                
            } 
            else if (radioButton2.Checked)
            {
                DateBank.Lavel = 2;
                DateBank.File_name += "Words2.txt";
                
            }
            else if (radioButton3.Checked)
            {
                DateBank.Lavel = 3;
                DateBank.File_name += "Words3.txt";
                
            }

            this.Close();
        }
        
    }
}
