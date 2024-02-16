<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">
        <div class="row row-cols-4 gy-2">
            <asp:Repeater ID="Repeater" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card border border-dark bg-info text-white">
                            <img src='<%# Eval("Image") %>' class="card-img-top img-fluid" alt='<%# Eval("Name") %>'>
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                <p class="card-text"><%# Eval("Price", "{0:c2}") %></p>
                                <div class="d-flex justify-content-between w-100">
                                    <a href='<%# "Dettagli.aspx?IdProdotto=" + Eval("Id") %>' class="btn btn-sm btn-success">Dettagli</a>
                                    <asp:Button ID="Button1" runat="server" Text="Aggiungi al carrello" class="btn btn-sm btn-primary" CommandArgument='<%# Eval("Id") %>' OnClick="AddToCart" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </main>

</asp:Content>
