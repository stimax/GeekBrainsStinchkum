using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StinchkumHomeworkLesson5
{
    public class MyString
    {
        string msg;

        public MyString(string message)
        {
            msg = message;
        }

        public void SearchWordsLenghtLessN(int n)
        {
            string onlyLetters = Clear(); // чистим текст
            string[] words = onlyLetters.Split(' '); // разбиваем на массив из слов

            Console.WriteLine("Список слов длиной не больше {0} симв.:", n);
            foreach (string item in words)
            {
                if (item.Length <= n)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void SearchLongestWords()
        {
            string onlyLetters = Clear(); // чистим текст
            string[] words = onlyLetters.Split(' '); // разбиваем на массив из слов

            // находим максимальную длину слова
            int maxLetters = 0;
            foreach (string item in words)
            {
                if (item.Length > maxLetters)
                {
                    maxLetters = item.Length;
                }
            }

            Dictionary<int, List<string>> words_rating = new Dictionary<int, List<string>>(maxLetters); // создаем словарь с количеством букв и списком слов

            // заполняем словарь пустыми списками
            for (int i = 0; i < (maxLetters + 1); i++)
            {
                words_rating[i] = new List<string>();
            }

            // заполняем словарь словами
            foreach (string item in words)
            {
                words_rating[item.Length].Add(item);
            }

            // выводим словарь по убыванию количества букв
            for (int i = maxLetters; i > 0; i--)
            {
                if (words_rating[i].Count != 0)
                {
                    Console.WriteLine("Количество букв: {0:D2} Список слов: ", i);

                    foreach (var item in words_rating[i])
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        public void ClearLastSymbol_S(char s)
        {
            string onlyLetters = Clear();
            string[] words = onlyLetters.Split(' '); // разбиваем на массив из слов
            List<string> words_list = new List<string>(words);

            foreach (string item in words)
            {
                if (item.Length > 0 && item[item.Length - 1] == s)
                {
                    words_list.Remove(item);
                }
            }

            Console.WriteLine("Сообщение без слов с символом \"{0}\" на конце:\n{1}", s, String.Join(" ", words_list));
        }

        public string Clear()
        {
            string msg2 = msg;
            string pattern = @"[^a-zA-Zа-яА-я\s]"; // любой символ за исключением a-z, A-Z, а-я, А-Я и пробела
            string target = ""; // менять будем на пустоту
            Regex regex = new Regex(pattern);
            string onlyLetters = regex.Replace(msg2, target); // остаются только буквы и пробелы

            // убираем двойные пробелы
            string pattern2 = @"[\s+]"; // любой ряд пробелов
            string target2 = " "; // менять на пробел
            Regex regex2 = new Regex(pattern2);
            onlyLetters = regex2.Replace(onlyLetters, target2); // остаются только буквы и одинарные пробелы

            return onlyLetters;
        }
    }
}
