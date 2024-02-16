<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="BE_U1_W3_D5_Progetto_ECommerce.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Il Tuo Carrello</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="rptProdottiNelCarrello" runat="server" AutoGenerateColumns="False" OnItemCommand="rptProdottiNelCarrello_ItemCommand" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" ItemStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" SortExpression="Descrizione" />
                        <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" SortExpression="Prezzo" DataFormatString="{0:C}" HtmlEncode="False" ItemStyle-CssClass="text-center"/>
                        <asp:TemplateField HeaderText="Azioni">
                            <ItemTemplate>
                                <div class="text-center">
                                    <asp:Button runat="server" CommandName="RimuoviDalCarrello" CommandArgument='<%# Eval("Id") %>' Text="Rimuovi" CssClass="btn btn-danger" />
                                </div>                             
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 mt-3">
                <asp:Button runat="server" ID="btnSvuotaCarrello" OnClick="btnSvuotaCarrello_Click" Text="Svuota Carrello" CssClass="btn btn-dark" />
                <br />
                <asp:Label runat="server" ID="lblTotaleCarrello" Text="Totale Carrello: €0.00" CssClass="mt-2" />
                <br />
                <asp:Button runat="server" ID="btnTornaAiProdotti" OnClick="btnTornaAiProdotti_Click" Text="Torna ai Prodotti" CssClass="btn btn-secondary mt-3" />
            </div>
        </div>
    </main>
</asp:Content>
