using System;
namespace CourseBlog
{
    public static class Menu
    {
        static readonly string[] Items = { "Просмотр статей", "Добавить статью", "Комментарии", "Выход" };
        public static int Choose(bool lineMenu)
        {
            if (lineMenu)
            {
                while (true)
                {
                    Console.WriteLine("\nБлог: 1 — статьи; 2 — добавить; 3 — комментарии; 0 — выход");
                    int value; string text = Console.ReadLine();
                    if (text == null) return 0;
                    if (int.TryParse(text, out value) && value >= 0 && value <= 3) return value;
                    Console.WriteLine("Введите число от 0 до 3.");
                }
            }
            bool expanded = false; int selected = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("БЛОГ С КОММЕНТАРИЯМИ");
                Console.WriteLine(expanded ? "[ Меню ^ ]" : "[ Меню v ]");
                if (expanded)
                    for (int i = 0; i < Items.Length; i++)
                        Console.WriteLine((selected == i ? " > " : "   ") + Items[i]);
                Console.WriteLine("Enter — открыть/выбрать, стрелки — выбор, Esc — свернуть/выход");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) { if (expanded) expanded = false; else return 0; }
                else if (key == ConsoleKey.Enter)
                {
                    if (!expanded) expanded = true;
                    else return selected == 3 ? 0 : selected + 1;
                }
                else if (expanded && key == ConsoleKey.DownArrow) selected = (selected + 1) % Items.Length;
                else if (expanded && key == ConsoleKey.UpArrow) selected = (selected + Items.Length - 1) % Items.Length;
            }
        }
    }
}