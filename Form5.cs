using System;
using System.Data;
using System.Windows.Forms;
using System.IO;



namespace Курсовая_работа
{
    public partial class Form5 : Form
    {
        public string fileName = @"C:\Users\pavelkrivonogov\source\repos\Курсовая работа\Курсовая работа\bin\Debug\GameDate\GameResults.txt"; //путь к файлу 


        DataSet db = new DataSet();
         
        public Form5()
        {
            InitializeComponent();
            OpenFile(fileName);
   
        }
        
        private void OpenFile(string filaName)      //Считывание данных результатов игроков и занесение их в таблицу
        {

            StreamReader rd = new StreamReader(filaName, System.Text.Encoding.Default);

            
            db.Tables.Add("Gamers");

            string h = rd.ReadLine();
            string[] header = System.Text.RegularExpressions.Regex.Split(h, " "); //Считывание шапки таблицы

            for (int i = 0; i < header.Length; i++) db.Tables[0].Columns.Add(header[i]);


            string r = rd.ReadLine();

            while (r != null)
            {
                string[] row = System.Text.RegularExpressions.Regex.Split(r, " "); 
                db.Tables[0].Rows.Add(row);

                r = rd.ReadLine();

            }


            if (DateBank.test_form5 == true)
            {
                db.Tables[0].Rows.Add(DateBank.NameGamer, DateBank.Result, DateBank.Score, DateBank.Game_word, DateBank.Kol, DateBank.Lavel);
                DateBank.test_form5 = false;
            }
         
            dataGridView1.DataSource = db.Tables[0];

            rd.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {                                   //Обработка нажатия на кнопку "Выход"
            this.Close();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {                                   //Запись данных результатов игры при выходе из формы
            StreamWriter wr = new StreamWriter(fileName, false, System.Text.Encoding.Default);


            for (int i = 0; i < db.Tables[0].Columns.Count; i++)
            {
                if (i == db.Tables[0].Columns.Count - 1) wr.Write((db.Tables[0].Columns[i]).ToString());
                else wr.Write((db.Tables[0].Columns[i]).ToString() + " ");
            }
            wr.WriteLine();


            for (int i = 0; i < db.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < db.Tables[0].Columns.Count; j++)
                {

                    if (j == db.Tables[0].Columns.Count - 1) wr.Write((db.Tables[0].Rows[i][j]).ToString());
                    else wr.Write((db.Tables[0].Rows[i][j]).ToString() + " ");


                }

                wr.WriteLine();


            }

            wr.Close();

        }
    }
}
