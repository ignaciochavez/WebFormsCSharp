<%@ Page Title="Check" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="WebApp.Pages.Check.Check" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="min-height: 78.3vh;">
        <div class="mt-3 pb-3 container" style="border: 3px solid rgba(50, 50, 50, 0.3); border-radius: 6px;">
            <div class="row">
                <div class="col-md-6 text-center my-auto mx-auto">
                    <h1 class="mt-3">Check</h1>
                </div>
            </div>

            <div class="row justify-content-center mt-3">
                <div class="col-md-10">
                    <asp:Panel ID="pAlert" runat="server" Visible="true" role="alert">
                        <h4 id="hTitle" runat="server" class="alert-heading"></h4>
                        <p id="pMessage" runat="server"></p>
                    </asp:Panel>  
                </div>
            </div>
        </div>
    </div>

</asp:Content>
