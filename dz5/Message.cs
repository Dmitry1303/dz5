using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{
    class Message
    {
        public static void Start()
        {

        }
        private string _Messag;

        public string Messag //потому что нельзя называть таким же именем, как имя самого класса
        {
            get
            {
                return _Messag;
            }
            set
            {
                _Messag = value;
            }
        }

        public Message(string Msg)
        {
            if (Msg == null)
                throw new NullReferenceException("Указана пустая ссылка на массив");
            _Messag = Msg;
        }

        public static void MinChar(string msg, int n)
        {
            //ищем слова длины меньше чем
            string items = "";
            //string b1 = $"([А-Яа-я]{{1,{n}}})";
            //string b1 = $"(\W)([A-Za-z]\(W)";\
            // вот здесь проблема
            // вот здесь проблема
            //Regex regex1 = new Regex(@"(\W)([A-Za-z]{1,5}\(W)");
            //MatchCollection b = regex1.Matches(msg);
            //foreach (Match match in regex1.Matches(msg))
            //    Helps.Printm($"Найдено {match.Value}, индекс {match.Index}\n");
            string[] str_mass = msg.Split(new char[] { ' ', '/', ':', '_', ',', '.', '!', '?' }).ToArray();
            foreach (string word in str_mass)
                if (word.Length <= n)
                    items = items + word + ";";
            Helps.Printm($"Входящее сообщение: {msg}\nСлова:{items}\n");
        }
        public static void DelWord(string msg)
        {
            // удаляем слово заканчивающееся на 
            string items = "";
            string[] str_mass = msg.Split(new char[] { ' ', '/', ':', '_', ',', '.', '!', '?' }).ToArray();
            char symb = Helps.Msg_string("Введите один символ (остальные обрежутся):")[0];
            foreach (string word in str_mass)
                if (word[word.Length - 1] != symb)
                    items = items + word + ";";
            Helps.Printm($"После удаления:{items}\n");
        }
        public static void MaxWord(string msg)
        { 
            // ищем максимальное и его аналоги
            string max_word = "";
            //string items = "";
            string[] str_mass = msg.Split(new char[] { ' ', '/', ':', '_', ',', '.', '!', '?' }).ToArray();
            foreach (string word in str_mass)
                if (word.Length > max_word.Length)
                    max_word = word;
            StringBuilder strbuild = new StringBuilder(max_word);
            foreach (string word in str_mass)
                if (word.Length == max_word.Length && word != max_word)
                    strbuild.Append(";"+word);
                    //items = items + max_word + word; 
            Helps.Printm($"Самое длинное слово: \n{max_word}; Длина: {max_word.Length}\n");
            Helps.Printm($"Длинное слово и его аналоги:\n{strbuild.ToString()}\n");
        }
    }
}
