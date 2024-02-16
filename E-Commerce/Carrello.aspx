<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="E_Commerce.Carrello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <p id="emptyCart" runat="server" class="display-5" style="display: none">Carrello vuoto</p>
        <div id="cartRow" style="display: none" class="row" runat="server">
            <asp:Repeater ID="cartRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-12">
                        <div style="height: 100px" class="d-flex justify-content-between align-items-center border border-dark bg-info">
                            <div class="h-100 d-flex">
                                <div class="h-100 p-2 me-3">
                                    <img src='<%# Eval("Image") %>' class="h-100" alt='<%# Eval("Name") %>'>
                                </div>
                                <div class="py-2">
                                    <h5><%# Eval("Name") %></h5>
                                    <p><%# Eval("Price", "{0:c2}") %></p>
                                </div>
                            </div>
                            <div class="me-3">
                                <asp:Button class="btn btn-danger" ID="ButtonRemove" runat="server" Text="Rimuovi" CommandArgument='<%# Eval("Id") %>' OnClick="Remove" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="d-flex justify-content-between align-items-center mt-3">
                <div>
                    <p id="totalPrice" class="font-monospace mb-0" runat="server"></p>
                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Acquista" />
                </div>
                <asp:Button CssClass="btn btn-danger" ID="RemoveAllBtn" runat="server" Text="Rimuovi tutto" OnClick="RemoveAll"/>
            </div>
        </div>
    </main>
</asp:Content>
