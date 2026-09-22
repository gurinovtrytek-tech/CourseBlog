using System;
namespace CourseBlog
{
    public static class ViewArticles
    {
        public static void Run(BlogData data)
        {
            if (data.Articles.Count == 0) { Console.WriteLine("Статей пока нет."); return; }
            foreach (Article article in data.Articles)
            {
                Console.WriteLine("[" + article.Id + "] " + article.Title);
                Console.WriteLine(article.Text);
                Console.WriteLine("Комментариев: " + article.Comments.Count);
            }
        }
    }
}