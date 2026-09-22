using System;
namespace CourseBlog
{
    public static class Comments
    {
        public static void Run(BlogData data)
        {
            Console.Write("ID статьи: "); int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            { Console.WriteLine("ID должен быть целым числом."); return; }
            Article article = data.Find(id);
            if (article == null) { Console.WriteLine("Статья не найдена."); return; }
            Console.WriteLine("Комментарии к статье: " + article.Title);
            if (article.Comments.Count == 0) Console.WriteLine("Комментариев пока нет.");
            foreach (string comment in article.Comments) Console.WriteLine("- " + comment);
            Console.Write("1 — добавить комментарий; Enter — назад: ");
            if (Console.ReadLine() != "1") return;
            Console.Write("Комментарий: "); string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            { Console.WriteLine("Комментарий не должен быть пустым."); return; }
            article.Comments.Add(text.Trim());
            try { data.Save(); }
            catch { article.Comments.RemoveAt(article.Comments.Count - 1); throw; }
            Console.WriteLine("Комментарий добавлен.");
        }
    }
}