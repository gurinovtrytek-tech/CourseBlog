using System;
namespace CourseBlog
{
    public static class AddArticle
    {
        public static void Run(BlogData data)
        {
            Console.Write("Заголовок: "); string title = Console.ReadLine();
            Console.Write("Текст: "); string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(text))
            { Console.WriteLine("Заголовок и текст не должны быть пустыми."); return; }
            int id = 1;
            foreach (Article item in data.Articles) if (item.Id >= id) id = item.Id + 1;
            var article = new Article { Id = id, Title = title.Trim(), Text = text.Trim() };
            data.Articles.Add(article);
            try { data.Save(); }
            catch { data.Articles.Remove(article); throw; }
            Console.WriteLine("Статья добавлена. ID: " + id);
        }
    }
}