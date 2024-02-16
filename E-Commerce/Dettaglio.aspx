<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="E_Commerce.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container d-flex justify-content-center">
        <div class="d-flex">
            <div class="me-5">
                <img id="imageArticle" src="" width="300" runat="server"/>
            </div>
            <div class="d-flex flex-column justify-content-between">
                <div>

                <p id="titleArticle" class="display-4 fw-bold" runat="server"></p>
                <p id="descriptionArticle" class="fs-5 fw-light" runat="server"></p>
                </div>
                <div>

                <p id="priceArticle" class="fs-5 font-monospace mb-0" runat="server"></p>
                <asp:Button ID="Button1" runat="server" Text="Aggiungi al carrello" class="btn btn-sm btn-primary" OnClick="AddToCart" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
