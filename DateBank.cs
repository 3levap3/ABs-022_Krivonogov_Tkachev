
namespace Курсовая_работа
{
    static class DateBank
    {

        //Для Form1
        public static string File_name;
        public static string Game_word;
        public static string Hint;
        public static string Image_name = @"C:\Users\pavelkrivonogov\source\repos\Курсовая работа\Курсовая работа\bin\Debug\GameDate\";
        public static string Image = ".png";
        
        public static bool test_form1_1 = false;        //Проверка на начало игры (нажималась ли кнопка)
        

        //Для Form2
        public static string NameGamer;
        public static int Lavel;
        public static bool test_form2_1 = false;        //Проверка на способ закрытия формы
                                                        //(true - на кнопку, false - на крест)


        //Для Form3
        public static int Score;
        public static int Kol = 0;
        public static bool Res;

        //Для Form3

        public static bool test_position_1 = false;
        public static bool test_position_2 = false;
        public static bool test_position_3 = false;
        public static int X_position_1;
        public static int Y_position_1;
        public static int X_position_2;
        public static int Y_position_2;
        public static int X_position_3;
        public static int Y_position_3;
        public static string fileName = @"C:\Users\pavelkrivonogov\source\repos\Курсовая работа\Курсовая работа\bin\Debug\GameDate\Coordinates.txt";


        //Для Form5
        public static bool test_form5 = true;
        public static string Result;


        //Для кол-ва очков

        public static int Score_hint = 100;
        public static int Score_mistake;


    }
}
