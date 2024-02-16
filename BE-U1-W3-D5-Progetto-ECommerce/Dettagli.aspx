<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dettagli.aspx.cs" Inherits="BE_U1_W3_D5_Progetto_ECommerce.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
      <h2>Dettagli prodotto:</h2>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-3 text-center"> 
                    <div class="card">                       
                        <asp:Image runat="server" ID="imgProdotto" CssClass="card-img-top" style="max-height:200px; object-fit:contain"/>                        
                        <div class="card-body">                           
                            <h5 class="card-title">
                                <asp:Label runat="server" ID="lblNomeProdotto" CssClass="nome-prodotto" />
                            </h5>                                                       
                            <p class="card-text">
                                <asp:Label runat="server" ID="lblDescrizioneProdotto" CssClass="descrizione-prodotto" />
                            </p>
                            <p class="card-text">
                                <asp:Label runat="server" ID="lblPrezzoProdotto" CssClass="prezzo-prodotto" />
                            </p>
                        </div>
                    </div>
                     <asp:Label runat="server" ID="lblMessaggio" CssClass="messaggio-errore" />
                     <asp:Button runat="server" ID="btnTornaAiProdotti" OnClick="btnTornaAiProdotti_Click" Text="Torna ai Prodotti" CssClass="btn btn-secondary mt-3" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
