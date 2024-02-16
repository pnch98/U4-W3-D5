using System.Collections.Generic;

namespace E_Commerce
{
    public class Article
    {
        private static int count = 0;
        private int id;
        public int Id { get => id; }
        private string name;
        public string Name { get => name; }
        private string description;
        public string Description { get => description; }
        private double price;
        public double Price { get => price; }
        private string image;
        public string Image { get => image; }
        private static HashSet<Article> articlesList = new HashSet<Article>();

        public Article(string name, string description, double price, string image)
        {
            this.id = count++;
            this.name = name;
            this.description = description;
            this.price = price;
            this.image = image;
        }

        public static void AddArticle(Article article)
        {
            articlesList.Add(article);
        }

        public int getId() { return id; }
        public static HashSet<Article> getArticlesList() { return articlesList; }
        public static Article GetArticleById(int id)
        {
            Article selectedArticle = null;

            foreach (Article article in articlesList)
            {
                if (article.Id == id)
                {
                    selectedArticle = article;
                }
            }
            return selectedArticle;
        }
    }
}