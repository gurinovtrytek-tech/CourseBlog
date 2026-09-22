using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace CourseBlog
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<string> Comments { get; set; }
        public Article() { Comments = new List<string>(); }
    }
    public class BlogData
    {
        public List<Article> Articles { get; set; }
        public BlogData() { Articles = new List<Article>(); }
        static string FileName { get { return Path.Combine("data", "blog.xml"); } }
        public static BlogData Load()
        {
            if (!File.Exists(FileName)) return new BlogData();
            using (var stream = File.OpenRead(FileName))
                return (BlogData)new XmlSerializer(typeof(BlogData)).Deserialize(stream);
        }
        public void Save()
        {
            Directory.CreateDirectory("data");
            string temporary = FileName + ".tmp";
            using (var stream = File.Create(temporary))
                new XmlSerializer(typeof(BlogData)).Serialize(stream, this);
            if (File.Exists(FileName)) File.Replace(temporary, FileName, FileName + ".bak");
            else File.Move(temporary, FileName);
        }
        public Article Find(int id) { return Articles.Find(a => a.Id == id); }
    }
}