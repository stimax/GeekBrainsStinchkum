using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Stinchkum Maksim
//Homework lesson 5

namespace StinchkumHomeworkLesson5
{
    class Program
    {
        static void Main()
        {
            //1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
            //а) без использования регулярных выражений;
            //б) с использованием регулярных выражений.

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Результат проверки на корректность без регулярных выражений: {0}", LogIn_NoReg(login));
            Console.WriteLine("Результат проверки на корректность c регулярными выражениями: {0}", LogIn_Reg(login));
            Console.ReadKey();

            // 2. Разработать методы для решения следующих задач. Дано сообщение:
            // + а) Вывести только те слова сообщения, которые содержат не более чем n букв;
            // + б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
            // + в) Найти самое длинное слово сообщения;
            // + г) Найти все самые длинные слова сообщения.
            // + Постараться разработать класс MyString.

            MyString txt = new MyString("Разработать методы для решения следующих задач. Дано сообщение:\n" +
                "а) Вывести только те слова сообщения, которые содержат не более чем n букв;\n" +
                "б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;\n" +
                "в) Найти самое длинное слово сообщения;\n" +
                "г) Найти все самые длинные слова сообщения.\n" +
                "Постараться ​​разработать ​​класс ​​MyString.");
            txt.SearchWordsLenghtLessN(5);
            Console.WriteLine();

            txt.ClearLastSymbol_S('я');
            Console.WriteLine();

            txt.SearchLongestWords();

            Console.ReadKey();

            // 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
            // а) + с использованием методов C#
            // б) ? * разработав собственный алгоритм
            // Например:
            // badc являются перестановкой abcd

            Console.WriteLine(Compare_2_words("badc", "abcd"));
            Console.WriteLine(Compare_2_words("badc", "abcde"));
            Console.WriteLine(Compare_2_words("badc", "asds"));
            Console.ReadKey();
        }

        static bool LogIn_NoReg(string login)
        {
            // если длина от 2 до 10 и первый символ не цифра, то проверяем каждый символ на букву или цифру
            if (login.Length >= 2 && login.Length <= 10 && char.GetNumericValue(login[0]) == -1)
            {
                foreach (char item in login)
                {
                    if (char.IsLetterOrDigit(item) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        static bool LogIn_Reg(string login)
        {
            Regex myReg = new Regex(@"^[A-Za-zА-Яа-я][A-Za-zА-Яа-я0-9]{1,9}$");
            return myReg.IsMatch(login);
        }

        static bool Compare_2_words(string word1, string word2)
        {
            if (word1.Length == word2.Length)
            {
                char[] array1 = word1.ToCharArray();
                char[] array2 = word2.ToCharArray();
                Array.Sort(array1);
                Array.Sort(array2);
                return Enumerable.SequenceEqual(array1, array2);
            }
            return false;
        }
    }
}
