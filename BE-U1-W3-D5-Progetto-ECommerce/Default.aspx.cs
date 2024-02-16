using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BE_U1_W3_D5_Progetto_ECommerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ottiene la lista di articoli dal database simulato
                List<Ecommerce> listaArticoli = DatabaseSimulato.GetListaArticoli();

                // Assegna la lista di articoli al Repeater
                rptArticoli.DataSource = listaArticoli;
                rptArticoli.DataBind();
            }
        }

        protected void rptArticoli_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Gestisce gli eventi generati dai controlli nel Repeater

            // Ottieni l'ID dell'articolo associato al comando
            int articoloId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Dettaglio")
            {
                // Se il comando è "Dettaglio", reindirizza alla pagina Dettaglio.aspx con l'ID del prodotto nella query string
                Response.Redirect($"Dettagli.aspx?Id={articoloId}");
            }
            else if (e.CommandName == "AggiungiAlCarrello")
            {
                // Se il comando è "AggiungiAlCarrello"

                // Ottieni i dettagli dell'articolo dal database simulato in base all'ID
                Ecommerce articolo = DatabaseSimulato.GetDettagliProdotto(articoloId);

                // Aggiungi l'articolo al carrello
                if (articolo != null)
                {
                    Carrello.AggiungiAlCarrello(articolo);

                    // Dopo l'aggiunta al carrello, reindirizza alla pagina del carrello
                    Response.Redirect("Carrello.aspx");
                }
            }
        }
    }
}
