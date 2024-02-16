using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BE_U1_W3_D5_Progetto_ECommerce
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Leggi il cookie del carrello
                List<int> carrello = LeggiCookieCarrello();

                // Mostra l'elenco dei prodotti nel carrello
                MostraProdottiNelCarrello(carrello);

                // Calcola e mostra il totale del carrello
                CalcolaEVisualizzaTotale(carrello);
            }
        }

        private List<int> LeggiCookieCarrello()
        {
            HttpCookie cookie = Request.Cookies["Carrello"];

            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                // Estrai l'elenco degli ID degli articoli dal cookie
                string[] idArticoli = cookie.Value.Split(',');
                List<int> carrello = idArticoli.Select(id => Convert.ToInt32(id)).ToList();
                return carrello;
            }

            return new List<int>();
        }

        private void MostraProdottiNelCarrello(List<int> carrello)
        {
            // Ottieni gli articoli nel carrello dalla classe Carrello
            List<Ecommerce> prodottiNelCarrello = Carrello.GetArticoliNelCarrello();

            // Assegna la lista di prodotti al controllo GridView o Repeater
            rptProdottiNelCarrello.DataSource = prodottiNelCarrello;
            rptProdottiNelCarrello.DataBind();
        }

        private void CalcolaEVisualizzaTotale(List<int> carrello)
        {
            // Ottieni gli articoli nel carrello dalla classe Carrello
            List<Ecommerce> prodottiNelCarrello = Carrello.GetArticoliNelCarrello();

            // Calcola il totale
            decimal totale = prodottiNelCarrello.Sum(a => a.Prezzo);

            // Mostra il totale nel lblTotaleCarrello
            lblTotaleCarrello.Text = $"Totale Carrello: €{totale:N2}";
        }

        protected void rptProdottiNelCarrello_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RimuoviDalCarrello")
            {
                int idArticolo = Convert.ToInt32(e.CommandArgument);

                // Rimuovi l'articolo dal carrello
                Carrello.RimuoviDalCarrello(idArticolo);

                // Ricarica la pagina per riflettere i cambiamenti
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnSvuotaCarrello_Click(object sender, EventArgs e)
        {
            // Svuota completamente il carrello
            Carrello.SvuotaCarrello();

            // Aggiorna la visualizzazione dei prodotti nel carrello e il totale
            List<int> carrello = LeggiCookieCarrello();
            MostraProdottiNelCarrello(carrello);
            CalcolaEVisualizzaTotale(carrello);
        }
        protected void btnTornaAiProdotti_Click(object sender, EventArgs e)
        {
            // Reindirizza l'utente alla schermata dei prodotti 
            Response.Redirect("Default.aspx");
        }
    }
}


