using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prendo la Session che contiene la lista di articoli. Se non è nulla, la collego al repeater e calcolo il totale
            List<Article> articles = (List<Article>)Session["cart"];
            if (Session["cart"] != null && articles.Count > 0)
            {
                cartRow.Attributes.Remove("style");
                cartRepeater.DataSource = articles;
                cartRepeater.DataBind();

                double total = 0;

                foreach (var item in articles)
                {
                    total += item.Price;
                }

                totalPrice.InnerText = "Prezzo totale: " + total + "€";
            }
            else
            {
                emptyCart.Attributes.Remove("style");
            }
        }

        //Metodo che rimuove un articolo dal carrello
        protected void Remove(object sender, EventArgs e)
        {
            //Prendo l'id dal CommandArgument del Button
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);

            //Riprendo la lista di articoli e cerco l'articolo con quell'id tramite il metodo statico della classe Article
            List<Article> cart = (List<Article>)Session["cart"];
            Article selectedArticle = cart.Find(item => item.Id == id);

            //Rimuovo tale articolo da cart e riaggiorno la Session["cart"] con la lista aggiornata
            cart.Remove(selectedArticle);
            Session["cart"] = cart;
            Response.Redirect(Request.RawUrl);
        }

        //Metodo che svuota la lista di articoli e aggiorna la Session con la lista vuota
        protected void RemoveAll(object sender, EventArgs e)
        {
            List<Article> cart = (List<Article>)Session["cart"];
            cart.Clear();
            Session["cart"] = cart;
            Response.Redirect(Request.RawUrl);
        }
    }
}