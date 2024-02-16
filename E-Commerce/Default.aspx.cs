using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Controllo che la pagina non sia rirenderizzata tramite interazione
            if (!IsPostBack)
            {
                //Svuoto la lista di articoli e la rigenero in modo da non moltiplicarla al refresh
                Article.getArticlesList().Clear();
                GenerateArticles();
                //Mi collego al repeater di Default.aspx e gli passo come sorgente il mio hashset di articoli
                Repeater.DataSource = Article.getArticlesList();
                Repeater.DataBind();
            }
        }

        //Metodo che genera 12 articoli e li inserisce nell'hashset statico presente nella classe Article
        protected void GenerateArticles()
        {
            Article.AddArticle(new Article("Super Mario Wonder", "Brand new Super Mario 2d style game!", 69.99, "https://m.media-amazon.com/images/I/81PDm2hnsjL._AC_SY879_.jpg"));
            Article.AddArticle(new Article("The Legend of Zelda: Tears of the Kingdom", "Ganondorf is back! Live the last journey in the Hyrule Kingdom, fighting new monsters with brand new powers!", 69.99, "https://m.media-amazon.com/images/I/81uIdB9nHdL._AC_SY879_.jpg"));
            Article.AddArticle(new Article("Mario Kart 8 Deluxe", "Hit the road with the definitive version of Mario Kart 8 and play anytime, anywhere. Race your friends or battle them in a revised battle mode for new and returning battle courses", 49.99, "https://m.media-amazon.com/images/I/81iJG2js5-S._SY679_.jpg"));
            Article.AddArticle(new Article("Super Smash Bros. Ultimate", "New stages and fighters are joined by the combined rosters of every past Super Smash Bros. Game", 50.99, "https://m.media-amazon.com/images/I/81aJ-R4E6gL._SY679_.jpg"));
            Article.AddArticle(new Article("Just Dance 2024 Edition - Standard Edition", "ALL-NEW TRACKLIST, UNIVERSES, AND CHARACTERS", 19.99, "https://m.media-amazon.com/images/I/719rfs3UNAL._SY679_.jpg"));
            Article.AddArticle(new Article("Super Mario RPG", "Jump through a colorful world and give attacks some extra oomph in battle!", 52.09, "https://m.media-amazon.com/images/I/81pUNVRNnFL._SY679_.jpg"));
            Article.AddArticle(new Article("Hogwarts Legacy", "EXPLORE AN OPEN WORLD. The wizarding world awaits you. Freely roam Hogwarts, Hogsmeade, the Forbidden Forest, and the surrounding Overland area.", 52.99, "https://m.media-amazon.com/images/I/816nYzwbSOL._AC_SY879_.jpg"));
            Article.AddArticle(new Article("Animal Crossing: New Horizons", "Build your community from scratch on a deserted island brimming with possibility; Create your personal getaway and customize your character, home, decorations, and even the landscape itself", 40.99, "https://m.media-amazon.com/images/I/81UfEdvf2kL._SY679_.jpg"));
            Article.AddArticle(new Article("Splatoon 2", "New weapons - New dual wielding Splat Dualies join the action, complete with a new Dodge Roll move. Mainstays like the Splat Roller and Splat Charger have also been remixed to include new gameplay mechanics and brand new special weapons.", 49.99, "https://m.media-amazon.com/images/I/81F9LrZ7YgL._SY679_.jpg"));
            Article.AddArticle(new Article("Luigi's Mansion 3", "Catch ghosts and solve puzzles to rescue Mario and friends in the Last Resort hotel; Each floor of this towering hotel is themed, from the décor to the puzzles to the boss", 53.99, "https://m.media-amazon.com/images/I/81-FD3tzUlL._SY679_.jpg"));
            Article.AddArticle(new Article("Mario Plus Rabbids Kingdom Battle", "An epic journey starring eight heroes, Embark with your team of heroes on an epic quest to free your friends and put the Mushroom Kingdom back in order! Mario, Luigi, Peach, and Yoshi will join forces with four Rabbids heroes, each with their own unique personalities: boastful Rabbid Mario, fearful Rabbid Luigi, sassy Rabbid Peach, and off-his-rocker Rabbid Yoshi. A crazy tactical adventure, Mario and his friends will use never-before-seen weapons to engage in combat with their foes. With an arsenal of more than 250 weapons with unique statistics and specificities, players will choose how best to equip each of their eight heroes. Turn-based gameplay allows players to take the time they need to position their heroes and unleash their actions. Play additional co-op challenges with a friend in local multiplayer, featuring three levels of difficulty. Share a pair of Joy-Con controllers or use your Nintendo Switch Pro Controllers. A fresh Mario experience, Discover the Mushroom Kingdom like you never have before - twisted by the mischievous Rabbids! Experience a feel-good adventure filled with humor, epic music, vibrant animation, and colorful visuals, powered by the Snowdrop engine.", 35.99, "https://m.media-amazon.com/images/I/81DEtGHy41L._SY679_.jpg"));
            Article.AddArticle(new Article("Crash™ Team Racing Nitro-Fueled", "Crash is back in the driver’s seat! Get ready to go fur-throttle with Crash Team Racing Nitro-Fueled - the authentic CTR experience, now fully-remastered and revved up to the max", 28.99, "https://m.media-amazon.com/images/I/81xOmCNm6iL._SY679_.jpg"));
        }

        //Metodo che aggiunge un articolo al carrello
        protected void AddToCart(object sender, EventArgs e)
        {
            //Prendo l'id dell'articolo dal CommandArgument del Button
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);

            //Se non esiste, creo una Session con chiave "cart" e la inizializzo come List<Article>
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Article>();
            }

            //Riprendo la lista
            List<Article> cart = (List<Article>)Session["cart"];

            //Cerco l'articolo corrispondente all'id e lo aggiungo alla lista cart, poi riaggiorno la Session con il cart aggiornato
            Article myArticle = Article.GetArticleById(id);
            cart.Add(myArticle);
            Session["cart"] = cart;
            Response.Redirect(Request.RawUrl); //Comando che forza il rendering così da avere feedback immediato all'aggiornamento del carrello
        }
    }
}