using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Курсовая_работа
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Position();

            DateBank.test_form1_1 = false;

        }

        Thread th;
        public char[] word;
                                                
        public void Win_open(object obj)        //Перенаправление потока на Form3
        {
            Application.Run(new Form3());

        }
        public void Win_die(object obj)         //Перенаправление потока на Form6
        {
            Application.Run(new Form6());

        }
        public void Null()                      //Обновление переменных для начала игры
        {
            DateBank.File_name = string.Empty;
            DateBank.Game_word = string.Empty;
            DateBank.Hint = string.Empty;
            DateBank.test_form5 = true;
            DateBank.test_form1_1 = true;
            DateBank.test_form2_1 = false;
            DateBank.Kol = 0;
        }
        public void Position()                  //Считывание графического пароля
        {
            string[] Coordinates = File.ReadAllLines(DateBank.fileName, System.Text.Encoding.Default);

            DateBank.X_position_1 = Convert.ToInt32(Coordinates[0]);
            DateBank.Y_position_1 = Convert.ToInt32(Coordinates[1]);

            DateBank.X_position_2 = Convert.ToInt32(Coordinates[2]);
            DateBank.Y_position_2 = Convert.ToInt32(Coordinates[3]);

            DateBank.X_position_3 = Convert.ToInt32(Coordinates[4]);
            DateBank.Y_position_3 = Convert.ToInt32(Coordinates[5]);
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            Null();                                 //Обнуление данных
            Form form2 = new Form2();
            form2.ShowDialog();



            if (DateBank.test_form2_1)
            {

                if (File.Exists(DateBank.File_name))//Отлавливание ошибки (отсутвие ошибки)
                {
                    string[] Array_GAME = File.ReadAllLines(DateBank.File_name, System.Text.Encoding.Default);
                                                    //Считывание данных из файла выбранного уровня


                    Random rnd = new Random();
                    int x = rnd.Next(Array_GAME.Length);

                    string GAME = Array_GAME[x];    //Выбор рандомного слова из библиотеки слов

                    int i = 0;
                    for (; GAME[i] != ' '; i++) DateBank.Game_word += GAME[i];
                                                    //Запись загадоного слова
                    i += 3;
                    for (; i < GAME.Length; i++) DateBank.Hint += GAME[i];
                                                    //Запись подсказкик к загадоному слову


                    word = new char[DateBank.Game_word.Length];
                    for (int j = 0; j < DateBank.Game_word.Length; j++) word[j] = '*';
                                                    //Запись слова в формате "****"


                    DateBank.Score_mistake = DateBank.Score / DateBank.Game_word.Length;
                                                    //Высчитывание стоимости ошибки в баллах

                    textBox1.Text = new string(word);
                }

                else                                //Действия при отсутствии нужного файла (перенаправление потока)
                {

                    th = new Thread(Win_die);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
            }
        }

        private void buttonHint_Click(object sender, EventArgs e)
        {                                       //Действия при нажатии на кнопку "Подсказка" (вывод в поле)
            textBox2.Text = DateBank.Hint;
            DateBank.Score -= DateBank.Score_hint;
        }
        
        private void buttonChar_Click(object sender, EventArgs e)
        {                                       //Обработка нажатия кнопок "А"-"Б"
            if (DateBank.test_form1_1)          //Проверка на нажатие кнопки "Начало игры"
            {
                string button_text = ((Button)sender).Text;
                string test = new string(word);


                for (int i = 0; i < DateBank.Game_word.Length; i++)
                {

                    if (DateBank.Game_word[i] == Convert.ToChar(button_text)) word[i] = Convert.ToChar(button_text);

                }

                string answer = new string(word);
                textBox1.Text = answer;

                if (answer == test)             //Если слово не изменилось (неправильная буква), то...
                {
                    if (DateBank.Kol < 7) //..., то проверяем кол-во ошибок
                    {
                        DateBank.Score -= DateBank.Score_mistake;

                        string png = DateBank.Image_name + Convert.ToString(DateBank.Kol) + DateBank.Image;
                                                //Составляем имя нужной картинки

                        if (File.Exists(png))   //Проверяем на существование этой картинки
                        {
                            pictureBox1.Image = new Bitmap(png);
                            DateBank.Kol += 1;
                        }
                        else
                        {

                            th = new Thread(Win_die);
                            th.SetApartmentState(ApartmentState.STA);
                            th.Start();

                        }

                    }
                    else
                    {
                        DateBank.Result = "Проигрыш";
                        DateBank.Res = false;
                        this.Close();

                        th = new Thread(Win_open);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }

                }

                if (DateBank.Game_word == answer)
                {
                    DateBank.Result = "Победа";
                    DateBank.Res = true;
                    this.Close();

                    th = new Thread(Win_open);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }

                ((Button)sender).Dispose();
            }

            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {                                       //Реализация проверки пароля к консоли админа

            int x_1 = DateBank.X_position_1;
            int y_1 = DateBank.Y_position_1;

            int x_2 = DateBank.X_position_2;
            int y_2 = DateBank.Y_position_2;

            int x_3 = DateBank.X_position_3;
            int y_3 = DateBank.Y_position_3;


            if ((e.X >= x_1-20) && (e.X <= x_1 + 20) && (e.Y >= y_1 - 20) && (e.Y <= y_1 + 20))
            {
                DateBank.test_position_1 = true;
            }
            if ((e.X >= x_2 - 20) && (e.X <= x_2 + 20) && (e.Y >= y_2 - 20) && (e.Y <= y_2 + 20))
            {
                DateBank.test_position_2 = true;
            }
            if ((e.X >= x_3 - 20) && (e.X <= x_3 + 20) && (e.Y >= y_3 - 20) && (e.Y <= y_3 + 20))
            {
                DateBank.test_position_3 = true;
            }

            if (DateBank.test_position_1 && DateBank.test_position_2 && DateBank.test_position_3)
            {
                Form form4 = new Form4();
                form4.ShowDialog();

                DateBank.test_position_1 = false;
                DateBank.test_position_2 = false;
                DateBank.test_position_3 = false;
            }
        }

        
    }
}
