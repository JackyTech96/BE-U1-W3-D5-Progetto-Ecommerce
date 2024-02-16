<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BE_U1_W3_D5_Progetto_ECommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <main class="container">
        <h1 class="text-center mb-3">Benvenuti all'Epic-Commerce</h1>
        <div class="row">
            <asp:Repeater runat="server" ID="rptArticoli" OnItemCommand="rptArticoli_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-3 mb-3">
                        <div class="card">
                            <asp:Image runat="server" ID="imgArticolo" ImageUrl='<%# Eval("ImmagineUrl") %>' AlternateText='<%# Eval("Nome") %>' CssClass="card-img-top"  style="max-height: 200px; object-fit: contain" />
                            <div class="card-body">
                                <h3 class="card-title"><asp:Literal runat="server" ID="litNome" Text='<%# Eval("Nome") %>'></asp:Literal></h3>
                                <p class="card-text">Prezzo: €<asp:Literal runat="server" ID="litPrezzo" Text='<%# String.Format("{0:0.00}", Eval("Prezzo")) %>'></asp:Literal></p>
                                <asp:Button runat="server" CommandName="Dettaglio" CommandArgument='<%# Eval("Id") %>' Text="Dettaglio" CssClass="btn btn-primary" />
                                <asp:Button runat="server" CommandName="AggiungiAlCarrello" CommandArgument='<%# Eval("Id") %>' Text="Aggiungi al Carrello" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </main>

</asp:Content>
