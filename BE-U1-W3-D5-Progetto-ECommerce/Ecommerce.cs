using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE_U1_W3_D5_Progetto_ECommerce
{
    // Classe che rappresenta un singolo prodotto nel sistema di E-commerce
    public class Ecommerce
    {
        public int Id { get; set; }               // Identificativo univoco del prodotto
        public string Nome { get; set; }          // Nome del prodotto
        public string Descrizione { get; set; }   // Descrizione del prodotto
        public decimal Prezzo { get; set; }       // Prezzo del prodotto
        public string ImmagineUrl { get; set; }   // URL dell'immagine del prodotto
    }

    // Classe statica simulata per gestire il database di prodotti
    public static class DatabaseSimulato
    {
        private static List<Ecommerce> listaArticoli = new List<Ecommerce>
        {
            // Esempi di prodotti predefiniti nel catalogo
            new Ecommerce { Id = 1, Nome = "Occhiale 1", Descrizione = "Occhiali da vista con montatura tigrata", Prezzo = 120.50m, ImmagineUrl = "https://images.unsplash.com/photo-1603578119639-798b8413d8d7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
            new Ecommerce { Id = 2, Nome = "Occhiale 2", Descrizione = "Occhiali anti luce blu con montatura nera", Prezzo = 75, ImmagineUrl = "https://images.unsplash.com/photo-1483412468200-72182dbbc544?q=80&w=2073&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
            new Ecommerce { Id = 3, Nome = "Occhiale 3", Descrizione = "Occhiali da vista con montatura nera", Prezzo = 199.95m, ImmagineUrl = "https://images.unsplash.com/photo-1619089661769-3101dbac9257?q=80&w=2028&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
            new Ecommerce { Id = 4, Nome = "Occhiale 4", Descrizione = "Occhiali da sole con montatura nera e lenti fluo", Prezzo = 250, ImmagineUrl = "https://images.unsplash.com/flagged/photo-1577479662097-5e0347cbe923?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }
        };

        // Metodo per ottenere la lista completa di prodotti nel catalogo
        public static List<Ecommerce> GetListaArticoli()
        {
            return listaArticoli;
        }

        // Metodo per ottenere i dettagli di un singolo prodotto in base all'ID
        public static Ecommerce GetDettagliProdotto(int productId)
        {
            return listaArticoli.FirstOrDefault(a => a.Id == productId);
        }
    }

    // Classe statica per gestire il carrello della spesa
    public static class Carrello
    {
        public static List<Ecommerce> articoliNelCarrello = new List<Ecommerce>();

        // Metodo per ottenere la lista di articoli nel carrello
        public static List<Ecommerce> GetArticoliNelCarrello()
        {
            return articoliNelCarrello;
        }

        // Metodo per aggiungere un articolo al carrello
        public static void AggiungiAlCarrello(Ecommerce articolo)
        {
            articoliNelCarrello.Add(articolo);
        }

        // Metodo per rimuovere un articolo dal carrello in base all'ID
        public static void RimuoviDalCarrello(int articoloId)
        {
            Ecommerce articoloDaRimuovere = articoliNelCarrello.FirstOrDefault(a => a.Id == articoloId);
            if (articoloDaRimuovere != null)
            {
                articoliNelCarrello.Remove(articoloDaRimuovere);
            }
        }

        // Metodo per svuotare completamente il carrello
        public static void SvuotaCarrello()
        {
            articoliNelCarrello.Clear();
        }

        // Metodo per calcolare il totale del carrello
        public static decimal CalcolaTotale()
        {
            return articoliNelCarrello.Sum(a => a.Prezzo);
        }
    }
}
