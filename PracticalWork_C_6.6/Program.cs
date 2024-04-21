using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_C_6._6
{
    internal class Program
    {
        /// <summary>
        /// Запись нового сотрудника в файл
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fio"></param>
        /// <param name="age"></param>
        /// <param name="height"></param>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        static void WorkerWriter(string id, string date,string fio, string age, string height, string birthDate, string birthPlace)
        {
            using (StreamWriter sw = new StreamWriter("Worker.txt", true, Encoding.Unicode))
            {
                DateTime dateAddWorker = DateTime.Now;
                string note = id + "#" + date + "#" + fio + "#" + age + 
                            "#" + height + "#" + birthDate + "#" + birthPlace;
                sw.WriteLine(note);
            }
        }

        /// <summary>
        /// Ввод данных сотрудника и запись их в файл методом WorkerWriter
        /// </summary>
        static void FillingWithDataAndWriter()
        {
            char key = 'д';

            do
            {
                Console.Clear();

                #region Ввод данных сотрудника

                Console.WriteLine("Справочник <Сотрудники>.");
                Console.WriteLine();

                // Ввод ID сотрудника
                Console.Write("Введите ID сотрудника: ");
                string idAddWorker = Console.ReadLine();

                // Дата добавления сотрудника
                Console.Write("Дата добавления сотрудника: ");
                string dateAddWorker = DateTime.Now.ToShortDateString();
                Console.WriteLine($"{dateAddWorker}");

                // ФИО добавляемого сотрудника
                Console.Write("Введите ФИО сотрудника: ");
                string fioAddWorker = Console.ReadLine();

                // Возраст сотрудника
                Console.Write("Введите возраст сотрудника: ");
                string ageAddWorker = Console.ReadLine();

                // Рост сотрудника
                Console.Write("Введите рост сотрудника: ");
                string heightAddWorker = Console.ReadLine();

                // Дата рождения сотрудника
                Console.Write("Введите дату рождения сотрудника: ");
                string birthDateAddWorker = Console.ReadLine();

                // Место рождения сотрудника
                Console.Write("Введите место рождения сотрудника: ");
                string birthPlaceAddWorker = Console.ReadLine();

                #endregion

                WorkerWriter(idAddWorker, dateAddWorker, fioAddWorker, ageAddWorker, heightAddWorker,
                                    birthDateAddWorker, birthPlaceAddWorker);

                Console.WriteLine("Запись добавлена. Ввести ещё сотрудника? н/д");
                key = Console.ReadKey(true).KeyChar;

            } while (char.ToLower(key) == 'д');

            Console.Clear();
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод данных из файла
        /// </summary>
        static void WorkerDataOutput() 
        {
            // Проверяем файл на существование и если он существует, то выводим данные
            if (File.Exists(@"Worker.txt"))
            {
                // Открывает доступ к файлу для чтения данных
                using (StreamReader sr = new StreamReader("Worker.txt", Encoding.Unicode))
                {
                    Console.WriteLine();

                    Console.WriteLine($"{"id", 5} * {"Дата записи", 11} * {"ФИО", 30} * {"Возраст", 7}" +
                                        $" * {"Рост", 4} * {"Дата рождения", 13} * {"Место рождения", 15}");

                    Console.WriteLine();
                    string line;

                    // Пока не пустая строка, выводим данные
                    while ((line = sr.ReadLine()) != null) 
                    {
                        // Разбиваем строку в массив по #
                        string[] data = line.Split('#');
                        Console.WriteLine($"{data[0], 5} * {data[1], 11} * {data[2], 30} * {data[3], 7} * " +
                                            $"{data[4], 4} * {data[5], 13} * {data[6], 15}");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Файл не найден.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа C# 6.6. Создать справочник <Сотрудники>");
            Console.WriteLine();

            bool indexСycle = true;

            do
            {
                Console.Write("Выберите действие: 1 - Вывести данные на экран. 2 - Добавить данные. 0 - Выход : ");
                byte indexData = Convert.ToByte(Console.ReadLine());

                switch (indexData)
                {
                    case 0:
                        indexСycle = false;
                        break;
                    case 1:
                        WorkerDataOutput();
                        break;
                    case 2:
                        FillingWithDataAndWriter();
                        break;                    
                }
            } while (indexСycle);            
        }
    }
}
