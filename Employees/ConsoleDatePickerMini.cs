using System;

namespace Employees
{
    class ConsoleDatePickerMini
    {
        public int Left { get; }
        public int Top { get; }
        public DateTime SelectedDate { get; private set; }

        public ConsoleDatePickerMini(int left, int top, DateTime date)
        {
            Left = left;
            Top = top;
            SelectedDate = date;
        }

        public ConsoleDatePickerMini(int left, int top) : this(left, top, System.DateTime.Today) { }

        public ConsoleDatePickerMini() : this(0, 0) { }

        public void Show()
        {
            int oldLeft = Console.CursorLeft, oldTop = Console.CursorTop;
            ShowDate();
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        public DateTime GetDate()
        {
            int oldLeft = Console.CursorLeft, oldTop = Console.CursorTop;
            bool cursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            int f = 0;
            ConsoleKeyInfo key;
            do
            {
                ShowCursor(f);
                Console.SetCursorPosition(oldLeft, oldTop);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow) f = (f + 1) % 3;
                if (key.Key == ConsoleKey.LeftArrow) f = (f + 2) % 3;
                if (key.Key == ConsoleKey.UpArrow ||
                    key.Key == ConsoleKey.DownArrow)
                {
                    int additive = key.Key == ConsoleKey.UpArrow ? 1 : -1;
                    if (f == 0) SelectedDate = SelectedDate.AddDays(additive);
                    else if (f == 1) SelectedDate = SelectedDate.AddMonths(additive);
                    else if (f == 2) SelectedDate = SelectedDate.AddYears(additive);
                }
                ShowDate();
            }
            while (key.Key != ConsoleKey.Enter);
            Console.CursorVisible = cursorVisible;
            Console.SetCursorPosition(oldLeft, oldTop);
            return SelectedDate;
        }

        void ShowDate()
        {
            Console.SetCursorPosition(Left, Top);
            Console.Write("          ");
            Console.SetCursorPosition(Left, Top + 1);
            Console.Write(SelectedDate.ToString("dd.MM.yyyy"));
            Console.SetCursorPosition(Left, Top + 2);
            Console.Write("          ");
        }

        void ShowCursor(int field)
        {
            int offset = new[] { 1, 4, 9 }[field]; // или по хакерски: int offset = (field + 1) * (field + 1);
            Console.SetCursorPosition(Left + offset, Top);
            Console.Write("+");
            Console.SetCursorPosition(Left + offset, Top + 2);
            Console.Write("-");
        }

        //static void DateTime(ConsoleDatePickerMini v)
        //{
        //    throw new NotImplementedException();
        //}

        public static implicit operator DateTime(ConsoleDatePickerMini v)
        {
            throw new NotImplementedException();
        }
    }
}
