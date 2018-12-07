using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dz5
{
    class Tasks
    {
        public static void Run()
        {
            do
            {
                switch (Helps.Msg_int("Выберите задачу 1,2,3 или 4 :"))
                {
                    case 1:
                        Z1();
                        break;
                    case 2:
                        Z2();
                        break;
                    case 3:
                        Helps.Printm($"{Z3()}\n");
                        break;
                    case 4:
                        Z4();
                        break;
                    default:
                        break;
                }
            } while (Helps.Msg_int("1 - еще раз все задачи") == 1);

            Helps.Pause();


        }

        public static void Z1() //задача с массивом
        {

            //^ - начало, [A-Za-z]{1} - англ символы один раз, [A-Za-z0-9]{1,9} - цифры и англ символы от 1 до 9 раз, $ - конец
            string user_str = Helps.Msg_string("Введите логин:");

            //// первый вариант решения
            Regex regex = new Regex("^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");
            if (regex.IsMatch(user_str))
                Helps.Printm("Connection true(вариант с регулярками)\n");
            //// первый вариант решения

            //// второй вариант решения
            string check_str = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string check_numbr = "1234567890";
            int counter = 0;
            int str_len = user_str.Length;
            if (!check_numbr.Contains(user_str[0])) //ищем в строке ц ифр первый символ входной строки
                foreach (char ch in user_str)
                    foreach (char cch in check_str)
                        // проверяем, что каждый элемент юзерстринга может быть равен 
                        // хоть какому-то элементу проверочного массива, если да, то апаем счетчик
                        // потом если счетчик совпадает с длиной юзерстринга, значит всё верно
                        if (ch == cch) counter += 1; // аппер счетчика
            if (counter - str_len == 0)
                Helps.Printm("Connection true(вариант без регулярок)\n");
            //// второй вариант решения
        }

        public static void Z2()
        {
            string str = Helps.LoadFile(Helps.Msg_string("Введите файл(words.txt):"));
            // берем весь текст в строку 
            Message.MinChar(str, Helps.Msg_int("Введите максимальную длину слова:"));
            Message.DelWord(str);
            Message.MaxWord(str); // тут еще стрингбилдер
        }

        static bool Z3()
        {
            // собственный метод
            string first_line = Helps.Msg_string("Введите первую строку:");
            string second_line = Helps.Msg_string("Введите вторую строку:");
            List<char> f = new List<char>();
            List<char> s = new List<char>();
            if (first_line.Length == second_line.Length) //проверка на длину
            {
                foreach (char symbol in first_line)
                    foreach (char symbol2 in second_line)
                        if (symbol == symbol2)
                            f.Add(symbol); // если 1 слово = 2ому, то такое заполнение листа даст 1 слово
                foreach (char symbol2 in second_line)
                    foreach (char symbol in first_line)
                        if (symbol == symbol2)
                            s.Add(symbol); // если 1 слово = 2ому, то такое заполнение листа даст 2 слово
            }
            char[] firs = f.ToArray();
            char[] secn = s.ToArray();
            string fin = new string(firs);
            string sec = new string(secn);
            // если получили две идентичные первоначальным строки, значит символы в строках одинаковые.
            if (fin == first_line && sec == second_line)
            {
                return true;
            }
            return false;
        }
        public static void Z4()
        {
            // задача с играми
            //парсим файл
            string[,] questions = Helps.LoadGameFromFile(Helps.Msg_string("Сейчас будем играть!\nВведите название файла(game.txt):"));
            Random rand = new Random();
            List<int> random_list = new List<int>();
            int numbr = 0;
            //делаем заполнение листа с рандомными числами, пока не будет 5 УНИКАЛЬНЫХ значений
            do
            {
                numbr = rand.Next(1, questions.GetLength(1));
                if (!random_list.Contains(numbr))
                    random_list.Add(numbr);
            } while (random_list.Count < 5);
            int counter = 0;
            for (int i =0; i<random_list.Count;i++)
            {
                
                // обрезаем пробелы, уравниваем шансы заглавных/незаглавных букв, если ответ равен ответу из файла, счетчик прибавляем
                if (Helps.Msg_string($"{questions[0, random_list[i]].Trim()}").Trim().ToUpper() == questions[1, random_list[i]].Trim().ToUpper())
                {
                    counter +=1;
                }
            }
            Helps.Printm($"Отлично поиграли! Итоговый счет:{counter}\n");


        }
    }
}
