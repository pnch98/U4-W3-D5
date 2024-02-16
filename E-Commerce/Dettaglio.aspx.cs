using System;
using System.Collections.Generic;

namespace E_Commerce
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["idArticle"]);

            Article selectedArticle = Article.GetArticleById(id);
            imageArticle.Src = selectedArticle.Image;
            titleArticle.InnerText = selectedArticle.Name;
            descriptionArticle.InnerText = selectedArticle.Description;
            priceArticle.InnerText = "Price: " + selectedArticle.Price;
        }

        //Metodo per aggiungere l'articolo al carrello simile a quello presente nella pagina Default
        protected void AddToCart(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["idArticle"]);

            List<Article> cart = (List<Article>)Session["cart"];
            cart.Add(Article.GetArticleById(id));
            Session["cart"] = cart;
            Response.Redirect(Request.RawUrl);
        }
    }
}