using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Employees
{
    struct Notepad
    {
        public List<Content> content;
        string[] titles;                            // Заголовки столбцов

        /// <summary>
        /// Конструктор
        /// </summary>
        public Notepad(params Content[] Args)
        {
            content = new List<Content>();
            titles = new string[]                   // Инициализация заголовков столбцов
            {"ID", "Дата создания записи", "ФИО сотрудника", "Возраст", "Рост", "Дата рождения", "Место рождения"};
        }

        /// <summary>
        /// Метод для создания или добавления записей
        /// </summary>
        /// <param name="contentLine">Строка данных для добавления в блокнот</param>
        public void AddLine(Content contentLine)
        {
            content.Add(contentLine);
        }

        /// <summary>
        /// Метод загрузки данных из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void Load(string path)
        {
            content.Clear();                                    // Очистка списка перед новой загрузкой

            using (StreamReader read = new StreamReader(path))
            {
                while (!read.EndOfStream)
                {
                    string[] arg = read.ReadLine().Split('#');
                    AddLine(new Content(Convert.ToInt32(arg[0]), Convert.ToDateTime(arg[1]), arg[2], Convert.ToInt32(arg[3]), Convert.ToInt32(arg[4]), Convert.ToDateTime(arg[5]), arg[6]));
                }
            }
        }

        /// <summary>
        /// Метод для добавления новых данных
        /// </summary>
        /// <param name="arg">Данные строки</param>
        public void AddItem(params string[] arg)
        {
            AddLine(new Content(Int32.Parse(arg[0]), arg[1], Int32.Parse(arg[2]), Int32.Parse(arg[3]), Convert.ToDateTime(arg[4]), arg[5]));
        }

        /// <summary>
        /// Метод для вывода данных в консоли
        /// </summary>
        public void PrintDB()
        {
            Console.WriteLine($"{titles[0],10} {titles[1],20} {titles[2],23} {titles[3],10} {titles[4],8} {titles[5],20} {titles[6],18}\n");
            for (int i = 0; i < content.Count; i++)
            {
                Console.WriteLine(content[i].Print());
            }
            Console.WriteLine($"\nКоличество записей в списке {content.Count}");
        }

        /// <summary>
        /// Метод удаления записей
        /// </summary>
        /// <param name="line">Номер строки для удаления</param>
        public void Del(int line)
        {
            content.RemoveAt(line - 1);
        }

        /// <summary>
        /// Метод сохранения данных в файл
        /// </summary>
        /// <param name="savepath">Путь к файлу для сохранения</param>
        public void Save(string savepath)
        {
            File.Delete(savepath);                      // Удаление старого файла

            for (int i = 0; i < content.Count; i++)     // Сохранение записей с информацией
            {
                string line = String.Format($"{content[i].ID}#{content[i].DateOfCreation}#{content[i].EmployeeName}#{content[i].EmployeeAge}#{content[i].EmployeeHeight}#{content[i].EmployeeBDay}#{content[i].EmployeeCity}");
                File.AppendAllText(savepath, $"{line}\n", Encoding.UTF8);
            }
        }

        /// <summary>
        /// Метод добавления данных из файла
        /// </summary>
        /// <param name="addfile">Путь к файлу</param>
        public void Merge(string addfile)
        {
            using (StreamReader read = new StreamReader(addfile))
            {
                while (!read.EndOfStream)
                {
                    string[] arg = read.ReadLine().Split('#');
                    AddLine(new Content (Convert.ToInt32(arg[0]), Convert.ToDateTime(arg[1]), arg[2], Convert.ToInt32(arg[3]), Convert.ToInt32(arg[4]), Convert.ToDateTime(arg[5]), arg[6]));
                }
            }

        }

        /// <summary>
        /// Метод импортирования записей по выбранному диапазону
        /// </summary>
        /// <param name="date1">Начальная дата для импорта</param>
        /// <param name="date2">Конечная дата для импорта</param>
        /// <param name="importfile">Путь к файлу для импорта данных</param>
        public void Import(string date1, string date2, string importfile)
        {
            DateTime startDate = Convert.ToDateTime(date1);
            DateTime endDate = Convert.ToDateTime(date2);

            using (StreamReader read = new StreamReader(importfile))
            {
                while (!read.EndOfStream)
                {
                    string[] arg = read.ReadLine().Split('#');
                    DateTime arg0 = Convert.ToDateTime(arg[0]);

                    if (arg0 >= startDate && arg0 <= endDate)               // Проверка на заданный диапазон дат
                    {
                        AddLine(new Content(Convert.ToInt32(arg[0]), Convert.ToDateTime(arg[1]), arg[2], Convert.ToInt32(arg[3]), Convert.ToInt32(arg[4]), Convert.ToDateTime(arg[5]), arg[6]));
                    }
                }
            }
        }

        /// <summary>
        /// Метод сортировки записей по выбранному полю
        /// </summary>
        /// <param name="line">Номер поля для редактирования</param>
        public void Sort(int line)
        {
            switch (line)
            {
                case 1:
                    content = content.OrderBy(e => e.ID)
                        .ThenBy(e => e.DateOfCreation)
                        .ThenBy(e => e.EmployeeName)
                        .ThenBy(e => e.EmployeeAge)
                        .ThenBy(e => e.EmployeeHeight)
                        .ThenBy(e => e.EmployeeBDay)
                        .ThenBy(e => e.EmployeeCity)
                        .ToList();
                    break;

                case 2:
                    content = content.OrderBy(e => e.DateOfCreation)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.EmployeeName)
                        .ThenBy(e => e.EmployeeAge)
                        .ThenBy(e => e.EmployeeHeight)
                        .ThenBy(e => e.EmployeeBDay)
                        .ThenBy(e => e.EmployeeCity)
                        .ToList();
                    break;

                case 3:
                    content = content.OrderBy(e => e.EmployeeName)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.DateOfCreation)
                        .ThenBy(e => e.EmployeeAge)
                        .ThenBy(e => e.EmployeeHeight)
                        .ThenBy(e => e.EmployeeBDay)
                        .ThenBy(e => e.EmployeeCity)
                        .ToList();
                    break;

                case 4:
                    content = content.OrderBy(e => e.EmployeeAge)
                       .ThenBy(e => e.ID)
                       .ThenBy(e => e.DateOfCreation)
                       .ThenBy(e => e.EmployeeName)
                       .ThenBy(e => e.EmployeeHeight)
                       .ThenBy(e => e.EmployeeBDay)
                       .ThenBy(e => e.EmployeeCity)
                       .ToList();
                    break;

                case 5:
                    content = content.OrderBy(e => e.EmployeeHeight)
                       .ThenBy(e => e.ID)
                       .ThenBy(e => e.DateOfCreation)
                       .ThenBy(e => e.EmployeeName)
                       .ThenBy(e => e.EmployeeAge)
                       .ThenBy(e => e.EmployeeBDay)
                       .ThenBy(e => e.EmployeeCity)
                       .ToList();
                    break;
                case 6:
                    content = content.OrderBy(e => e.EmployeeBDay)
                        .ThenBy(e => e.ID)
                        .ThenBy(e => e.DateOfCreation)
                        .ThenBy(e => e.EmployeeName)
                        .ThenBy(e => e.EmployeeAge)
                        .ThenBy(e => e.EmployeeHeight)
                        .ThenBy(e => e.EmployeeCity)
                        .ToList();
                    break;
                case 7:
                    content = content.OrderBy(e => e.EmployeeCity)
                       .ThenBy(e => e.ID)
                       .ThenBy(e => e.DateOfCreation)
                       .ThenBy(e => e.EmployeeName)
                       .ThenBy(e => e.EmployeeAge)
                       .ThenBy(e => e.EmployeeHeight)
                       .ThenBy(e => e.EmployeeBDay)
                       .ToList();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Метод редактирования записи
        /// </summary>
        /// <param name="line">Номер строки для редактирования</param>
        public void Edit(int line)
        {
            Content temp = new Content();                                   // Создание временной переменной
            Console.WriteLine("Введите новое ФИО: ");
            temp.EmployeeName = Console.ReadLine();
            Console.WriteLine("Введите новый возраст: ");
            //temp.EmployeeAge = Console.ReadLine();
            temp.EmployeeAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новый рост: ");
            //temp.EmployeeHeight = Console.ReadLine();
            temp.EmployeeHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новую дату рождения сотрудника: ");
            temp.EmployeeBDay = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите новое место рождения: ");
            temp.EmployeeCity = Console.ReadLine();
            content[line - 1] = temp;                                       // Перекидываем изменённые данные из переменной назад в список
        }
    }
}
