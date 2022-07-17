using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    struct Content
    {
        #region Поля
        /// <summary>
        /// ID сотрудника
        /// </summary>
        private int iD;
        /// <summary>
        /// Дата создания записи
        /// </summary>
        private DateTime dateOfCreation;
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        private string employeeName;
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        private int employeeAge;
        /// <summary>
        /// Рост сотрудника
        /// </summary>
        private int employeeHeight;
        /// <summary>
        /// День рождения сотрудника
        /// </summary>
        private DateTime employeeBDay;
        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        private string employeeCity;

        #endregion

        #region Свойства
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID { get { return this.iD; } }
        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime DateOfCreation { get => this.dateOfCreation; private set { } }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeeName { get { return this.employeeName; } set { this.employeeName = value; } }
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int EmployeeAge { get { return this.employeeAge; } set { this.employeeAge = value; } }
        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int EmployeeHeight { get { return this.employeeHeight; } set { this.employeeHeight = value; } }
        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime EmployeeBDay { get { return this.employeeBDay; } set { this.employeeBDay = value; } }
        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string EmployeeCity { get { return this.employeeCity; } set { this.employeeCity = value; } }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор для создания записи о сотруднике
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        /// <param name="DateOfCreation">Дата создания записи</param>
        /// <param name="EmployeeName">Имя сотрудника</param>
        /// <param name="EmployeeAge">Возраст сотрудника</param>
        /// <param name="EmployeeHeight">Рост сотрудника</param>
        /// <param name="EmployeeBDay">День рождения сотрудника</param>
        /// <param name="EmployeeCity">Место рождения сотрудника</param>
        public Content (int ID, DateTime DateOfCreation, string EmployeeName, int EmployeeAge, int EmployeeHeight, DateTime EmployeeBDay, string EmployeeCity)
        {
            this.iD = ID;
            this.dateOfCreation = DateOfCreation;
            this.employeeName = EmployeeName;
            this.employeeAge = EmployeeAge;
            this.employeeHeight = EmployeeHeight;
            this.employeeBDay = EmployeeBDay;
            this.employeeCity = EmployeeCity;
        }
        /// <summary>
        /// Конструктор для создания записи о сотруднике c установкой текущего времени создания записи
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        /// <param name="EmployeeName">Имя сотрудника</param>
        /// <param name="EmployeeAge">Возраст сотрудника</param>
        /// <param name="EmployeeHeight">Рост сотрудника</param>
        /// <param name="EmployeeBDay">День рождения сотрудника</param>
        /// <param name="EmployeeCity">Место рождения сотрудника</param>
        public Content (int ID, string EmployeeName, int EmployeeAge, int EmployeeHeight, DateTime EmployeeBDay, string EmployeeCity) :
            this(ID, DateTime.Now, EmployeeName, EmployeeAge, EmployeeHeight, EmployeeBDay, EmployeeCity)
        { }

        #endregion

        /// <summary>
        /// Метод вывода данных в консоль
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{iD,10} {DateOfCreation,20} {EmployeeName,30} {EmployeeAge,10} {EmployeeHeight,8} {EmployeeBDay,20} {EmployeeCity,18}";
        }
    }
}
