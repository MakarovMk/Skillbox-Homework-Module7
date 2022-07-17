using System;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ДЗ

            ///  
            /// Улучшите программу, которую разработали в модуле 6. Создайте структуру «Сотрудник» со следующими полями:
            /// - ID                                +
            /// - Дата и время добавления записи    +
            /// - Ф.И.О.                            +
            /// - Возраст                           +    
            /// - Рост                              +
            /// - Дата рождения                     +
            /// - Место рождения                    +
            ///
            /// - Для записей реализуйте следующие функции:
            /// - Просмотр записи. Функция должна содержать параметр ID записи, которую необходимо вывести на экран.
            /// - Создание записи.
            /// - Удаление записи.
            /// - Редактирование записи.
            /// - Загрузка записей в выбранном диапазоне дат.
            /// - Сортировка по возрастанию и убыванию даты.
            /// 
            #endregion

            string savepath = "savedata.txt";       // Путь к файлу для сохранения данных
            string addfile = "adddata.txt";         // Путь к файлу с доп данными для добавления в таблицу
            string importfile = "importfile.txt";   // Путь к файлу с данными для импорта
            int line;                               // Переменная номера строки/поля
            string id, age, height, name, city, bdaystr, date1str, date2str;

            Notepad notepad = new Notepad(new Content());

            while (true)
            {
                Console.WriteLine("Выберите действие:\n");
                Console.WriteLine("1 - загрузка данных из файла");
                Console.WriteLine("2 - сохранение данных в файл");
                Console.WriteLine("3 - добавление данных в текущий блокнот из файла");
                Console.WriteLine("4 - создание записи");
                Console.WriteLine("5 - удаление записи");
                Console.WriteLine("6 - редактирование записи");
                Console.WriteLine("7 - импорт записей по выбранному диапазону дат");
                Console.WriteLine("8 - сортировка записей по выбранному полю");
                Console.WriteLine("9 - вывод блокнота на экран");
                Console.WriteLine("0 - выход");
                int key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        notepad.Load(savepath);
                        Console.Clear();
                        Console.WriteLine("Файл загружен\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 2:
                        notepad.Save(savepath);
                        Console.Clear();
                        Console.WriteLine("Файл сохранён\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 3:
                        notepad.Merge(addfile);
                        Console.Clear();
                        Console.WriteLine("Данные добавлены\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Введите ID сотрудника: ");
                        id = Console.ReadLine();

                        Console.WriteLine("Введите ФИО сотрудника: ");
                        name = Console.ReadLine();

                        Console.WriteLine("Введите возраст сотрудника: ");
                        age = Console.ReadLine();

                        Console.WriteLine("Введите рост сотрудника: ");
                        height = Console.ReadLine();

                        Console.WriteLine("Введите дату рождения сотрудника: ");
                        bdaystr = Console.ReadLine();

                        Console.WriteLine("Введите место рождения сотрудника: ");
                        city = Console.ReadLine();

                        notepad.AddItem(id, name, age, height, bdaystr, city);
                        Console.Clear();
                        Console.WriteLine("Данные добавлены\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Введите номер строки для удаления");
                        line = int.Parse(Console.ReadLine());
                        notepad.Del(line);
                        Console.Clear();
                        Console.WriteLine("Запись удалена\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.WriteLine("Введите номер строки для редактирования");
                        line = int.Parse(Console.ReadLine());
                        notepad.Edit(line);
                        Console.Clear();
                        Console.WriteLine("Данные отредактированы\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 7:
                        Console.WriteLine("Введите начальную дату для импорта(формат dd-mm-yy):");
                        date1str = Console.ReadLine();

                        Console.WriteLine("Введите конечную дату для импорта(формат dd-mm-yy):");
                        date2str = Console.ReadLine();

                        notepad.Import(date1str, date2str, importfile);
                        Console.Clear();
                        Console.WriteLine("Данные импортированы\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 8:
                        Console.WriteLine("Выберите номер поля, по которому делать сортировку (1-8)");
                        line = int.Parse(Console.ReadLine());
                        notepad.Sort(line);
                        Console.Clear();
                        Console.WriteLine("Данные отсортированы\n\n");
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 9:
                        Console.Clear();
                        notepad.PrintDB();
                        Console.ReadLine();
                        break;

                    case 0:
                        return;

                    default:
                        break;
                }
            }
        }
    }
}
