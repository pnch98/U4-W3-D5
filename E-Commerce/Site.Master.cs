using System;
using System.Collections.Generic;
using System.Web.UI;

namespace E_Commerce
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                List<Article> cart = (List<Article>)Session["cart"];
                countCart.InnerText = cart.Count.ToString();
            }
        }
    }
}