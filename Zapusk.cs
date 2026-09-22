using System;
using System.Text;
namespace CourseBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = new UTF8Encoding(false);
            Console.OutputEncoding = new UTF8Encoding(false);
            bool lineMenu = Array.IndexOf(args, "--line-menu") >= 0 || Console.IsInputRedirected;
            BlogData data;
            try { data = BlogData.Load(); }
            catch (Exception e) { Console.WriteLine("Не удалось прочитать данные: " + e.Message); return; }
            while (true)
            {
                int choice = Menu.Choose(lineMenu);
                if (choice == 0) break;
                try
                {
                    if (choice == 1) ViewArticles.Run(data);
                    if (choice == 2) AddArticle.Run(data);
                    if (choice == 3) Comments.Run(data);
                }
                catch (Exception e) { Console.WriteLine("Ошибка операции: " + e.Message); }
                if (!lineMenu) { Console.WriteLine("Нажмите любую клавишу..."); Console.ReadKey(true); }
            }
            Console.WriteLine("Работа завершена.");
        }
    }
}