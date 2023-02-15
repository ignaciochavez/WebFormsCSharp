<%@ Page Title="SOAPCSharpCheckAuth" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="SOAPCSharpCheckAuth.aspx.cs" Inherits="WebApp.Pages.Check.SOAPCSharpCheckAuth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="min-height: 78.3vh;">
        <div class="mt-3 pb-3 container" style="border: 1px solid rgba(50, 50, 50, 0.3); border-radius: 6px;">
            <div class="row">
                <div class="col-md-6 text-center my-auto mx-auto">
                    <h1 class="mt-3">SOAPCSharpCheckAuth</h1>
                </div>
            </div>

            <div class="row justify-content-center mt-3">
                <div class="col-md-10">
                    <asp:Panel ID="pAlert" runat="server" Visible="true" role="alert">
                        <h4 id="hTitle" runat="server" class="alert-heading"></h4>
                    </asp:Panel>  
                </div>
            </div>
        </div>
    </div>

</asp:Content>
