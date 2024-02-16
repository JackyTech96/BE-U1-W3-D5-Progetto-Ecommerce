using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BE_U1_W3_D5_Progetto_ECommerce
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Controlla se l'ID del prodotto è presente nella query string
                if (Request.QueryString["Id"] != null)
                {
                    // Recupera l'ID del prodotto dalla query string
                    int productId = Convert.ToInt32(Request.QueryString["Id"]);

                    // Utilizza l'ID del prodotto per ottenere i dettagli del prodotto
                    Articolo prodotto = DatabaseSimulato.GetDettagliProdotto(productId);

                    // Verifica se il prodotto è valido
                    if (prodotto != null)
                    {
                        // Visualizza i dettagli del prodotto nella pagina
                        PopolaDettagliProdotto(prodotto);
                    }
                    else
                    {
                        // Se il prodotto non è valido
                        lblMessaggio.Text = "Errore nel recuperare il prodotto";
                    }
                }
            }
        }

        private void PopolaDettagliProdotto(Articolo prodotto)
        {
            // Popola i controlli nella pagina con i dettagli del prodotto
            lblNomeProdotto.Text = prodotto.Nome;
            lblDescrizioneProdotto.Text = prodotto.Descrizione;
            lblPrezzoProdotto.Text = string.Format("Prezzo: €{0:0.00}", prodotto.Prezzo);
            imgProdotto.ImageUrl = prodotto.ImmagineUrl;
        }

        protected void btnTornaAiProdotti_Click(object sender, EventArgs e)
        {
            // Reindirizza l'utente alla schermata dei prodotti 
            Response.Redirect("Default.aspx");
        }
    }
}
    
